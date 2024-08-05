using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TrabajoEdi3.Datos.Intefaces;
using TrabajoEdi3.Entidades;
using TrabajoEdi3.Entidades.Dto;
using TrabajoEdi3.Entidades.Enums;

namespace TrabajoEdi3.Datos.Repositorio
{
    public class RepositorioZapatillas : IZapatillasRepositorio
    {
        private readonly DbContex _Context;
        public RepositorioZapatillas(DbContex context)
        {
            _Context = context;
        }
        public void Agregar(Zapatilla zapatilla)
        {
            // Verificar si el TipoDePlanta asociado
            // a la planta ya existe en la base de datos
            var MarcaExistente = _Context.marcas
                .FirstOrDefault(t => t.MarcaId == zapatilla.MarcaId);

            // Si el TipoDeMarca ya existe,
            // adjuntarlo al contexto en lugar de agregarlo nuevamente
            if (MarcaExistente != null)
            {
                _Context.Attach(MarcaExistente);
                zapatilla.Marca = MarcaExistente;
            }
            // Verificar si el TipoDeDeporte asociado
            // a la planta ya existe en la base de datos

            var DeporteExistente = _Context.deportes
                .FirstOrDefault(t => t.DeporteId == zapatilla.DeporteId);
            if (DeporteExistente != null)
            {
                _Context.Attach(DeporteExistente);
                zapatilla.Deporte = DeporteExistente;
            }

            // Verificar si el TipoDeGenero asociado
            // a la Zapatilla ya existe en la base de datos
            var GeneroExistente = _Context.generos
              .FirstOrDefault(t => t.GeneroId == zapatilla.GeneroId);
            if (GeneroExistente != null)
            {
                _Context.Attach(GeneroExistente);
                zapatilla.Genero = GeneroExistente;
            }
            // Verificar si el TipoDeColor asociado
            // a la Zapatilla ya existe en la base de datos
            var ColorExistente = _Context.colors
              .FirstOrDefault(t => t.ColorId == zapatilla.ColoresId);
            if (ColorExistente != null)
            {
                _Context.Attach(ColorExistente);
                zapatilla.Colores = ColorExistente;
            }


            // Agregar la planta al contexto de la base de datos
            _Context.zapatillas.Add(zapatilla);
        }

        public void AgregarTallesZapatilla(ZapatillasTalles nuevaRelacion)
        {
            _Context.Set<ZapatillasTalles>().Add(nuevaRelacion);
        }

        public void AgregarZapatillaTalles(Zapatilla zapatilla, List<Talles> talles)
        {
            foreach (var Talles in talles)
            {
                var tallesExistente = _Context.talles
                    .FirstOrDefault(p => p.TallesId == Talles.TallesId);

                if (tallesExistente == null)
                {
                    _Context.talles.Add(Talles); // Agregar nuevo talle
                    tallesExistente = Talles; // Establecer talleExistente como el nuevo talle
                }
                else
                {
                    _Context.talles.Attach(tallesExistente); // Attach si el proveedor ya existe y está detached
                }

                if (!ExisteRelacion(zapatilla, tallesExistente))
                {
                    _Context.zapatillastalles.Add(new ZapatillasTalles
                    {
                        ZapatillaId = zapatilla.ZapatillaId,
                        TallesId = tallesExistente.TallesId,
                        
                        
                    });
                }
            }
        }

        public void Borrar(Zapatilla zapatilla)
        {
            _Context.zapatillas.Remove(zapatilla);
        }

        public void Editar(Zapatilla zapatilla)
        {
            // Verificar si el TipoDePlanta asociado
            // a la planta ya existe en la base de datos
            var MarcaExistente = _Context.marcas
                .FirstOrDefault(t => t.MarcaId == zapatilla.MarcaId);

            // Si el TipoDeMarca ya existe,
            // adjuntarlo al contexto en lugar de agregarlo nuevamente
            if (MarcaExistente != null)
            {
                _Context.Attach(MarcaExistente);
                zapatilla.Marca = MarcaExistente;
            }
            // Verificar si el TipoDeDeporte asociado
            // a la planta ya existe en la base de datos

            var DeporteExistente = _Context.deportes
                .FirstOrDefault(t => t.DeporteId == zapatilla.DeporteId);
            if (DeporteExistente != null)
            {
                _Context.Attach(DeporteExistente);
                zapatilla.Deporte = DeporteExistente;
            }

            // Verificar si el TipoDeGenero asociado
            // a la Zapatilla ya existe en la base de datos
            var GeneroExistente = _Context.generos
              .FirstOrDefault(t => t.GeneroId == zapatilla.GeneroId);
            if (GeneroExistente != null)
            {
                _Context.Attach(GeneroExistente);
                zapatilla.Genero = GeneroExistente;
            }
            // Verificar si el TipoDeColor asociado
            // a la Zapatilla ya existe en la base de datos
            var ColorExistente = _Context.colors
              .FirstOrDefault(t => t.ColorId == zapatilla.ColoresId);
            if (ColorExistente != null)
            {
                _Context.Attach(ColorExistente);
                zapatilla.Colores = ColorExistente;
            }


            // Agregar la planta al contexto de la base de datos
            _Context.zapatillas.Update(zapatilla);
        }

        public void Editar(Zapatilla zapatilla, int? TallesId)
        {
            _Context.zapatillas.Update(zapatilla);
        }

        public void EliminarRelaciones(Zapatilla zapatilla)
        {
            var relacionesPasadas = _Context.zapatillastalles
              .Where(pp => pp.ZapatillaId == zapatilla.ZapatillaId)
              .ToList();

            _Context.zapatillastalles
                .RemoveRange(relacionesPasadas);
        }

        public bool Existe(Zapatilla zapatilla)
        {
            if (zapatilla.ZapatillaId == 0)
            {
                return _Context.zapatillas.Any(
                    p => p.Modelo == zapatilla.Modelo &&
                    p.Description == zapatilla.Description &&
                    p.DeporteId == zapatilla.DeporteId &&
                    p.MarcaId == zapatilla.MarcaId &&
                    p.GeneroId == zapatilla.GeneroId &&
                    p.ColoresId == zapatilla.ColoresId);
            }
            return _Context.zapatillas.Any(
                 p => p.Modelo == zapatilla.Modelo &&
                 p.Description == zapatilla.Description &&
                    p.DeporteId == zapatilla.DeporteId &&
                    p.MarcaId == zapatilla.MarcaId &&
                    p.GeneroId == zapatilla.GeneroId &&
                    p.ColoresId == zapatilla.ColoresId &&
                    p.ZapatillaId == zapatilla.ZapatillaId);
        }

        public bool ExisteRelacion(Zapatilla zapatilla, Talles talles)
        {
            if (zapatilla == null || talles == null) return false;

            return _Context.zapatillastalles
                .Any(pp => pp.ZapatillaId == zapatilla.ZapatillaId
                && pp.TallesId == talles.TallesId);

        }

        public int GetCantidad(Func<Zapatilla, bool>? filtro = null)
        {
            if (filtro != null)
            {
                return _Context.zapatillas.Count(filtro);
            }
            else
            {
                return _Context.zapatillas.Count();
            }
        }

        public List<Zapatilla> GetLista()
        {
            return _Context.zapatillas
             .Include(p => p.Colores)
             .Include(p => p.Deporte)
             .Include(p => p.Marca)
             .Include(p => p.Genero)
             .ToList();
        }

        public IEnumerable<object> GetListaAnonima()
        {
            return _Context.zapatillas
              .Include(p => p.Colores)
              .Include(p => p.Deporte)
               .Include(p => p.Marca)
              .Include(p => p.Genero)

              .Select(n => new
              {
                  Id = n.ZapatillaId,
                  Zapatilla = n.Modelo,
                  Marca = n.Marca != null ? n.Marca.MarcaNombre : string.Empty,
                  Deporte = n.Deporte != null ? n.Deporte.NombreDeporte : string.Empty,
                  Colores = n.Colores != null ? n.Colores.ColorName : string.Empty,
                  Genero = n.Genero != null ? n.Genero.GeneroNombre : string.Empty,
                  Precio = n.Precio
              }).ToList();
        }

        public List<ZapatillaListDto> GetListaDto()
        {
            return _Context.zapatillas
                .Include(p => p.Marca)
                .Include(p => p.Deporte)
                .Include(p => p.Colores)
                .Include(p => p.Genero)
                .Include(p=>p.zapatillastalles)
                .Select(n => new ZapatillaListDto
                {
                    ZapatillaId = n.ZapatillaId,
                    Modelo = n.Modelo,
                    Description = n.Description,
                    Marca = n.Marca != null ? n.Marca.MarcaNombre : string.Empty,
                    Deporte = n.Deporte != null ? n.Deporte.NombreDeporte : string.Empty,
                    Colores = n.Colores != null ? n.Colores.ColorName : string.Empty,
                    Genero = n.Genero != null ? n.Genero.GeneroNombre : string.Empty,
                    Precio = n.Precio
                }).ToList();
        }

        public List<ZapatillaListDto> GetListaPaginadaOrdenadaFiltrada
            (int page, int pageSize, Orden? orden = null, Deporte? DeporteFiltro = null, Marca? MarcaFiltro = null, Entidades.Color? colorFiltro = null, Genero? GeneroFiltro = null, Talles? talleSelec = null, Talles? tallemax = null)
        {
            IQueryable<Zapatilla> query = _Context.zapatillas
              .Include(p => p.Marca)
              .Include(p => p.Deporte)
              .Include(p => p.Colores)
              .Include(p => p.Genero)
              .Include(p => p.zapatillastalles).ThenInclude(s => s.Talles)

              .AsNoTracking();

            // Aplicar filtro si se proporciona un tipo de Marca
            if (MarcaFiltro != null)
            {
                query = query
                    .Where(p => p.MarcaId == MarcaFiltro.MarcaId);
            }

            // Aplicar filtro si se proporciona un tipo de Deporte
            if (DeporteFiltro != null)
            {
                query = query
                    .Where(p => p.DeporteId == DeporteFiltro.DeporteId);
            }
            if (colorFiltro != null)
            {
                query = query
                    .Where(p => p.ColoresId == colorFiltro.ColorId);
            }

            // Aplicar filtro si se proporciona un tipo de Genero
            if (GeneroFiltro != null)
            {
                query = query
                    .Where(p => p.GeneroId == GeneroFiltro.GeneroId);
            }
            if (talleSelec != null && tallemax == null)
            {
                query = query.Where(s => _Context.zapatillastalles.Any(ss => ss.TallesId == talleSelec.TallesId && ss.ZapatillaId == s.ZapatillaId));
            }
            if (talleSelec != null && tallemax != null)
            {
                query = query.Where(s => _Context.zapatillastalles.Any(ss => ss.ZapatillaId == s.ZapatillaId && ss.TallesId <= tallemax.TallesId && ss.TallesId >= talleSelec.TallesId));
            }

            // Aplicar orden si se proporciona
            if (orden != null)
            {
                switch (orden)
                {
                    case Orden.AZ:
                        query = query.OrderBy(p => p.Description);
                        break;
                    case Orden.ZA:
                        query = query.OrderByDescending(p => p.Description);
                        break;
                    case Orden.MenorPrecio:
                        query = query.OrderBy(p => p.Precio);
                        break;
                    case Orden.MayorPrecio:
                        query = query.OrderByDescending(p => p.Precio);
                        break;
                    default:
                        break;
                }
            }
            // Paginar los resultados
            List<Zapatilla> listaPaginada = query
                .Skip(page * pageSize)
                .Take(pageSize)
                .ToList();

            // Mapear los resultados a PlantaListDto
            List<ZapatillaListDto> listaDto = listaPaginada
                .Select(p => new ZapatillaListDto
                {
                    ZapatillaId = p.ZapatillaId,
                    Description = p.Description,
                    Marca = p.Marca.MarcaNombre,
                    Deporte = p.Deporte.NombreDeporte,
                    Genero = p.Genero.GeneroNombre,
                    Colores = p.Colores.ColorName,
                    Modelo = p.Modelo,
                    Precio = p.Precio
                })
                .ToList();

            return listaDto;
        }

        public List<ZapatillaListDto>? GetZapatillaSinTalle()
        {
            return _Context.zapatillas
               .Include(p => p.Marca)
              .Include(p => p.Deporte)
              .Include(p => p.Colores)
              .Include(p => p.Genero)
                .Where(p => !p.zapatillastalles.Any())
                .Select(p => new ZapatillaListDto
                {
                    ZapatillaId = p.ZapatillaId,
                    Description = p.Description,
                    Marca = p.Marca.MarcaNombre == null ? "N/A" : p.Marca.MarcaNombre,
                    Deporte = p.Deporte.NombreDeporte == null ? "N/A" : p.Deporte.NombreDeporte,
                    Genero = p.Genero.GeneroNombre == null ? "N/A" : p.Genero.GeneroNombre,
                    Colores = p.Colores.ColorName == null ? "N/A" : p.Colores.ColorName,
                    Modelo = p.Modelo,
                    Precio = p.Precio
                })
                .ToList();
        }

        public List<ZapatillasTalles>? GetTallesPorZapatilla(int zapatillaId)
        {
            return _Context.zapatillastalles
                .Include(pp => pp.Talles)
               .Where(pp => pp.ZapatillaId == zapatillaId)
               .ToList();
        }

        public Zapatilla? GetZapatillaPorId(int zapatillaId)
        {
            return _Context.zapatillas
                .Include(p => p.Marca)
                 .Include(p => p.Genero)
                 .Include(p => p.Deporte)
                 .Include(p => p.Colores)
                 .FirstOrDefault(p => p.ZapatillaId == zapatillaId);
        }

        public bool EstaRelacionado(Zapatilla zapatilla)
        {
            return _Context.zapatillastalles.Any(ss => ss.ZapatillaId == zapatilla.ZapatillaId);
        }
    }
}
