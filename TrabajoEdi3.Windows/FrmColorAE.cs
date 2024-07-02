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
    public partial class FrmColorAE : Form
    {
        private Entidades.Color color;

        public Entidades.Color? GetColor()
        {
            return color;
        }
        public void SetColor(Entidades.Color? colors)
        {
            color = colors;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (color != null)
            {
                txtColor.Text = color.ColorName;
            }
        }
        public FrmColorAE()
        {
            InitializeComponent();
        }

        private void FrmColorAE_Load(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (color == null)
                {
                    color = new Entidades.Color();

                }
                color.ColorName = txtColor.Text;

                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valid = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtColor.Text))
            {
                valid = false;
                errorProvider1.SetError(txtColor, "Nombre de Color requerido!!!");
            }
            return valid;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
