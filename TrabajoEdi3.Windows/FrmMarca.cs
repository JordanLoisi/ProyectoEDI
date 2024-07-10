using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrabajoEdi3.Datos.Migrations;
using TrabajoEdi3.Entidades;
using TrabajoEdi3.Servicios.Interfaces;
using TrabajoEdi3.Windows.Helpers;

namespace TrabajoEdi3.Windows
{
    public partial class FrmMarca : Form
    {
        private readonly IServicioMarca _servicio;
        private List<Marca>? lista;
        private readonly IServicioZapatilla _servicioZapatilla;

        private bool FilterOn = false;

        private int pageCount;
        private int pageSize = 15;
        private int pageNum = 0;
        private int recordCount;
        public FrmMarca(IServicioMarca servicio,IServicioZapatilla servicioZapatilla)
        {
            InitializeComponent();
            _servicio = servicio;
            _servicioZapatilla = servicioZapatilla;
        }

        private void FrmMarca_Load(object sender, EventArgs e)
        {
            RecargarGrilla();
            ActualizarCantidad();

        }

        private void ActualizarCantidad()
        {
            txtCantidadRegistros.Text = _servicio.GetCantidad().ToString();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            FrmMarcaAE frm = new FrmMarcaAE() { Text = "Agregar Marca" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            try
            {
                Marca? marca = frm.GetMarca();

                if (marca is not null)
                {
                    if (!_servicio.Existe(marca))
                    {
                        _servicio.Guardar(marca);
                        ActualizarCantidad();
                        var r = GridHelper.ConstruirFila(dgvDatos);
                        GridHelper.SetearFila(r, marca);
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

        private void BtnBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            if (r.Tag is not null)
            {
                Marca marca = (Marca)r.Tag;
                DialogResult dr = MessageBox.Show($"¿Desea dar de baja a {marca.MarcaNombre}?",
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


                    if (!_servicio.EstaRelacionado(marca))
                    {
                        _servicio.Borrar(marca);
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

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            if (r.Tag == null) { return; }
            Marca? marca = (Marca)r.Tag;
            FrmMarcaAE frm = new FrmMarcaAE() { Text = "Editar País" };
            frm.SetMarca(marca);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            try
            {
                marca = frm.GetMarca();

                if (!_servicio.Existe(marca))
                {
                    _servicio.Guardar(marca);

                    GridHelper.SetearFila(r, marca);
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

        private void txtCantidadRegistros_TextChanged(object sender, EventArgs e)
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
            Marca marca = (Marca)r.Tag;
            var marcas = _servicio.GetMarcaPorId(marca.MarcaId);
            recordCount = _servicioZapatilla.GetCantidad(s => s.Marca == marcas);
            pageCount = FromHelper.CalcularPaginas(recordCount, pageSize);
            var lista = _servicioZapatilla.GetListaPaginadaOrdenadaFiltrada(pageNum, pageSize, null,null, marcas,null, null);

            FrmZapatillasPorMarca frm = new FrmZapatillasPorMarca(_servicioZapatilla);
            frm.SetDatosParaElPaginadoYFiltro(pageCount, pageNum, pageSize, recordCount, marcas);
            frm.SetLista(lista);
            frm.ShowDialog();
        }
    }
}

    
    

