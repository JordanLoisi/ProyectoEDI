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

namespace TrabajoEdi3.Windows
{
    public partial class FrmMarcaAE : Form
    {
        private Marca? marca;
        public FrmMarcaAE()
        {
            InitializeComponent();
        }
        public Marca? GetMarca()
        {
            return marca;
        }
        public void SetMarca(Marca? marcas)
        {
            marca = marcas;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (marca != null)
            {
                txtMarca.Text = marca.MarcaNombre;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (marca == null)
                {
                    marca = new Marca();

                }
                marca.MarcaNombre = txtMarca.Text;

                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valid = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtMarca.Text))
            {
                valid = false;
                errorProvider1.SetError(txtMarca, "Nombre de marca requerido!!!");
            }
            return valid;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void txtMarca_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
