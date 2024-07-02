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
    public class ServicioColor : IServicioColor
    {
        private readonly IColorRepositorio _repository;
        private readonly IUnitOfWork _unitOfWork;
        public ServicioColor(IColorRepositorio repository,
            IUnitOfWork uniOfWork)
        {
            _repository = repository;
            _unitOfWork = uniOfWork;
        }
        public void Borrar(Color color)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                _repository.Borrar(color);
                _unitOfWork.Commit();

            }
            catch (Exception)
            {
                _unitOfWork?.Rollback();
                throw;
            }
        }
    

        public bool EstaRelacionado(Color color)
        {
            return _repository.EstaRelacionado(color);
        }

        public bool Existe(Color color)
        {
            return _repository.Existe(color);
        }

        public int GetCantidad(Func<Color, bool>? filtro = null)
        {
            return _repository.GetCantidad(filtro);
        }

        public Color? GetColorPorId(int idEditar)
        {
            return _repository.GetColorPorId(idEditar);
        }

        public Color? GetColorPorNombre(string tipoDeEnvase)
        {
            return _repository.GetColorPorNombre(tipoDeEnvase);
        }

        public List<Color> GetLista()
        {
            return _repository.GetLista();
        }

        public void Guardar(Color color)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                if (color.ColorId == 0)
                {
                    _repository.Agregar(color);
                }
                else
                {
                    _repository.Editar(color);
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
