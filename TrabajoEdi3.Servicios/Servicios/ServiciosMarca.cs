using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoEdi3.Datos.Intefaces;
using TrabajoEdi3.Datos.UnitOfWork;
using TrabajoEdi3.Entidades;
using TrabajoEdi3.Servicios.Interfaces;

namespace TrabajoEdi3.Servicios.Servicios
{
    public class ServiciosMarca : IServicioMarca
    {
        private readonly IMarcaRepositorio _repository;
        private readonly IUnitOfWork _unitOfWork;
        public ServiciosMarca(IMarcaRepositorio repository,
            IUnitOfWork uniOfWork)
        {
            _repository = repository;
            _unitOfWork = uniOfWork;
        }
        public void Borrar(Marca marca)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                _repository.Borrar(marca);
                _unitOfWork.Commit();

            }
            catch (Exception)
            {
                _unitOfWork?.Rollback();
                throw;
            }
        }

        public bool EstaRelacionado(Marca marca)
        {
            return _repository.EstaRelacionado(marca);
        }

        public bool Existe(Marca marca)
        {

            return _repository.Existe(marca);
        }

        public int GetCantidad(Func<Marca, bool>? filtro = null)
        {
            return _repository.GetCantidad(filtro);
        }

        public List<Marca> GetLista()
        {
            return _repository.GetLista();
        }

        public Marca? GetMarcaPorId(int idEditar)
        {
            return _repository.GetMarcaPorId(idEditar);
        }

        public Marca? GetMarcaPorNombre(string marca)
        {
            return _repository.GetMarcaPorNombre(marca);
        }

        public void Guardar(Marca marca)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                if (marca.MarcaId == 0)
                {
                    _repository.Agregar(marca);
                }
                else
                {
                    _repository.Editar(marca);
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
