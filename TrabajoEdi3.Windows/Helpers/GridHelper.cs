using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TrabajoEdi3.Entidades;
using TrabajoEdi3.Entidades.Dto;

namespace TrabajoEdi3.Windows.Helpers
{
    public static class GridHelper
    {
        public static void LimpiarGrilla(DataGridView dgv)
        {
            dgv.Rows.Clear();
        }

        public static DataGridViewRow ConstruirFila(DataGridView dgv)
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgv);
            return r;

        }

        public static void QuitarFila(DataGridViewRow r, DataGridView dgv)
        {
            dgv.Rows.Remove(r);
        }
        public static void SetearFila(DataGridViewRow r, object item)
        {
            switch (item)
            {
                case Marca marca:
                    r.Cells[0].Value = marca.MarcaNombre;
                    break;
                case Deporte deporte:
                    r.Cells[0].Value = deporte.NombreDeporte;
                    break;
                case Entidades.Color color:
                    r.Cells[0].Value = color.ColorName;
                    break;
                case Genero genero:
                    r.Cells[0].Value = genero.GeneroNombre;
                    break;
                case Talles talles:
                    r.Cells[0].Value = talles.TallesNumbero.ToString();
                    break;

                case ZapatillaListDto zapatilla:
                    r.Cells[0].Value = zapatilla.Description;
                    r.Cells[1].Value = zapatilla.Modelo;
                    r.Cells[2].Value = zapatilla.Deporte;
                    r.Cells[3].Value = zapatilla.Precio.ToString("C");
                    r.Cells[4].Value = zapatilla.Colores;
                    r.Cells[5].Value = zapatilla.Genero;

                    break;
                case Zapatilla zapatilla:
                    r.Cells[0].Value = zapatilla.Modelo;
                    r.Cells[1].Value = zapatilla.Marca.MarcaNombre;
                    r.Cells[2].Value = zapatilla.Deporte.NombreDeporte;
                    r.Cells[3].Value = zapatilla.Colores.ColorName;
                    r.Cells[4].Value = zapatilla.Genero.GeneroNombre;
                    r.Cells[5].Value = zapatilla.Precio.ToString("C");
                    break;


                default:
                    break;

            }
            r.Tag = item;
        }

        public static void AgregarFila(DataGridViewRow r, DataGridView dgv)
        {
            dgv.Rows.Add(r);
        }

        public static void MostrarDatosEnGrilla<T>(List<T> lista, DataGridView dgvDatos) where T: class
        {
            LimpiarGrilla(dgvDatos);
            foreach (T t in lista)
            {
                var r = ConstruirFila(dgvDatos);
                SetearFila(r, t);
                AgregarFila(r, dgvDatos);
            }
        }
    }
}
