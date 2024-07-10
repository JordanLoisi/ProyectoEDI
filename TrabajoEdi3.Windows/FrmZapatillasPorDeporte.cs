using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrabajoEdi3.Entidades.Dto;
using TrabajoEdi3.Entidades;
using TrabajoEdi3.Servicios.Interfaces;
using TrabajoEdi3.Windows.Helpers;

namespace TrabajoEdi3.Windows
{
    public partial class FrmZapatillasPorDeporte : Form
    {
        private readonly IServicioZapatilla _servicioZapatilla;
        private int pageSize;
        private int pageNum;
        private int recordCount;
        private int pageCount;
        private Deporte? DeporteFiltro;
        private List<ZapatillaListDto> ZapatillaListDtos;
        public FrmZapatillasPorDeporte(IServicioZapatilla servicioZapatilla)
        {
            InitializeComponent();
            _servicioZapatilla = servicioZapatilla;
        }
      
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

        }
        private void MostrarDatosEnGRilla()
        {
            GridHelper.LimpiarGrilla(dgvConsulta);
            foreach (var item in ZapatillaListDtos)
            {
                var r = GridHelper.ConstruirFila(dgvConsulta);
                GridHelper.SetearFila(r, item);
                GridHelper.AgregarFila(r, dgvConsulta);
            }
        }
        public void SetLista(List<ZapatillaListDto> lista)
        {
            ZapatillaListDtos = lista;
        }
        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPrimero_Click(object sender, EventArgs e)
        {
            pageNum = 0;
            ActualizarListaPaginada();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            pageNum--;
            if (pageNum < 0) { pageNum = 0; }
            ActualizarListaPaginada();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            pageNum++;
            if (pageNum > pageCount - 1) { pageNum = pageCount - 1; }
            ActualizarListaPaginada();
        }

        private void ActualizarListaPaginada()
        {
            ZapatillaListDtos = _servicioZapatilla
                .GetListaPaginadaOrdenadaFiltrada
                (pageNum, pageSize, null, DeporteFiltro, null, null, null);
            MostrarDatosEnGRilla();
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            pageNum = pageCount - 1;
            ActualizarListaPaginada();
        }
        public void SetDatosParaElPaginadoYFiltro(int _pageCount, int _pageNum, int _pageSize, int _recordCount, Deporte? deportes)
        {
            pageCount = _pageCount;
            pageNum = _pageNum;
            pageSize = _pageSize;
            recordCount = _recordCount;
            DeporteFiltro = deportes;
        }

        private void FrmZapatillasPorDeporte_Load_1(object sender, EventArgs e)
        {
            if (ZapatillaListDtos != null)
            {
                MostrarDatosEnGRilla();
            }
        }
    }
}
