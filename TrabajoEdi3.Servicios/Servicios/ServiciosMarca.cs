using System.Linq.Expressions;
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

        public bool EstaRelacionado(int id)
        {
            return _repository.EstaRelacionado(id);
        }

        public bool Existe(Marca marca)
        {

            return _repository.Existe(marca);
        }

        public int GetCantidadFiltro(Func<Marca, bool>? filtro = null)
        {
            return _repository.GetCantidadFiltro(filtro);
        }
        public int GetCantidad()
        {
            return _repository.GetCantidad();
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
        public IEnumerable<Marca> GetAll(Expression<Func<Marca, bool>>? filter = null,
           Func<IQueryable<Marca>, IOrderedQueryable<Marca>>? orderBy = null,
           string? propertiesNames = null)
        {
            return _repository!.GetAll(filter, orderBy, propertiesNames);
        }

        public Marca? Get(Expression<Func<Marca, bool>>? filter = null, string? propertiesNames = null, bool tracked = true)
        {
            return _repository!.Get(filter, propertiesNames, tracked);
        }
    }
}
