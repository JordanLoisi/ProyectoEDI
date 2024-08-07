﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.DependencyInjection;
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
        private Talles? TalleSelec = null;
        private Talles? TalleMax = null;

        
        private Func<Zapatilla, bool>? filtro = null;

         Orden ordenado = Orden.SinOrden;

        private int cantidadPaginas;
        private int pageSize = 8;
        private int pageNum = 0;
        private int cantidadRegistros;
        public FrmZapatilla(IServicioZapatilla servicio, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _servicio = servicio;
            _serviceProvider = serviceProvider;
        }

        private void FrmZapatilla_Load(object sender, EventArgs e)
        {
            
            RecargarGrillDeTodasLasZapatilla();
        }

        private void RecargarGrillDeTodasLasZapatilla()
        {
            try
            {
                cantidadRegistros = _servicio.GetCantidad();
                cantidadPaginas = FromHelper.CalcularPaginas(cantidadRegistros, pageSize);
                lista = _servicio.GetListaPaginadaOrdenadaFiltrada(pageNum, pageSize, orden, DeporteFiltro, MarcaFiltro, ColorFiltro, GeneroFiltro,TalleSelec,TalleMax);
                CantidadPaginasLbl.Text = cantidadPaginas.ToString();

                PaginaActualLbl.Text = (pageNum + 1).ToString();

                CantidadZapatillasLbl.Text = cantidadRegistros.ToString();




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



        private void tsbNuevo_Click(object sender, EventArgs e)
        {

            FrmZapatillaAE frm = new FrmZapatillaAE(_serviceProvider);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            try
            {
                Zapatilla? zapatilla = frm.GetZapatilla();

                if (zapatilla is not null)
                {
                    if (!_servicio.Existe(zapatilla))
                    {
                        _servicio.GuardarZapas(zapatilla);
                        AgregarTalles(zapatilla);
                       DialogResult dr2= MessageBox.Show("Desea agregar más talles?","Pregunta",MessageBoxButtons.YesNo, MessageBoxIcon.Question,MessageBoxDefaultButton.Button2);
                        if (dr2 == DialogResult.Yes)
                        {
                            FrmCantidadDeseada frm3 = new FrmCantidadDeseada();
                                 DialogResult dr3 =frm3.ShowDialog(this);
                            for (int i = 0; i < frm3.GetCantidad(); i++)
                            {
                                AgregarTalles(zapatilla);
                            }
                        }
                        else
                        {
                            return;
                        }
                        MessageBox.Show("Agregado Satisfactoriamente");

                        

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

            }

        }
        private void AgregarTalles(Zapatilla zapatilla)
        {

            MessageBox.Show("Selleccione un talle para la zapatilla y su stock ");
            FrmAgregarTalles frm2 = new FrmAgregarTalles(_serviceProvider, 0, null);
            DialogResult dr2 = frm2.ShowDialog(this);
            if (dr2 == DialogResult.Cancel) { return; }
            try
            {
                Talles? talles = frm2.GetTalles();
                int Stock = frm2.GetStock();
                if (talles is null) return;
                if (!_servicio.ExisteRelacion(zapatilla, talles))
                {
                    _servicio.AsignarTalleAZapatilla(zapatilla, talles, Stock);
                    RecargarGrillDeTodasLasZapatilla();
                    MessageBox.Show("Registro Agregado Satisfactoriamente!!!",
                        "Mensaje",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);


                }

                else
                {
                    MessageBox.Show("Registro Duplicado",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                }
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

            }
        }


        private void tstBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            ZapatillaListDto zapatillaListDto = (ZapatillaListDto)r.Tag;
            DialogResult dr = MessageBox.Show($"¿Desea dar de baja a {zapatillaListDto.Description}?",
                "Confirmar Operación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No)
            {
                return;
            }
            try
            {
                Zapatilla zapatilla = _servicio.GetZapatillaPorId(zapatillaListDto.ZapatillaId);

                if (!_servicio.EstaRelacionado(zapatilla))
                {
                    _servicio.Borrar(zapatilla.ZapatillaId);

                    GridHelper.QuitarFila(r, dgvDatos);
                    MessageBox.Show("Registro Borrado Satisfactoriamente!!!",
                        "Mensaje",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);


                }
                else
                {
                    MessageBox.Show("Registro Relacionado...Baja denegada!!!",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

            }
        }

        private void tstEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0) { return; }
            var r = dgvDatos.SelectedRows[0];
            if (r.Tag is null) return;
            ZapatillaListDto zapatillaList = (ZapatillaListDto)r.Tag;
            Zapatilla? zapatilla = _servicio.GetZapatillaPorId(zapatillaList.ZapatillaId);
            if (zapatilla == null) return;
            FrmZapatillaAE frm = new FrmZapatillaAE(_serviceProvider)
            { Text = "Editar Zapatilla" };
            List<ZapatillasTalles>? talles = _servicio
                .GetTallesPorZapatilla(zapatilla.ZapatillaId);
           /* (*//*Z*//*apatilla? zapatilla, List<Talles>? talles) p = (zapatilla, talles);*/
            frm.SetZapatilla(zapatilla);
            DialogResult dr = frm.ShowDialog(this);
            try
            {
                //p= frm.GetZapatillaTalles();
                var zapatillaEditada = frm.GetZapatilla();
                //if (p.zapatilla is null) return;
                if (!_servicio.Existe(zapatillaEditada))
                {

                    _servicio.GuardarZapas(zapatillaEditada);
                    RecargarGrillDeTodasLasZapatilla();

                }
                else
                {
                    MessageBox.Show("Zapatilla existente!!!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            MarcaFiltro = null;
            DeporteFiltro = null;
            GeneroFiltro = null;
            ColorFiltro = null;
            filtro = null;
            TalleSelec = null;
            TalleMax = null;
            RecargarGrillDeTodasLasZapatilla();
            tsbFiltrar.BackColor = SystemColors.Control;

        }

        private void tsbFiltrar_Click(object sender, EventArgs e)
        {
            var talleservicio = _serviceProvider.GetService<ITallesServicio>();
            FrmZapatillaFiltro frm = new FrmZapatillaFiltro(_serviceProvider, talleservicio);
            frm.ShowDialog(this);
            filtro = frm.GetFiltro();
            MarcaFiltro = frm.GetFiltroMarca();
            DeporteFiltro = frm.GetFiltroDeporte();
            GeneroFiltro = frm.GetFiltroGenero();
            ColorFiltro = frm.GetFiltroColor();

            TalleSelec = frm.GetTalleSeleccionado();
            TalleMax = frm.GetTalleMax();
        
   
            RecargarGrillDeTodasLasZapatilla();
        }

        private void tsbOrden_Click(object sender, EventArgs e)
        {

        }

        private void tsbTalle_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            if (r.Tag is null) return;
            ZapatillaListDto zapatillaDto = (ZapatillaListDto)r.Tag;
            List<ZapatillasTalles>? talles = _servicio
                .GetTallesPorZapatilla(zapatillaDto.ZapatillaId);
            if (talles is null || talles.Count == 0)
            {
                MessageBox.Show("Zapatilla sin talle asignados",
                    "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            FrmDetalleTalles frm = new FrmDetalleTalles(_serviceProvider)
            { Text = $"Talles de la zapatilla {zapatillaDto.Description}" };
            frm.SetDatos(talles);
            frm.ShowDialog(this);
        }

        private void tsbAsignarTalle_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            if (r.Tag is null) return;
            var zapatillaDto = (ZapatillaListDto)r.Tag;

            Zapatilla? zapatilla = _servicio.GetZapatillaPorId(zapatillaDto?.ZapatillaId ?? 0);
            if (zapatilla is null) return;
            AgregarTalles(zapatilla);
        }

        private void btnPrimero_Click(object sender, EventArgs e)
        {
            pageNum = 0;
            PaginaActualLbl.Text = (pageNum + 1).ToString();
            RecargarGrillDeTodasLasZapatilla();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            pageNum--;
            if (pageNum < 0) { pageNum = 0; }
            PaginaActualLbl.Text = (pageNum + 1).ToString();
            RecargarGrillDeTodasLasZapatilla();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            pageNum++;
            if (pageNum > cantidadPaginas - 1) { pageNum = cantidadPaginas - 1; }
            PaginaActualLbl.Text = (pageNum + 1).ToString();

            RecargarGrillDeTodasLasZapatilla();
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            pageNum = cantidadPaginas - 1;
            PaginaActualLbl.Text = (pageNum + 1).ToString();

            RecargarGrillDeTodasLasZapatilla();
        }
    }


}


       
