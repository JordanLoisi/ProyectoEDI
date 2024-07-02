using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrabajoEdi3.Entidades;
using TrabajoEdi3.Entidades.Dto;
using TrabajoEdi3.Entidades.Enums;
using TrabajoEdi3.Servicios.Interfaces;
using TrabajoEdi3.Windows.Helpers;

namespace TrabajoEdi3.Windows
{
    public partial class FrmZapatilla : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IServicioZapatilla _servicio;
        private List<ZapatillaListDto>? lista;
        private Orden orden = Orden.SinOrden;
        private Marca? MarcaFiltro = null;
        private Deporte? DeporteFiltro = null;
        private Entidades.Color? ColorFiltro = null;
        private Genero? GeneroFiltro = null;

        private bool FilterOn = false;

        private int pageCount;
        private int pageSize = 15;
        private int pageNum = 0;
        private int recordCount;
        public FrmZapatilla(IServicioZapatilla servicio)
        {
            InitializeComponent();
            _servicio = servicio;
        }

        private void FrmZapatilla_Load(object sender, EventArgs e)
        {
            CombosHelper.CargarComboColor(_serviceProvider, ref porColorToolStripMenuItem);
            CombosHelper.CargarComboDeporte(_serviceProvider, ref porDeporteStripMenuItem);
            CombosHelper.CargarComboMarca(_serviceProvider, ref porMarcaStripMenuItem);
            CombosHelper.CargarComboGenero(_serviceProvider, ref porGeneroToolStripMenuItem);
            RecargarGrillDeTodasLasZapatilla();
        }

        private void RecargarGrillDeTodasLasZapatilla()
        {
            try
            {
                recordCount = _servicio.GetCantidad();
                pageCount = FromHelper.CalcularPaginas(recordCount, pageSize);
                txtCantidadRegistros.Text = pageCount.ToString();
                CombosHelper.CargarCombosPaginas(pageCount, ref cboPaginas);

                // Obtener la lista paginada ordenada y filtrada por defecto (sin orden ni filtro)
                lista = _servicio.GetListaPaginadaOrdenadaFiltrada(pageNum, pageSize, orden, DeporteFiltro, MarcaFiltro, ColorFiltro, GeneroFiltro);
                MostrarDatosEnGrilla();
            }
            catch (Exception)
            {
                throw;

            }
        }

        private void MostrarDatosEnGrilla()
        {
            GridHelper.LimpiarGrilla(dgvDatos);
            if (lista is not null)
            {
                foreach (var item in lista)
                {
                    DataGridViewRow r = GridHelper.ConstruirFila(dgvDatos);
                    GridHelper.SetearFila(r, item);
                    GridHelper.AgregarFila(r, dgvDatos);
                }
            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void aZToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Ordenar de forma ascendente (A-Z)
            MostrarOrdenado(Orden.AZ);
        }

        private void MostrarOrdenado(Orden orden)
        {
            // Mostrar la lista ordenada según el criterio seleccionado
            lista = _servicio.GetListaPaginadaOrdenadaFiltrada(pageNum, pageSize, orden);
            MostrarDatosEnGrilla();
        }

        private void zAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Ordenar de forma descendente (Z-A)
            MostrarOrdenado(Orden.ZA);
        }

        private void menorPrecioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Ordenar por menor precio
            MostrarOrdenado(Orden.MenorPrecio);
        }

        private void mayorPrecioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Ordenar por mayor precio
            MostrarOrdenado(Orden.MayorPrecio);
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            // Ir a la siguiente página
            pageNum++;
            if (pageNum > pageCount - 1) { pageNum = pageCount - 1; }
            cboPaginas.SelectedIndex = pageNum;
            ActualizarListaPaginada();
        }

        private void ActualizarListaPaginada()
        {
            // Actualizar la lista paginada según la página actual y tamaño de página
            lista = _servicio.GetListaPaginadaOrdenadaFiltrada(pageNum, pageSize, orden,
                 DeporteFiltro, MarcaFiltro, ColorFiltro, GeneroFiltro);
            MostrarDatosEnGrilla();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            // Ir a la página anterior
            pageNum--;
            if (pageNum < 0) { pageNum = 0; }
            cboPaginas.SelectedIndex = pageNum;
            ActualizarListaPaginada();
        }

        private void btnPrimero_Click(object sender, EventArgs e)
        {
            // Ir a la primera página
            pageNum = 0;
            cboPaginas.SelectedIndex = pageNum;
            ActualizarListaPaginada();
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            // Ir a la última página
            pageNum = pageCount - 1;
            cboPaginas.SelectedIndex = pageNum;
            ActualizarListaPaginada();
        }

        private void cboPaginas_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Cambiar a la página seleccionada
            pageNum = cboPaginas.SelectedIndex;
            ActualizarListaPaginada();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {

            FrmZapatillaAE frm = new FrmZapatillaAE(_serviceProvider);
            DialogResult df = frm.ShowDialog(this);
            if (df == DialogResult.Cancel) { return; }
            try
            {
                (Zapatilla? zapatilla, List<Talles>? talles) p = frm
                    .GetZapatillaTalles();
                if (p.zapatilla is null) return;
                if (!_servicio.Existe(p.zapatilla))
                {
                    _servicio.Guardar(p.zapatilla, p.talles);
                    // Actualizar la lista después de agregar la planta
                    ActualizarListaDespuesAgregar(p.zapatilla);
                    MessageBox.Show("zapatilla agregada!!!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("zapatilla existente!!!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void ActualizarListaDespuesAgregar(Zapatilla zapatillaAgregada)
        {
            // Obtener la página actual y actualizar la lista
            int paginaActual = pageNum;
            lista = _servicio.GetListaPaginadaOrdenadaFiltrada(paginaActual, pageSize);

            // Mostrar la lista actualizada en la grilla
            MostrarDatosEnGrilla();

            // Verificar si la Zapatilla agregada está en la página actual

            bool ZapatillaAgregadaEnPaginaActual = lista
                .Any(p => p.ZapatillaId == zapatillaAgregada.ZapatillaId);

            if (!ZapatillaAgregadaEnPaginaActual)
            {
                // Si la Zapatilla agregada no está en la página actual,
                // seleccionar la última página y actualizar la lista
                pageNum = pageCount - 1;
                cboPaginas.SelectedIndex = pageNum;
                lista = _servicio.GetListaPaginadaOrdenadaFiltrada(pageNum, pageSize);
                MostrarDatosEnGrilla();
            }
        }

        private void tstBorrar_Click(object sender, EventArgs e)
        {

        }

        private void tstEditar_Click(object sender, EventArgs e)
        {
            //if (dgvDatos.SelectedRows.Count == 0) { return; }
            //var r = dgvDatos.SelectedRows[0];
            //if (r.Tag is null) return;
            //ZapatillaListDto zapatillaList = (ZapatillaListDto)r.Tag;
            //Zapatilla? zapatilla = _servicio.GetZapatillaPorId(zapatillaList.ZapatillaId);
            //if (zapatilla == null) return;
            //List<Talles>? talles = _servicio
            //    .GetTallesPorZapatilla(zapatilla.ZapatillaId);
            //(Zapatilla? zapatilla, List<Talles>? talles) p = (zapatilla, talles);
            //FrmZapatillaAE frm = new FrmZapatillaAE(_serviceProvider)
            //{ Text = "Editar Zapatilla" };
            //frm.SetZapatillaTalles(p);
            //DialogResult dr = frm.ShowDialog(this);
            //try
            //{
            //    p = frm.GetZapatillaTalles();
            //    if (p.zapatilla is null) return;
            //    if (!_servicio.Existe(p.zapatilla))
            //    {
            //        _servicio.Guardar(p.zapatilla, p.talles);
            //        ActualizarListaDespuesAgregar(zapatilla);

            //    }
            //    else
            //    {
            //        MessageBox.Show("Planta existente!!!", "Error",
            //            MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }

            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show(ex.Message, "Error",
            //            MessageBoxButtons.OK, MessageBoxIcon.Error);

            //}
        }

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            FilterOn = false;
            RecargarGrillDeTodasLasZapatilla();
            //tsbFiltrar.Image = Resources.filter_40px;
            tsbFiltrar.BackColor = SystemColors.Control;
        }

        private void tsbFiltrar_Click(object sender, EventArgs e)
        {

        }

        private void tsbOrden_Click(object sender, EventArgs e)
        {

        }

        private void tsbTalle_Click(object sender, EventArgs e)
        {
            //if (dgvDatos.SelectedRows.Count == 0)
            //{
            //    return;
            //}
            //var r = dgvDatos.SelectedRows[0];
            //if (r.Tag is null) return;
            //ZapatillaListDto zapatillaDto = (ZapatillaListDto)r.Tag;
            //List<Talles>? talles = _servicio
            //    .GetTallesPorZapatilla(zapatillaDto.ZapatillaId);
            //if (talles is null || talles.Count == 0)
            //{
            //    MessageBox.Show("Zapatilla sin talle asignados",
            //        "Advertencia",
            //        MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;00
            //}
            //FrmDetalleTalles frm = new FrmDetalleTalles()
            //{ Text = $"Talles de la zapatilla {zapatillaDto.Description}" };
            //frm.SetDatos(talles);
            //frm.ShowDialog(this);
        }

        private void tsbAsignarTalle_Click(object sender, EventArgs e)
        {
            //if (dgvDatos.SelectedRows.Count == 0)
            //{
            //    return;
            //}
            //var r = dgvDatos.SelectedRows[0];
            //if (r.Tag is null) return;
            //var zapatillaDto = (ZapatillaListDto)r.Tag;

            //Zapatilla? zapatilla = _servicio.GetZapatillaPorId(zapatillaDto?.ZapatillaId ?? 0);
            //if (zapatilla is null) return;
            //FrmAgregarTalles frm = new FrmAgregarTalles(_serviceProvider) { Text = "Agregar Talles" };
            //DialogResult dr = frm.ShowDialog(this);
            //if (dr == DialogResult.Cancel) { return; }
            //try
            //{
            //    Talles? talles = frm.GetTalles();
            //    if (talles is null) return;
            //    if (!_servicio.ExisteRelacion(zapatilla, talles))
            //    {
            //        _servicio.AsignarTalleAZapatilla(zapatilla, talles);
            //        if (zapatillaDto is not null)
            //        {
            //            zapatillaDto.CantidadTalles++;
            //            GridHelper.SetearFila(r, zapatillaDto);
            //        }
            //        MessageBox.Show("Talle asignado a la Zapatilla!!!",
            //            "Mensaje",
            //            MessageBoxButtons.OK, MessageBoxIcon.Information);


            //    }
            //    else
            //    {
            //        MessageBox.Show("Asignación Existente!!!",
            //        "Error",
            //        MessageBoxButtons.OK, MessageBoxIcon.Error);

            //    }

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message,
            //                "Error",
            //                MessageBoxButtons.OK, MessageBoxIcon.Error);

            //}
        }
    }


}


       
