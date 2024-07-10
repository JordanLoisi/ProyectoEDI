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
using TrabajoEdi3.Entidades.Dto;
using TrabajoEdi3.Servicios.Interfaces;
using TrabajoEdi3.Windows.Helpers;

namespace TrabajoEdi3.Windows
{
    public partial class FrmZapatillasPorMarca : Form
    {
        private readonly IServicioZapatilla _servicioZapatilla;
        private int pageSize;
        private int pageNum;
        private int recordCount;
        private int pageCount;
        private Marca? MarcaFiltro;
        private List<ZapatillaListDto> ZapatillaListDtos;
        public FrmZapatillasPorMarca(IServicioZapatilla servicioZapatilla)
        {
            InitializeComponent();
            _servicioZapatilla = servicioZapatilla;

        }

        private void FrmZapatillasPorGenero_Load(object sender, EventArgs e)
        {
            if (ZapatillaListDtos != null)
            {
                MostrarDatosEnGRilla();
            }
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
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            // Ir a la siguiente página
            pageNum++;
            if (pageNum > pageCount - 1) { pageNum = pageCount - 1; }
            ActualizarListaPaginada();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            // Ir a la página anterior
            pageNum--;
            if (pageNum < 0) { pageNum = 0; }
            ActualizarListaPaginada();
        }

        private void btnPrimero_Click(object sender, EventArgs e)
        {
            // Ir a la primera página
            pageNum = 0;
            ActualizarListaPaginada();
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            // Ir a la última página
            pageNum = pageCount - 1;
            ActualizarListaPaginada();
        }
        private void ActualizarListaPaginada()
        {
            // Actualizar la lista paginada según la página actual y tamaño de página
            ZapatillaListDtos = _servicioZapatilla
                .GetListaPaginadaOrdenadaFiltrada(pageNum, pageSize, null,null,MarcaFiltro
                , null, null);
            MostrarDatosEnGRilla();
        }

        internal void SetDatosParaElPaginadoYFiltro(int _pageCount, int _pageNum, int _pageSize, int _recordCount, Marca? marca)
        {
            pageCount = _pageCount;
            pageNum = _pageNum;
            pageSize = _pageSize;
            recordCount = _recordCount;
            MarcaFiltro = marca;
        }
        public void SetLista(List<ZapatillaListDto> lista)
        {
            ZapatillaListDtos = lista;
        }

        private void dgvConsulta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
