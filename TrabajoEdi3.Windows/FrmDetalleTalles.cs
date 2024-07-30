using Microsoft.Extensions.DependencyInjection;
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
using TrabajoEdi3.Entidades.Dto;
using TrabajoEdi3.Servicios.Interfaces;
using TrabajoEdi3.Windows.Helpers;

namespace TrabajoEdi3.Windows
{
    public partial class FrmDetalleTalles : Form
    {
        private List<ZapatillasTalles> talle;
        private readonly IServiceProvider _serviceProvider;


        public FrmDetalleTalles(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;

        }

        public void SetDatos(List<ZapatillasTalles> talles)
        {
            this.talle = talles;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (talle != null)
            {
                CargarGrilla();

            }
        }

        private void CargarGrilla()
        {
            GridHelper.LimpiarGrilla(dgvDatos);
            foreach (var item in talle)
            {
                var r = GridHelper.ConstruirFila(dgvDatos);
                r.Cells[0].Value = item.Talles.TallesNumbero.ToString();
                r.Cells[1].Value = item.Stok;
                r.Tag = item;
                GridHelper.AgregarFila(r, dgvDatos);
            }
        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FrmDetalleTalles_Load(object sender, EventArgs e)
        {

        }

        private void tstEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            if (r.Tag == null) { return; }
            ZapatillasTalles tallezapas = (ZapatillasTalles)r.Tag;
            FrmAgregarTalles frm = new FrmAgregarTalles(_serviceProvider, tallezapas.Stok, tallezapas.Talles);

            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            try
            {
                tallezapas.Stok = frm.GetStock();

                var TallesServicio = _serviceProvider.GetService<ITallesServicio>();

                TallesServicio.EditarStocks(tallezapas);
                CargarGrilla();
                MessageBox.Show("Registro Editado Satisfactoriamente!!!");

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
            //if (dgvDatos.SelectedRows.Count == 0)
            //{
            //    return;
            //}
            //var r = dgvDatos.SelectedRows[0];
            //if (r.Tag == null) { return; }
            //ZapatillasTalles tallezapas = (ZapatillasTalles)r.Tag;
            //DialogResult dr = MessageBox.Show($"¿Desea dar de baja el talle {tallezapas.Talles.TallesNumbero}?",
            //  "Confirmar Operación",
            //  MessageBoxButtons.YesNo,
            //  MessageBoxIcon.Question,
            //  MessageBoxDefaultButton.Button2);
            //if (dr == DialogResult.No)
            //{
            //    return;
            //}
            //try
            //{
               

            //    if (!_servicio.EstaRelacionado(zapatilla))
            //    {
            //        _servicio.Borrar(zapatilla.ZapatillaId);

            //        GridHelper.QuitarFila(r, dgvDatos);
            //        MessageBox.Show("Registro Borrado Satisfactoriamente!!!",
            //            "Mensaje",
            //            MessageBoxButtons.OK,
            //            MessageBoxIcon.Information);


            //    }
            //    else
            //    {
            //        MessageBox.Show("Registro Relacionado...Baja denegada!!!",
            //            "Error",
            //            MessageBoxButtons.OK,
            //            MessageBoxIcon.Error);

            //    }
            //}
        }
    }
}
