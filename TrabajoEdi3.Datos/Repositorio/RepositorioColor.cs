﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoEdi3.Datos.Intefaces;
using TrabajoEdi3.Entidades;

namespace TrabajoEdi3.Datos.Repositorio
{
    public class RepositorioColor : RepositorioGenerico<Entidades.Color>, IColorRepositorio
    {
        private readonly DbContex _Context;

        public RepositorioColor(DbContex Context): base(Context)
        {
            _Context = Context;
        }

        public void Agregar(Entidades.Color coloor)
        {
            _Context.colors.Add(coloor);
        }

        public void Borrar(Entidades.Color coloor)
        {
            _Context.colors.Remove(coloor);
        }

        public void Editar(Entidades.Color coloor)
        {
            _Context.colors.Update(coloor);
        }

        public bool EstaRelacionado(int id)
        {
            return _Context
                .zapatillas
                .Any(p => p.ColoresId == id);
        }

        public bool Existe(Entidades.Color coloor)
        {
            if (coloor.ColorId == 0)
            {
                return _Context.colors
                    .Any(te => te.ColorName == coloor.ColorName);
            }
            return _Context.colors
                .Any(te => te.ColorName == coloor.ColorName &&
                te.ColorId != coloor.ColorId);
        }

        public int GetCantidad()
        {
            return _Context.colors.Count();
        }

        public Entidades.Color? GetColorPorId(int idEditar)
        {
            return _Context.colors
               .SingleOrDefault(te => te.ColorId == idEditar);
        }

        public Entidades.Color? GetColorPorNombre(string nombreColor)
        {
            return _Context.colors
                .FirstOrDefault(te => te.ColorName == nombreColor);
        }

        public List<Entidades.Color> GetLista()
        {
            return _Context.colors
               .OrderBy(te => te.ColorId)
               .AsNoTracking()
               .ToList();
        }
   
    }
}
