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
    public partial class FrmGeneroAE : Form
    {
        private Genero genero;

        public Genero? GetGenero()
        {
            return genero;
        }
        public void SetGenero(Genero? generos)
        {
            genero = generos;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (genero != null)
            {
                txtGenero.Text = genero.GeneroNombre;
            }
        }
        public FrmGeneroAE()
        {
            InitializeComponent();
        }

        private void FrmGeneroAE_Load(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (genero == null)
                {
                    genero = new Genero();

                }
                genero.GeneroNombre = txtGenero.Text;

                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valid = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtGenero.Text))
            {
                valid = false;
                errorProvider1.SetError(txtGenero, "Nombre de Color requerido!!!");
            }
            return valid;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}

