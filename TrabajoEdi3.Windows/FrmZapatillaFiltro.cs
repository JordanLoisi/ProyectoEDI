using Microsoft.Extensions.DependencyInjection;
using System.Drawing;
using TrabajoEdi3.Entidades;
using TrabajoEdi3.Servicios.Interfaces;
using TrabajoEdi3.Servicios.Servicios;
using TrabajoEdi3.Windows.Helpers;

namespace TrabajoEdi3.Windows
{
    public partial class FrmZapatillaFiltro : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ITallesServicio? _ServicioTalles;



        private Marca? MarcaFiltro;
        private Deporte? DeporteFiltro;
        private Entidades.Color? ColorFiltro;
        private Genero? GeneroFiltro;
        private Func<Zapatilla, bool>? filtro;
        private Talles? TalleSelec = null;
        private Talles? TallesMax = null;

        public FrmZapatillaFiltro(IServiceProvider serviceProvider, ITallesServicio tallesServicio)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _ServicioTalles = tallesServicio;

        }
        //protected override void OnLoad(EventArgs e)
        //{
        ////    base.OnLoad(e);
        ////    CombosHelper.CargarComboMarca(_serviceProvider, ref cboMarca);
        ////    CombosHelper.CargarComboDeporte(_serviceProvider, ref cboDeporte);
        ////    CombosHelper.CargarComboColor(_serviceProvider, ref cboColor);
        ////    CombosHelper.CargarComboGenero(_serviceProvider, ref cboGenero);
        //}
        private void FrmZapatillaFiltro_Load(object sender, EventArgs e)
        {
            CombosHelper.CargarComboMarca(_serviceProvider, ref cboMarca);
            CombosHelper.CargarComboDeporte(_serviceProvider, ref cboDeporte);
            CombosHelper.CargarComboColor(_serviceProvider, ref cboColor);
            CombosHelper.CargarComboGenero(_serviceProvider, ref cboGenero);
            CombosHelper.CargarComboTalle(_serviceProvider, ref cboTalle);
            CombosHelper.CargarComboTalle(_serviceProvider, ref cboTalleMaximo);
        }

        private void cboDeporte_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboGenero_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            var _serviceMarca = _serviceProvider?.GetService<IServicioMarca>();
            var _serviceDeporte = _serviceProvider?.GetService<IServicioDeporte>();
            var _serviceGenero = _serviceProvider?.GetService<IServicioGenero>();
            var _serviceColor = _serviceProvider?.GetService<IServicioColor>();

            if (ValidarDatos())
            {
                if (cboMarca.SelectedIndex != 0)
                {
                    MarcaFiltro = _serviceMarca?.GetMarcaPorId(((Marca?)cboMarca.SelectedItem).MarcaId);
                    Func<Zapatilla, bool> Marcafiltro = p => p.Marca == MarcaFiltro;
                    filtro = filtro == null ? Marcafiltro : filtro.And(Marcafiltro);
                }
                if (cboDeporte.SelectedIndex != 0)
                {
                    DeporteFiltro = _serviceDeporte?.GetDeportePorId(((Deporte?)cboDeporte.SelectedItem).DeporteId);
                    Func<Zapatilla, bool> Deportefiltro = p => p.Deporte == DeporteFiltro;
                    filtro = filtro == null ? Deportefiltro : filtro.And(Deportefiltro);
                }
                if (cboGenero.SelectedIndex != 0)
                {
                    GeneroFiltro = _serviceGenero?.GetGeneroPorId(((Genero?)cboGenero.SelectedItem).GeneroId);
                    Func<Zapatilla, bool> generofiltro = p => p.Genero == GeneroFiltro;
                    filtro = filtro == null ? generofiltro : filtro.And(generofiltro);
                }
                if (cboColor.SelectedIndex != 0)
                {
                    ColorFiltro = _serviceColor?.GetColorPorId(((Entidades.Color?)cboColor.SelectedItem).ColorId);
                    Func<Zapatilla, bool> colorfiltro = p => p.Colores == ColorFiltro;
                    filtro = filtro == null ? colorfiltro : filtro.And(colorfiltro);
                }
                if (cboTalle.SelectedIndex != 0 && chekSize.Checked == false)
                {
                    TalleSelec = _ServicioTalles.GetTallesPorId(((Talles?)cboTalle.SelectedItem).TallesId);
                    filtro.And(ss => ss.zapatillastalles.Any(s => s.TallesId == TalleSelec.TallesId));

                }
                if (chekSize.Checked == true)
                {
                    TalleSelec = _ServicioTalles?.GetTallesPorId(((Talles?)cboTalle.SelectedItem).TallesId);
                    TallesMax = _ServicioTalles.GetTallesPorId(((Talles?)cboTalleMaximo.SelectedItem).TallesId);
                    filtro.And(s => s.zapatillastalles.Any(s => s.Talles.TallesNumbero <= TallesMax.TallesNumbero && s.Talles.TallesNumbero >= TalleSelec.TallesNumbero));

                }
                DialogResult = DialogResult.OK;
            }
        }
    


        private bool ValidarDatos()
        {
            errorProvider1.Clear();
            bool valido = true;
            if (cboMarca.SelectedIndex == 0 && cboDeporte.SelectedIndex == 0 && cboColor.SelectedIndex == 0 && cboGenero.SelectedIndex == 0 == false)
            {
                errorProvider1.SetError(cboMarca, "Debe seleccionar aunque sea un filtro");
                valido = false;
            }
            if (chekSize.Checked == true)
            {
                if (cboTalle.SelectedIndex == 0)
                {
                    errorProvider1.SetError(cboTalle, "Debe Selecionar un Talle");
                    valido = false;
                }
                else
                {
                    Talles talles = (Talles?)cboTalle.SelectedItem;
                    Talles m = (Talles)cboTalleMaximo.SelectedItem;
                    if (_ServicioTalles.GetTallesPorId(talles.TallesId)?.TallesNumbero >= _ServicioTalles?.GetTallesPorId(m.TallesId)?.TallesNumbero)
                    {
                        errorProvider1.SetError(cboTalle, "Debe ser menor del talle Maximo");
                        errorProvider1.SetError(cboTalleMaximo, "Debe ser mayor del talle Minimo");
                        valido = false;
                    }
                }
                if (cboTalleMaximo.SelectedIndex == 0)
                {
                    errorProvider1.SetError(cboTalleMaximo, "Debe seleccionar un Size");
                    valido = false;
                }
               
            }
            return valido;
        } 
        public Func<Zapatilla, bool>? GetFiltro()
        {
            return filtro;
        }

        internal Marca? GetFiltroMarca()
        {
            return MarcaFiltro;
        }

        internal Deporte? GetFiltroDeporte()
        {
            return DeporteFiltro;
        }

        internal Genero? GetFiltroGenero()
        {
            return GeneroFiltro;
        }

        internal Entidades.Color? GetFiltroColor()
        {
            return ColorFiltro;
        }

        private void chekSize_CheckedChanged(object sender, EventArgs e)
        {
            if (chekSize.Checked == false)
            {
                cboTalleMaximo.Enabled = false;
            }
            else
            {
                cboTalleMaximo.Enabled = true;
            }
        }

        internal Talles? GetTalleSeleccionado()
        {
            return TalleSelec;
        }

        internal Talles? GetTalleMax()
        {
            return TallesMax;
        }
    }
}

    

