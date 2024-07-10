using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrabajoEdi3.Entidades;
using TrabajoEdi3.Servicios.Interfaces;
using TrabajoEdi3.Windows.Helpers;

namespace TrabajoEdi3.Windows
{
    public partial class FrmDeporte : Form
    {
        private readonly IServicioDeporte _servicio;
        private List<Deporte>? lista;
        private readonly IServicioZapatilla _servicioZapatilla;


        private int pageCount;
        private int pageSize = 15;
        private int pageNum = 0;
        private int recordCount;
        public FrmDeporte(IServicioDeporte servicio, IServicioZapatilla servicioZapatilla)
        {
            InitializeComponent();
            _servicio = servicio;
            _servicioZapatilla = servicioZapatilla;
        }



        private void FrmDeporte_Load(object sender, EventArgs e)
        {
            RecargarGrilla();
            ActualizarCantidad();
        }

        private void ActualizarCantidad()
        {
            txtCantidadRegistros.Text = _servicio.GetCantidad().ToString();
        }

        private void RecargarGrilla()
        {
            try
            {
                lista = _servicio.GetLista();
                MostrarDatosEnGrilla();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void MostrarDatosEnGrilla()
        {
            GridHelper.LimpiarGrilla(dgvDatos);
            if (lista is not null)
            {
                foreach (var item in lista)
                {
                    DataGridViewRow r = GridHelper.ConstruirFila(dgvDatos);
                    GridHelper.SetearFila(r, item);
                    GridHelper.AgregarFila(r, dgvDatos);
                }

            }
        }

        private void tstSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tstNuevo_Click(object sender, EventArgs e)
        {
            FrmDeporteAE frm = new FrmDeporteAE() { Text = "Agregar Deporte" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            try
            {
                Deporte? deporte = frm.GetDeporte();

                if (deporte is not null)
                {
                    if (!_servicio.Existe(deporte))
                    {
                        _servicio.Guardar(deporte);
                        ActualizarCantidad();
                        var r = GridHelper.ConstruirFila(dgvDatos);
                        GridHelper.SetearFila(r, deporte);
                        GridHelper.AgregarFila(r, dgvDatos);
                        MessageBox.Show("Registro Agregado Satisfactoriamente!!!",
                            "Mensaje",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("Registro Duplicado",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

            }

        }

        private void tstBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            if (r.Tag is not null)
            {
                Deporte deporte = (Deporte)r.Tag;
                DialogResult dr = MessageBox.Show($"¿Desea dar de baja a {deporte.NombreDeporte}?",
                    "Confirmar Operación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.No)
                {
                    return;
                }
                try
                {


                    if (!_servicio.EstaRelacionado(deporte))
                    {
                        _servicio.Borrar(deporte);
                        ActualizarCantidad();

                        GridHelper.QuitarFila(r, dgvDatos);
                        MessageBox.Show("Registro Borrado Satisfactoriamente!!!",
                            "Mensaje",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);


                    }
                    else
                    {
                        MessageBox.Show("Registro Relacionado...Baja denegada!!!",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                }

            }
        }

        private void tstEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            if (r.Tag == null) { return; }
            Deporte deporte = (Deporte)r.Tag;
            FrmDeporteAE frm = new FrmDeporteAE() { Text = "Editar Deporte" };
            frm.SetDeporte(deporte);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            try
            {
                deporte = frm.GetDeporte();

                if (!_servicio.Existe(deporte))
                {
                    _servicio.Guardar(deporte);

                    GridHelper.SetearFila(r, deporte);
                    MessageBox.Show("Registro Editado Satisfactoriamente!!!",
                        "Mensaje",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Registro duplicado",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

            }

        }

        private void aZToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tsbConsultar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            if (r is null)
            {
                return;
            }
            Deporte deporte = (Deporte)r.Tag;
            var deportes = _servicio.GetDeportePorId(deporte.DeporteId);
            recordCount = _servicioZapatilla.GetCantidad(s => s.Deporte == deportes);
            pageCount = FromHelper.CalcularPaginas(recordCount, pageSize);
            var lista = _servicioZapatilla.GetListaPaginadaOrdenadaFiltrada(pageNum, pageSize, null, deportes, null, null, null);

            FrmZapatillasPorDeporte frm = new FrmZapatillasPorDeporte(_servicioZapatilla);
            frm.SetDatosParaElPaginadoYFiltro(pageCount, pageNum, pageSize, recordCount, deportes);
            frm.SetLista(lista);
            frm.ShowDialog();
        }
    }
}
