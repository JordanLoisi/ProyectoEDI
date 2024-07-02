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
    public partial class FrmDetalleTalles : Form
    {
        private List<Talles> talle;
        public FrmDetalleTalles()
        {
            InitializeComponent();
        }

        public void SetDatos(List<Talles> talles)
        {
            this.talle = talles;
        }
        
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        if (talle != null)
        {
            GridHelper.MostrarDatosEnGrilla(talle, dgvDatos);
        }
    }

    private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FrmDetalleTalles_Load(object sender, EventArgs e)
        {

        }
    }
}
