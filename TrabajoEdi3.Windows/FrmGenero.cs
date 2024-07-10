using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Formats.Tar;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrabajoEdi3.Entidades;
using TrabajoEdi3.Servicios.Interfaces;
using TrabajoEdi3.Windows.Helpers;

namespace TrabajoEdi3.Windows
{
    public partial class FrmGenero : Form
    {
        private readonly IServicioGenero _servicio;
        private List<Genero>? lista;

        private bool FilterOn = false;

        private int pageCount;
        private int pageSize = 15;
        private int pageNum = 0;
        private int recordCount;
        public FrmGenero(IServicioGenero servicio)
        {
            InitializeComponent();
            _servicio = servicio;
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

        private void FrmGenero_Load(object sender, EventArgs e)
        {
            RecargarGrilla();
            ActualizarCantidad();
        }

        private void ActualizarCantidad()
        {
            txtCantidadRegistros.Text = _servicio.GetCantidad().ToString();
        }

        private void tstSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tstNuevo_Click(object sender, EventArgs e)
        {
            FrmGeneroAE frm = new FrmGeneroAE() { Text = "Agregar Genero" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            try
            {
                Genero? genero = frm.GetGenero();

                if (genero is not null)
                {
                    if (!_servicio.Existe(genero))
                    {
                        _servicio.Guardar(genero);
                        ActualizarCantidad();
                        var r = GridHelper.ConstruirFila(dgvDatos);
                        GridHelper.SetearFila(r, genero);
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
                Genero genero = (Genero)r.Tag;
                DialogResult dr = MessageBox.Show($"¿Desea dar de baja a {genero.GeneroNombre}?",
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


                    if (!_servicio.EstaRelacionado(genero))
                    {
                        _servicio.Borrar(genero);
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
            Genero genero = (Genero)r.Tag;
            FrmGeneroAE frm = new FrmGeneroAE() { Text = "Editar Genero" };
            frm.SetGenero(genero);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            try
            {
                genero = frm.GetGenero();

                if (!_servicio.Existe(genero))
                {
                    _servicio.Guardar(genero);

                    GridHelper.SetearFila(r, genero);
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

      
    }
}
