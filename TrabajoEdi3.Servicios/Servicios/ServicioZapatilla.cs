using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TrabajoEdi3.Datos.Intefaces;
using TrabajoEdi3.Datos.UnitOfWork;
using TrabajoEdi3.Entidades;
using TrabajoEdi3.Entidades.Dto;
using TrabajoEdi3.Entidades.Enums;
using TrabajoEdi3.Servicios.Interfaces;

namespace TrabajoEdi3.Servicios.Servicios
{
    public class ServicioZapatilla : IServicioZapatilla
    {
        private readonly IZapatillasRepositorio _repository;
        private readonly ITallesRepositores _tallesRepositores;
        private readonly IUnitOfWork _unitOfWork;
        public ServicioZapatilla(IZapatillasRepositorio repository,
            IUnitOfWork unitOfWork,
            ITallesRepositores tallesRepositores)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _unitOfWork = unitOfWork;
            _tallesRepositores = tallesRepositores;
        }

        public void AsignarTalleAZapatilla(Zapatilla zapatilla, Talles talles,int stock)
        {
            try
            {
                _unitOfWork.BeginTransaction();


                // Crear una nueva relación entre la planta y el proveedor
                ZapatillasTalles nuevaRelacion = new ZapatillasTalles
                {
                    Zapatilla = zapatilla,
                    Talles = talles,
                    Stok=stock
                };
                var validacion = _repository.ExisteRelacion(zapatilla,talles);
                if (validacion)
                {
                    Console.WriteLine("Relacion Existente ");
                    _unitOfWork.Rollback();
                }
                else
                {
                      _repository.AgregarTallesZapatilla(nuevaRelacion);
                    _unitOfWork.Commit();
                }
              
                
            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
                throw;
            }
        }

        public void Borrar(int zapatillaId)
        {
            try
            {
                _unitOfWork.BeginTransaction();

                var zapatilla = _repository.GetZapatillaPorId(zapatillaId);
                if (zapatilla == null)
                {
                    throw new Exception("La Zapatilla especificada no existe.");
                }

                // Eliminar relaciones con proveedores
                _repository.EliminarRelaciones(zapatilla);
                _unitOfWork.SaveChanges(); // Guardar cambios para confirmar eliminación de relaciones

                // Eliminar la planta
                _repository.Borrar(zapatilla);
                _unitOfWork.SaveChanges(); // Guardar cambios para confirmar eliminación de la planta

                _unitOfWork.Commit(); // Confirmar los cambios
            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
                throw;
            }
        
    }

        public void Editar(Zapatilla zapatilla, int? talleId)
        {
            try
            {
                _unitOfWork.BeginTransaction();

                // Editar la planta
                _repository.Editar(zapatilla);

                if (talleId.HasValue)
                {
                    // Buscar el proveedor
                    var talles = _tallesRepositores
                        .GetTallesPorId(talleId.Value);
                    if (talles != null)
                    {
                        // Crear la nueva relación si no existe
                        if (!zapatilla.zapatillastalles
                            .Any(pp => pp.TallesId == talleId))
                        {
                            var nuevaRelacion = new ZapatillasTalles
                            {
                                ZapatillaId = zapatilla.ZapatillaId,
                                TallesId = talles.TallesId
                            };
                            _tallesRepositores.AgregarZapatillasTalles(nuevaRelacion);

                        }
                    }
                    else
                    {
                        throw new Exception("Talles no encontrado.");
                    }
                }

                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
                throw;
            }
        }

        public bool EstaRelacionado(Zapatilla zapatilla)
        {
            try
            {
                return _repository.EstaRelacionado(zapatilla);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Existe(Zapatilla zapatilla)
        {
            return _repository.Existe(zapatilla);
        }

        public bool ExisteRelacion(Zapatilla zapatilla, Talles talles)
        {
            return _repository.ExisteRelacion(zapatilla, talles);
        }

        public Zapatilla? Get(Expression<Func<Zapatilla, bool>>? filter = null, string? propertiesNames = null, bool tracked = true)
        {
            return _repository!.Get(filter, propertiesNames, tracked);
        }

        public IEnumerable<Zapatilla>? GetAll(Expression<Func<Zapatilla, bool>>? filter = null, Func<IQueryable<Zapatilla>, IOrderedQueryable<Zapatilla>>? orderBy = null, string? propertiesNames = null)
        {
            return _repository!.GetAll(filter, orderBy, propertiesNames);
        }

        public int GetCantidad(Func<Zapatilla, bool>? filtro = null)
        {
            return _repository.GetCantidad(filtro);
        }

        public List<Zapatilla> GetLista()
        {
            return _repository.GetLista();
        }

        public IEnumerable<object> GetListaAnonima()
        {
            return _repository.GetListaAnonima();
        }

        public List<ZapatillaListDto> GetListaDto()
        {
            return _repository.GetListaDto();
        }

        public List<ZapatillaListDto> GetListaPaginadaOrdenadaFiltrada
            (int page, int pageSize, Orden? orden = null, 
            Deporte? DeporteFiltro = null, Marca? MarcaFiltro = null,
            Color? colorFiltro = null, Genero? GeneroFiltro = null, Talles? tallesSelec=null ,Talles? tallemax=null)
        {
            return _repository.GetListaPaginadaOrdenadaFiltrada(page, pageSize,
               orden, DeporteFiltro, MarcaFiltro, colorFiltro, GeneroFiltro, tallesSelec,tallemax);
        }

        public List<ZapatillasTalles>? GetTallesPorZapatilla(int zapatillaId)
        {
            return _repository.GetTallesPorZapatilla(zapatillaId);
        }

        public Zapatilla? GetZapatillaPorId(int zapatillaId)
        {
            return _repository.GetZapatillaPorId(zapatillaId);
        }

        public List<ZapatillaListDto>? GetZapatillaSinTalle()
        {
            return _repository.GetZapatillaSinTalle();
        }

        public void Guardar(Zapatilla zapatilla, List<Talles>? talles = null)
        {
            try
            {
                _unitOfWork.BeginTransaction();

                if (zapatilla.ZapatillaId == 0)
                {
                    _repository.Agregar(zapatilla);
                    _unitOfWork.SaveChanges(); // Guardar cambios para obtener el id de la planta agregada

                    if (talles != null && talles.Any())
                    {
                        _repository.AgregarZapatillaTalles(zapatilla, talles);
                    }
                }
                else
                {
                    _repository.Editar(zapatilla);
                    _unitOfWork.SaveChanges(); // Guardar cambios de la planta antes de manejar relaciones

                    if (talles != null)
                    {
                        _repository.EliminarRelaciones(zapatilla);
                        _unitOfWork.SaveChanges(); // Guardar cambios para confirmar eliminación

                        if (talles.Any())
                        {
                            _repository.AgregarZapatillaTalles(zapatilla, talles);
                        }
                    }
                }
                _unitOfWork.SaveChanges(); // Guardar todos los cambios al final
                _unitOfWork.Commit(); // Confirmar los cambios
            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
                throw;
            }
        }



        public void GuardarConTalle(Zapatilla zapatilla, Talles talle)
        {

            try
            {
                _unitOfWork.BeginTransaction();
                // Agrega la planta
                _repository.Agregar(zapatilla);

                // Agrega el proveedor
                if (talle.TallesId == 0)
                {
                    _tallesRepositores.Agregar(talle);

                }
                // Guardar los cambios en la base de datos
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                // En caso de error, revertir la transacción
                _unitOfWork.Rollback();
                throw;
            }
        }

        public void GuardarZapas(Zapatilla zapatilla)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                if (zapatilla.ZapatillaId == 0)
                {
                    if (!_repository.Existe(zapatilla))
                    {
                        _repository.Agregar(zapatilla);
                    }
                    else
                    {
                        throw new Exception("el zapatilla ya existe.");
                    }
                }
                else
                {
                    _repository.Editar(zapatilla);
                }
                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
                throw;
            }
        }
    }
}
