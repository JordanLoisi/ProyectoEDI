using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrabajoEdi3.Entidades;
using TrabajoEdi3.Entidades.Enums;
using TrabajoEdi3.Servicios.Interfaces;
using TrabajoEdi3.Windows.Helpers;

namespace TrabajoEdi3.Windows
{
    public partial class FrmColor : Form
    {
        private readonly IServicioColor _servicio;
        private List<Entidades.Color>? lista;

       

        public FrmColor(IServicioColor servicio)
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

        private void ActualizarCantidad()
        {
           txtCantidadRegistros.Text=_servicio.GetCantidad().ToString();
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
            FrmColorAE frm = new FrmColorAE() { Text = "Agregar Color" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            try
            {
                Entidades.Color? color = frm.GetColor();

                if (color is not null)
                {
                    if (!_servicio.Existe(color))
                    {
                        _servicio.Guardar(color);
                        ActualizarCantidad();
                        var r = GridHelper.ConstruirFila(dgvDatos);
                        GridHelper.SetearFila(r, color);
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
                Entidades.Color color = (Entidades.Color)r.Tag;
                DialogResult dr = MessageBox.Show($"¿Desea dar de baja a {color.ColorName}?",
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


                    if (!_servicio.EstaRelacionado(color))
                    {
                        _servicio.Borrar(color);
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
            Entidades.Color color = (Entidades.Color)r.Tag;
            FrmColorAE frm = new FrmColorAE() { Text = "Editar Color" };
            frm.SetColor(color);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            try
            {
                color = frm.GetColor();

                if (!_servicio.Existe(color))
                {
                    _servicio.Guardar(color);

                    GridHelper.SetearFila(r, color);
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

        private void FrmColor_Load_1(object sender, EventArgs e)
        {
            RecargarGrilla();
            ActualizarCantidad();
        }

       

    
        

        private void panelNavegacion_Paint(object sender, PaintEventArgs e)
        {

        }

      

       
    }
}
