using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrabajoEdi3.Entidades;

namespace TrabajoEdi3.Windows
{
    public partial class FrmDeporteAE : Form
    {
        private Deporte deporte;
        public FrmDeporteAE()
        {
            InitializeComponent();
        }
        public Deporte? GetDeporte()
        {
            return deporte;
        }
        public void SetDeporte(Deporte? deportes)
        {
            deporte = deportes;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (deporte != null)
            {
                txtDeporte.Text = deporte.NombreDeporte;
            }
        }


        private void FrmDeporteAE_Load(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (deporte == null)
                {
                    deporte = new Deporte();

                }
                deporte.NombreDeporte = txtDeporte.Text;

                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valid = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtDeporte.Text))
            {
                valid = false;
                errorProvider1.SetError(txtDeporte, "Nombre de deporte requerido!!!");
            }
            return valid;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void txtDeporte_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
