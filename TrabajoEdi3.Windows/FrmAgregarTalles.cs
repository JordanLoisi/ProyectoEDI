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
using TrabajoEdi3.Windows.Helpers;

namespace TrabajoEdi3.Windows
{
    public partial class FrmAgregarTalles : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private Talles? TallesSeleccionado;
        public FrmAgregarTalles(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }

        private void FrmAgregarTalles_Load(object sender, EventArgs e)
        {
            base.OnLoad(e);
            CombosHelper.CargarComboTalle(_serviceProvider, ref cboTalles);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
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
    }
}
