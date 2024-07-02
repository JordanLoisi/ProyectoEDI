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
    public partial class FrmTallesAE : Form
    {
        private Talles? talle;
        public FrmTallesAE()
        {
            InitializeComponent();
        }
        public Talles? GetTalles()
        {
            return talle;
        }
        public void SetTalles(Talles? talles)
        {
            talle = talles;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (talle != null)
            {
                txtNumeroTalle.Text = talle.TallesNumbero.ToString();
            }
        }

        private void FrmTallesAE_Load(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            
            if (ValidarDatos())
            {
                if (talle == null)
                {
                    talle = new Talles();

                }
                talle.TallesNumbero=decimal.Parse(txtNumeroTalle.Text); 

                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valid = true;
            errorProvider1.Clear();
            if (!decimal.TryParse(txtNumeroTalle.Text, out decimal precio) ||
                (precio<=0))
            {
                valid = false;
                errorProvider1.SetError(txtNumeroTalle, "Numero de Talle requerido!!!");
            }
            return valid;
        }
    }
}
