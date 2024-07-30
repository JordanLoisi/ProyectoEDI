using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrabajoEdi3.Windows
{
    public partial class FrmCantidadDeseada : Form
    {
        int cantidad = 0;
        public FrmCantidadDeseada()
        {
            InitializeComponent();
        }

        private void FrmCantidadDeseada_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                cantidad = int.Parse(txtCantidad.Text);
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (int.Parse(txtCantidad.Text) <= 0)
            {
                valido = false;
                errorProvider1.SetError(txtCantidad, "Cantidad no válido ");

            }

            return valido;

        }
        public int GetCantidad()
        {
            return cantidad;
        }
    }
}
