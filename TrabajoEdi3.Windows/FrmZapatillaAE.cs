using TrabajoEdi3.Entidades;
using TrabajoEdi3.Servicios.Interfaces;
using TrabajoEdi3.Windows.Helpers;

namespace TrabajoEdi3.Windows
{
    public partial class FrmZapatillaAE : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IServicioZapatilla servicioZapatilla;
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
        private bool EsEdition = false;


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

            if (zapatilla != null)
            {
                txtZapatilla.Text = zapatilla.Description;
                txtPrecio.Text = zapatilla.Precio.ToString();
                txtModelo.Text = zapatilla.Modelo.ToString();
                cboMarca.SelectedValue = zapatilla.MarcaId;
                cboDeporte.SelectedValue = zapatilla.DeporteId;
                cboColor.SelectedValue = zapatilla.ColoresId;
                cboGenero.SelectedValue = zapatilla.GeneroId;
                deporte = zapatilla.Deporte;
                marca = zapatilla.Marca;
                color = zapatilla.Colores;
                genero = zapatilla.Genero;


                EsEdition = true;
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

                try
                {



                    if (!EsEdition)
                    {
                        
                        InicializarControles();
                    }
                    else
                    {
                        MessageBox.Show("Registro editado exitosamente", "Mensaje",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.OK;
                    }
                }




                catch (Exception)
                {

                    throw;
                }

                DialogResult = DialogResult.OK;
            }
        }

        private void InicializarControles()
        {
            txtZapatilla.Focus();
            txtPrecio.Clear();
            txtModelo.Clear();
            cboDeporte.SelectedIndex = 0;
            cboColor.SelectedIndex = 0;
            cboGenero.SelectedIndex = 0;
            cboMarca.SelectedIndex = 0;

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

        //public void SetZapatillaTalles((Zapatilla? zapatilla, List<Talles>? talles) p)
        //{
        //    this.p = p;
        //}

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }
    }
}



