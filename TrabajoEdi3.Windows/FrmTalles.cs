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
using TrabajoEdi3.Entidades.Enums;
using TrabajoEdi3.Servicios.Interfaces;
using TrabajoEdi3.Windows.Helpers;

namespace TrabajoEdi3.Windows
{
    public partial class FrmTalles : Form
    {
        private readonly ITallesServicio _servicio;
        private List<Talles>? lista;
        private readonly IServicioZapatilla _servicioZapatilla;

        List<Talles> talles;

        Orden orden = Orden.SinOrden;

        private int cantidadPaginas;
        private int pageSize = 8;
        private int pageNum = 0;
        private int cantidadRegistros;

        public FrmTalles(ITallesServicio servicio, IServicioZapatilla servicioZapatilla)
        {
            InitializeComponent();
            _servicio = servicio;
            _servicioZapatilla = servicioZapatilla;
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
                        RecargarGrilla();
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
                cantidadRegistros = _servicio.GetCantidad();
                cantidadPaginas = FromHelper.CalcularPaginas(cantidadRegistros, pageSize);
                talles = _servicio.GetTallesPaginadosOrdenados(pageNum, pageSize, orden);
                CantidadPaginasLbl.Text = cantidadPaginas.ToString();

                PaginaActualLbl.Text = (pageNum + 1).ToString();

                CantidadTallesLbl.Text = cantidadRegistros.ToString();

                MostrarDatosEnGrilla();


            }
            catch (Exception)
            {

                throw;
            }

        }

        private void MostrarDatosEnGrilla()
        {
            GridHelper.LimpiarGrilla(dataGridView1);
            if (talles is not null)
            {
                foreach (var item in talles)
                {
                    DataGridViewRow r = GridHelper.ConstruirFila(dataGridView1);
                    GridHelper.SetearFila(r, item);
                    GridHelper.AgregarFila(r, dataGridView1);
                }

            }
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dataGridView1.SelectedRows[0];
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
            try
            {


                if (!_servicio.EstaRelacionado(talles))
                {
                    _servicio.Borrar(talles);

                    GridHelper.QuitarFila(r, dataGridView1);
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

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dataGridView1.SelectedRows[0];
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

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnPrimero_Click(object sender, EventArgs e)
        {
            pageNum = 0;
            PaginaActualLbl.Text = (pageNum + 1).ToString();
            RecargarGrilla();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            pageNum--;
            if (pageNum < 0) { pageNum = 0; }
            PaginaActualLbl.Text = (pageNum + 1).ToString();
            RecargarGrilla();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            pageNum++;
            if (pageNum > cantidadPaginas - 1) { pageNum = cantidadPaginas - 1; }
            PaginaActualLbl.Text = (pageNum + 1).ToString();

            RecargarGrilla();
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            pageNum = cantidadPaginas - 1;
            PaginaActualLbl.Text = (pageNum + 1).ToString();

            RecargarGrilla();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tsbOrden_Click(object sender, EventArgs e)
        {

        }

        private void aZToolStripMenuItem_Click(object sender, EventArgs e)
        {
            orden = Orden.AZ;
            RecargarGrilla();

        }

        private void zAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            orden = Orden.ZA;
            RecargarGrilla();
        }
    }
}
