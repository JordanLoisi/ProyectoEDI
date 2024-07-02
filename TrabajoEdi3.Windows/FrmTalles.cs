using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrabajoEdi3.Entidades;
using TrabajoEdi3.Servicios.Interfaces;
using TrabajoEdi3.Windows.Helpers;

namespace TrabajoEdi3.Windows
{
    public partial class FrmTalles : Form
    {
        private readonly ITallesServicio _servicio;
        private List<Talles>? lista;

        public FrmTalles(ITallesServicio servicio)
        {
            InitializeComponent();
            _servicio = servicio;

        }

        private void FrmTalles_Load(object sender, EventArgs e)
        {
            RecargarGrilla();
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            FrmTallesAE frm = new FrmTallesAE() { Text = "Agregar Talles" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            try
            {
                Talles? talle = frm.GetTalles();

                if (talle is not null)
                {
                    if (!_servicio.Existe(talle))
                    {
                        _servicio.Guardar(talle);
                        var r = GridHelper.ConstruirFila(dgvDatos);
                        GridHelper.SetearFila(r, talle);
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

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            Talles talles = (Talles)r.Tag;
            DialogResult dr = MessageBox.Show($"¿Desea dar de baja a {talles.TallesNumbero}?",
                "Confirmar Operación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No)
            {
                return;
            }
            //try
            //{


            //    //if (!_servicio.EstaRelacionado(talles))
            //    //{
            //    //    _servicio.Borrar(talles);

            //    //    GridHelper.QuitarFila(r, dgvDatos);
            //    //    MessageBox.Show("Registro Borrado Satisfactoriamente!!!",
            //    //        "Mensaje",
            //    //        MessageBoxButtons.OK,
            //    //        MessageBoxIcon.Information);


            //    //}
            //    else
            //    {
            //        MessageBox.Show("Registro Relacionado...Baja denegada!!!",
            //            "Error",
            //            MessageBoxButtons.OK,
            //            MessageBoxIcon.Error);

            //    }
            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show(ex.Message,
            //        "Error",
            //        MessageBoxButtons.OK,
            //        MessageBoxIcon.Error);

            //}

        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            Talles talles = (Talles)r.Tag;
            FrmTallesAE frm = new FrmTallesAE() { Text = "Editar Tipo" };
            frm.SetTalles(talles);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            try
            {
                talles = frm.GetTalles();

                if (!_servicio.Existe(talles))
                {
                    _servicio.Guardar(talles);

                    GridHelper.SetearFila(r, talles);
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
