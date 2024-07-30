using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrabajoEdi3.Entidades;
using TrabajoEdi3.Windows.Helpers;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TrabajoEdi3.Windows
{
    public partial class FrmAgregarTalles : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private Talles? TallesSeleccionado;
        private Zapatilla? ZapatillaSeleccionado;
        private int stock = 0;
        public FrmAgregarTalles(IServiceProvider serviceProvider,int stocks,Talles? talles)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            stock = stocks;
            TallesSeleccionado = talles;
        }

        private void FrmAgregarTalles_Load(object sender, EventArgs e)
        {

            CombosHelper.CargarComboTalle(_serviceProvider, ref cboTalles);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (TallesSeleccionado != null && stock!=null)
            {
                cboTalles.SelectedItem = TallesSeleccionado;
                txtStock.Text = stock.ToString();

            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                stock = int.Parse(txtStock.Text);
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (int.Parse(txtStock.Text)<=0)
            {
                valido = false;
                errorProvider1.SetError(txtStock, "Precio no válido o mal ingresado");

            }

            return valido;
        }

        private void cboTalles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTalles.SelectedItem is not null)
            {
                TallesSeleccionado = cboTalles.SelectedIndex > 0 ?
            (Talles)cboTalles.SelectedItem : null;

            }
        }

        public Talles? GetTalles()
        {
            return TallesSeleccionado;
        }
        public Zapatilla? GetZapatilla()
        {
            return ZapatillaSeleccionado;
        }
        internal int GetStock()
        {
            return stock;
        }

        //public void SetStock(int stocks)
        //{
           
        //}

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtStock_TextChanged(object sender, EventArgs e)
        {

        }

        //internal void SetTalle(Talles talles)
        //{
        //    TallesSeleccionado= talles;
        //}
    }
}
