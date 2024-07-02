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

        private bool FilterOn = false;

        private int pageCount;
        private int pageSize = 15;
        private int pageNum = 0;
        private int recordCount;
        public FrmDeporte(IServicioDeporte servicio)
        {
            InitializeComponent();
            _servicio = servicio;
        }


        private void FrmDeporte_Load(object sender, EventArgs e)
        {
            RecargarGrilla();
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

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            FilterOn = false;
            RecargarGrillDeTodosLosDeportes();
        }

        private void RecargarGrillDeTodosLosDeportes()
        {
            try
            {
                recordCount = _servicio.GetCantidad();
                pageCount = FromHelper.CalcularPaginas(recordCount, pageSize);
                txtCantidadRegistros.Text = pageCount.ToString();
                CombosHelper.CargarCombosPaginas(pageCount, ref cboPaginas);
                MostrarDatosEnGrilla();
            }
            catch (Exception)
            {
                throw;

            }
        }

        private void btnPrimero_Click(object sender, EventArgs e)
        {
            // Ir a la primera página
            pageNum = 0;
            cboPaginas.SelectedIndex = pageNum;
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            // Ir a la página anterior
            pageNum--;
            if (pageNum < 0) { pageNum = 0; }
            cboPaginas.SelectedIndex = pageNum;

        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            // Ir a la siguiente página
            pageNum++;
            if (pageNum > pageCount - 1) { pageNum = pageCount - 1; }
            cboPaginas.SelectedIndex = pageNum;
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            // Ir a la última página
            pageNum = pageCount - 1;
            cboPaginas.SelectedIndex = pageNum;
        }
    }
}
