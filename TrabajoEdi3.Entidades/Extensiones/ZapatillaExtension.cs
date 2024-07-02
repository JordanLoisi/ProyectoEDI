using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TrabajoEdi3.Entidades.Dto;

namespace TrabajoEdi3.Entidades.Extensiones
{
    public  static class ZapatillaExtension
    {
        public static Zapatilla FromZapatillaListDtoToZapatilla(this ZapatillaListDto zapatillaDto)
        {
            return new Zapatilla
            {
                //ZapatillaId = zapatillaDto.ZapatillaId,
                //Modelo = zapatillaDto.Modelo,
                //Precio = zapatillaDto.Precio,
                //MarcaId = zapatillaDto.MarcaId,
                //GeneroId = zapatillaDto.GeneroId,
                //DeporteId = zapatillaDto.DeporteId,
                //ColoresId=zapatillaDto.ColoresId

                
            };
        }
    }
}

