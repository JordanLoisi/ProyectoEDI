using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProyectoEdi.Web.Views_Model.Zapatillas;
using TrabajoEdi3.Servicios.Interfaces;
using X.PagedList.Extensions;

namespace ProyectoEdi.Web.Controllers
{
    public class ZapatillasController : Controller
    {
        private readonly IServicioZapatilla? _servicio;
        private readonly IServicioMarca? _marcaServicio;
        private readonly IServicioDeporte? _deporteServicio;
        private readonly IServicioColor? _colorServicio;
        private readonly IServicioGenero? _generoServicio;
        private readonly IMapper? _mapper;

        private int pageSize=10;

        public ZapatillasController(IServicioZapatilla servicio,IServicioMarca servicioMarca,IServicioDeporte servicioDeporte,
            IServicioGenero servicioGenero,IServicioColor servicioColor,IMapper mapper)
        {
            _servicio = servicio ?? throw new ApplicationException("Dependencies not set"); ;
            _marcaServicio= servicioMarca ?? throw new ApplicationException("Dependencies not set");
            _deporteServicio= servicioDeporte ?? throw new ApplicationException("Dependencies not set");
            _colorServicio = servicioColor ?? throw new ApplicationException("Dependencies not set");
            _generoServicio= servicioGenero ?? throw new ApplicationException("Dependencies not set");
            _mapper = mapper ?? throw new ApplicationException("Dependencies not set");
        }
        public IActionResult Index(int? page)
        {
            var currentPage = page ?? 1;
            var zapatilla = _servicio?
                    .GetAll(
                        orderBy: o => o.OrderBy(s => s.Description),
                        propertiesNames: "marca,deporte,color,genero");
            var zapatillasListVm = _mapper?.Map<List<ZapatillasListVm>>(zapatilla);
            return View(zapatillasListVm?.ToPagedList(currentPage, pageSize));
           
        }

    }
}
