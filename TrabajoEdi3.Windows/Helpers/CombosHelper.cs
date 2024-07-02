using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoEdi3.Entidades;
using TrabajoEdi3.Servicios.Interfaces;
using TrabajoEdi3.Servicios.Servicios;

namespace TrabajoEdi3.Windows.Helpers
{
    public static class CombosHelper
    {
        public static void CargarCombosPaginas(int pageCount, ref ComboBox cbo)
        {
            cbo.Items.Clear();
            for (int page = 1; page <= pageCount; page++)
            {
                cbo.Items.Add(page.ToString());
            }
            cbo.SelectedIndex = 0;
        }

        //ACA EMPIEZA MARCA
        public static void CargarComboMarca(IServiceProvider serviceProvider, ref ComboBox cbo)
        {
            var servicio = serviceProvider.GetService<IServicioMarca>();

            var lista = servicio.GetLista();
            var defaultMarca = new Marca
            {
                MarcaNombre = "Seleccione"
            };
            lista.Insert(0, defaultMarca);
            cbo.DataSource = lista;
            cbo.DisplayMember = "MarcaNombre";
            cbo.ValueMember = "MarcaId";
            cbo.SelectedIndex = 0;
        }
        public static void CargarComboMarca(IServiceProvider serviceProvider, ref ToolStripComboBox cbo)
        {
            var servicio = serviceProvider.GetService<IServicioMarca>();
            // Obtener la lista de tipos de envases del repositorio

            var lista = servicio.GetLista();
            var defaultMarca = new Marca
            {
                MarcaNombre = "Seleccione"
            };



            // Limpiar el ToolStripComboBox
            cbo.Items.Clear();
            lista.Insert(0, defaultMarca);
            // Agregar los tipos de envases al ToolStripComboBox
            foreach (Marca marca in lista)
            {
                cbo.Items.Add(marca.MarcaNombre);
            }

            // Seleccionar el primer elemento del ToolStripComboBox si hay elementos
            if (lista.Count > 0)
            {
                cbo.SelectedIndex = 0;
            }
        }
        //aca combo Deporte
        public static void CargarComboDeporte(IServiceProvider serviceProvider, ref ComboBox cbo)
        {
            var servicio = serviceProvider.GetService<IServicioDeporte>();

            var lista = servicio.GetLista();
            var defaultDeporte = new Deporte
            {
                NombreDeporte = "Seleccione"
            };
            lista.Insert(0, defaultDeporte);
            cbo.DataSource = lista;
            cbo.DisplayMember = "NombreDeporte";
            cbo.ValueMember = "DeporteId";
            cbo.SelectedIndex = 0;
        }
        public static void CargarComboDeporte(IServiceProvider serviceProvider, ref ToolStripComboBox cbo)
        {
            var servicio = serviceProvider.GetService<IServicioDeporte>();
            // Obtener la lista de tipos de envases del repositorio

            var lista = servicio.GetLista();
            var defaultDeporte = new Deporte
            {
                NombreDeporte = "Seleccione"
            };



            // Limpiar el ToolStripComboBox
            cbo.Items.Clear();
            lista.Insert(0, defaultDeporte);
            // Agregar los tipos de envases al ToolStripComboBox
            foreach (Deporte deporte in lista)
            {
                cbo.Items.Add(deporte.NombreDeporte);
            }

            // Seleccionar el primer elemento del ToolStripComboBox si hay elementos
            if (lista.Count > 0)
            {
                cbo.SelectedIndex = 0;
            }
        }

        //ACA EMPIEZA COMBO GENERO//

        public static void CargarComboGenero(IServiceProvider serviceProvider, ref ComboBox cbo)
        {
            var servicio = serviceProvider.GetService<IServicioGenero>();

            var lista = servicio.GetLista();
            var defaultGenero = new Genero
            {
                GeneroNombre = "Seleccione"
            };
            lista.Insert(0, defaultGenero);
            cbo.DataSource = lista;
            cbo.DisplayMember = "GeneroNombre";
            cbo.ValueMember = "GeneroId";
            cbo.SelectedIndex = 0;
        }
        public static void CargarComboGenero(IServiceProvider serviceProvider, ref ToolStripComboBox cbo)
        {
            var servicio = serviceProvider.GetService<IServicioGenero>();
            // Obtener la lista de tipos de envases del repositorio

            var lista = servicio.GetLista();
            var defaultGenero = new Genero
            {
                GeneroNombre = "Seleccione"
            };



            // Limpiar el ToolStripComboBox
            cbo.Items.Clear();
            lista.Insert(0, defaultGenero);
            // Agregar los tipos de envases al ToolStripComboBox
            foreach (Genero genero in lista)
            {
                cbo.Items.Add(genero.GeneroNombre);
            }

            // Seleccionar el primer elemento del ToolStripComboBox si hay elementos
            if (lista.Count > 0)
            {
                cbo.SelectedIndex = 0;
            }
        }

        //ACA EMPIEZA COLOR /////

        public static void CargarComboColor(IServiceProvider serviceProvider, ref ComboBox cbo)
        {
            var servicio = serviceProvider.GetService<IServicioColor>();

            var lista = servicio.GetLista();
            var defaultColor = new Entidades.Color
            {
                ColorName = "Seleccione"
            };
            lista.Insert(0, defaultColor);
            cbo.DataSource = lista;
            cbo.DisplayMember = "ColorNombre";
            cbo.ValueMember = "ColorId";
            cbo.SelectedIndex = 0;
        }
        public static void CargarComboColor(IServiceProvider serviceProvider, ref ToolStripComboBox cbo)
        {
            var servicio = serviceProvider.GetService<IServicioColor>();
            // Obtener la lista de tipos de envases del repositorio

            var lista = servicio.GetLista();
            var defaultColor = new Entidades.Color
            {
                ColorName = "Seleccione"
            };



            // Limpiar el ToolStripComboBox
            cbo.Items.Clear();
            lista.Insert(0, defaultColor);
            // Agregar los tipos de envases al ToolStripComboBox
            foreach (Entidades.Color color in lista)
            {
                cbo.Items.Add(color.ColorName);
            }

            // Seleccionar el primer elemento del ToolStripComboBox si hay elementos
            if (lista.Count > 0)
            {
                cbo.SelectedIndex = 0;
            }
        }

        public static void CargarComboTalle(IServiceProvider serviceProvider, ref ComboBox cbo)
        {
            var servicio = serviceProvider.GetService<ITallesServicio>();

            var lista = servicio?.GetLista();
            var defaultTalle = new Talles
            {
                
            };
            lista?.Insert(0, defaultTalle);
            cbo.DataSource = lista;
            cbo.DisplayMember = "TallesNUmero";
            cbo.ValueMember = "TalleId";
            cbo.SelectedIndex = 0;
        }
    }
}

