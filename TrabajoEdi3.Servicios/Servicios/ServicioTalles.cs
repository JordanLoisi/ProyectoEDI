using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TrabajoEdi3.Datos.Intefaces;
using TrabajoEdi3.Datos.UnitOfWork;
using TrabajoEdi3.Entidades;
using TrabajoEdi3.Entidades.Enums;
using TrabajoEdi3.Servicios.Interfaces;

namespace TrabajoEdi3.Servicios.Servicios
{
    public class ServicioTalles : ITallesServicio
    {
        private readonly ITallesRepositores _repository;
        private readonly IUnitOfWork _unitOfWork;

        public ServicioTalles(ITallesRepositores repository,
            IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public void Borrar(Talles talles)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                _repository.Borrar(talles);
                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
                throw;
            }
        }

        public void EditarStocks(ZapatillasTalles zapatillasTalles)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                _repository.EditarStocks(zapatillasTalles);
                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
                throw;
            }
        }

        public bool EstaRelacionado(int id)
        {
            try
            {
                return _repository.EstaRelacionado(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Existe(Talles talles)
        {
            try
            {
                return _repository.Existe(talles);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Talles? Get(Expression<Func<Talles, bool>>? filter = null, string? propertiesNames = null, bool tracked = true)
        {
            return _repository!.Get(filter, propertiesNames, tracked);
        }

        public IEnumerable<Talles>? GetAll(Expression<Func<Talles, bool>>? filter = null, Func<IQueryable<Talles>, IOrderedQueryable<Talles>>? orderBy = null, string? propertiesNames = null)
        {
            return _repository!.GetAll(filter, orderBy, propertiesNames);
        }

        public int GetCantidad()
        {
            try
            {
                return _repository.GetCantidad();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Talles> GetLista()
        {
            try
            {
                return _repository.GetLista();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Talles> GetTallesPaginadosOrdenados(int page, int pageSize, Orden? orden = null)
        {
            try
            {
                return _repository.GetTallesPaginadosOrdenados(page, pageSize, orden);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Talles? GetTallesPorId(int id, bool incluyeZapatilla = false)
        {
            try
            {
                return _repository.GetTallesPorId(id, incluyeZapatilla);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Guardar(Talles talles)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                if (talles.TallesId == 0)
                {
                    if (!_repository.Existe(talles))
                    {
                        _repository.Agregar(talles);
                    }
                    else
                    {
                        throw new Exception("el talle ya existe.");
                    }
                }
                else
                {
                    _repository.Editar(talles);
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
