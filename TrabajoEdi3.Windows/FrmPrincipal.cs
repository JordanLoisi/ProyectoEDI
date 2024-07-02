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
using TrabajoEdi3.Servicios.Interfaces;

namespace TrabajoEdi3.Windows
{
    public partial class FrmPrincipal : Form
    {
        private readonly IServiceProvider _serviceProvider;

       
        public FrmPrincipal(IServiceProvider serviceProvider)
        {
           
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMarca_Click(object sender, EventArgs e)
        {
            FrmMarca frm = new FrmMarca(_serviceProvider
               .GetService<IServicioMarca>());
            frm.ShowDialog();
        }

        private void btnDeporte_Click(object sender, EventArgs e)
        {
            FrmDeporte frm = new FrmDeporte(_serviceProvider
              .GetService<IServicioDeporte>());
            frm.ShowDialog();
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            FrmColor frm = new FrmColor(_serviceProvider
              .GetService<IServicioColor>());
            frm.ShowDialog();
        }

        private void btnGenero_Click(object sender, EventArgs e)
        {
            FrmGenero frm = new FrmGenero(_serviceProvider
              .GetService<IServicioGenero>());
            frm.ShowDialog();
        }

        private void BtnZapatilla_Click(object sender, EventArgs e)
        {
            FrmZapatilla frm = new FrmZapatilla(_serviceProvider
              .GetService<IServicioZapatilla>());
            frm.ShowDialog();
        }
    }
}
