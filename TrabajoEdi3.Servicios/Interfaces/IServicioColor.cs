﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoEdi3.Entidades;


namespace TrabajoEdi3.Servicios.Interfaces
{
    public interface IServicioColor
    {
        int GetCantidad();
        List<Entidades.Color> GetLista();
        void Guardar(Entidades.Color color);
        void Borrar(Entidades.Color color);
        bool Existe(Entidades.Color color);
        Entidades.Color? GetColorPorId(int idEditar);
        Entidades.Color? GetColorPorNombre(string ColorName);
        bool EstaRelacionado(Entidades.Color color);

    }
}
