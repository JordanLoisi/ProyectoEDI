using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrabajoEdi3.Entidades;
using TrabajoEdi3.Windows.Helpers;

namespace TrabajoEdi3.Windows
{
    public partial class FrmZapatillaAE : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private Zapatilla? zapatilla;
        private Deporte? deporte;
        private Marca? marca;
        private Entidades.Color? color;
        private Genero? genero;

        private (Zapatilla? zapatilla, List<Talles> talles) p;
        public FrmZapatillaAE(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }

        private void FrmZapatillaAE_Load(object sender, EventArgs e)
        {

        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CombosHelper.CargarComboMarca(_serviceProvider, ref cboMarca);
            CombosHelper.CargarComboDeporte(_serviceProvider, ref cboDeporte);
            CombosHelper.CargarComboColor(_serviceProvider, ref cboColor);
            CombosHelper.CargarComboGenero(_serviceProvider, ref cboGenero);
            ListBoxHelpers.CargarDatosListBoxTalles(_serviceProvider, ref clstTalles);
            if (zapatilla != null)
            {
                txtZapatilla.Text = zapatilla.Description;
                txtPrecio.Text = zapatilla.Precio.ToString();
                txtModelo.Text = zapatilla.Modelo.ToString();
                cboMarca.SelectedValue = marca.MarcaId;
                cboDeporte.SelectedValue = deporte.DeporteId;
                cboColor.SelectedValue = color.ColorId;
                cboGenero.SelectedValue = genero.GeneroId;
                deporte = zapatilla.Deporte;
                marca = zapatilla.Marca;
                color = zapatilla.Colores;
                genero = zapatilla.Genero;
            }
            if (p.talles != null && p.talles.Any())
            {
                // Recorre todos los ítems del CheckedListBox
                for (int i = 0; i < clstTalles.Items.Count; i++)
                {
                    // Obtén el proveedor actual del CheckedListBox
                    var itemTalles = clstTalles.Items[i] as Talles;

                    if (itemTalles != null)
                    {
                        // Verifica si el proveedor actual está en la lista de proveedores
                        if (p.talles
                            .Any(p => p.TallesId == itemTalles.TallesId))
                        {
                            // Selecciona el ítem si el proveedor está en la lista
                            clstTalles.SetItemChecked(i, true);
                        }
                        else
                        {
                            // Desmarca el ítem si el proveedor no está en la lista
                            clstTalles.SetItemChecked(i, false);
                        }
                    }
                }
            }
        }

        public (Zapatilla?, List<Talles>?) GetZapatillaTalles()
        {
            return p;
        }
        public Zapatilla GetZapatilla()
        {
            return zapatilla;
        }
        internal void SetZapatilla(Zapatilla? zapatilla)
        {
            this.zapatilla = zapatilla;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (zapatilla == null)
                {
                    zapatilla = new Zapatilla();
                }
                zapatilla.Description = txtZapatilla.Text;
                zapatilla.Modelo = txtModelo.Text;
                zapatilla.Precio = decimal.Parse(txtPrecio.Text);

                zapatilla.Marca = marca;
                zapatilla.Deporte = deporte;
                zapatilla.Colores = color;
                zapatilla.Genero = genero;

                zapatilla.MarcaId = marca.MarcaId;
                zapatilla.DeporteId = deporte.DeporteId;
                zapatilla.ColoresId = color.ColorId;
                zapatilla.GeneroId = genero.GeneroId;

                if (clstTalles.CheckedItems.Count > 0)
                {
                    p.talles = new List<Talles>();
                    //Se itera sobre los talles seleccionados
                    foreach (var item in clstTalles.CheckedItems)
                    {
                        //Se almacenan los proveedores seleccionados

                        p.talles.Add((Talles)item);

                    }
                }
                DialogResult = DialogResult.OK;
            }
        }


        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtZapatilla.Text) ||
                string.IsNullOrWhiteSpace(txtZapatilla.Text))
            {
                valido = false;
                errorProvider1.SetError(txtZapatilla, "Nombre de zapatilla requerido");
            }
            if (string.IsNullOrEmpty(txtModelo.Text) ||
               string.IsNullOrWhiteSpace(txtModelo.Text))
            {
                valido = false;
                errorProvider1.SetError(txtModelo, "Modelo de zapatilla requerido");
            }

            if (!decimal.TryParse(txtPrecio.Text, out decimal pCosto) ||
                (pCosto <= 0))
            {
                valido = false;
                errorProvider1.SetError(txtPrecio, "Precio no válido o mal ingresado");

            }

            if (cboMarca.SelectedIndex == 0 && marca == null)
            {
                valido = false;
                errorProvider1.SetError(cboMarca, "Debe seleccionar una Marca");

            }
            if (cboDeporte.SelectedIndex == 0 && deporte == null)
            {
                valido = false;
                errorProvider1.SetError(cboDeporte, "Debe seleccionar un Deporte");

            }
            if (cboColor.SelectedIndex == 0 && color == null)
            {
                valido = false;
                errorProvider1.SetError(cboColor, "Debe seleccionar un Color");

            }
            if (cboGenero.SelectedIndex == 0 && genero == null)
            {
                valido = false;
                errorProvider1.SetError(cboGenero, "Debe seleccionar un Genero");

            }

            return valido;
        }

        private void btnDeporte_Click(object sender, EventArgs e)
        {
            FrmDeporteAE frm = new FrmDeporteAE();
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) { return; }
            deporte = frm.GetDeporte();

            cboDeporte.Enabled = false;
            lblNuevoDeporte.Visible = true;
        }

        private void btnAgregarColor_Click(object sender, EventArgs e)
        {
            FrmColorAE frm = new FrmColorAE();
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) { return; }
            color = frm.GetColor();

            cboColor.Enabled = false;
            lblNuevoColor.Visible = true;
        }

        private void btnAgregarGenero_Click(object sender, EventArgs e)
        {
            FrmGeneroAE frm = new FrmGeneroAE();
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) { return; }
            genero = frm.GetGenero();

            cboGenero.Enabled = false;
            lblNuevoGenero.Visible = true;
        }

        private void btnAgregarMarca_Click(object sender, EventArgs e)
        {
            FrmMarcaAE frm = new FrmMarcaAE();
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) { return; }
            marca = frm.GetMarca();

            cboMarca.Enabled = false;
            lblNuevaMarca.Visible = true;
        }

        private void cboDeporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDeporte.SelectedIndex > 0)
            {
                deporte = (Deporte)cboDeporte.SelectedItem;
            }
            else
            {
                deporte = null;
            }
        }

        private void cboColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboColor.SelectedIndex > 0)
            {
                color = (Entidades.Color)cboColor.SelectedItem;
            }
            else
            {
                color = null;
            }
        }

        private void cboGenero_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboGenero.SelectedIndex > 0)
            {
                genero = (Genero)cboGenero.SelectedItem;
            }
            else
            {
                genero = null;
            }
        }

        private void cboMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMarca.SelectedIndex > 0)
            {
                marca = (Marca)cboMarca.SelectedItem;
            }
            else
            {
                marca = null;
            }
        }

        public void SetZapatillaTalles((Zapatilla? zapatilla, List<Talles>? talles) p)
        {
            this.p = p;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
        
    

