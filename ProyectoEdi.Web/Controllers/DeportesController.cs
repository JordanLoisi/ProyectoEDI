using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProyectoEdi.Web.Views_Model.Deporte;
using ProyectoEdi.Web.Views_Model.Marca;
using ProyectoEdi.Web.Views_Model.Zapatillas;
using TrabajoEdi3.Entidades;
using TrabajoEdi3.Servicios.Interfaces;
using TrabajoEdi3.Servicios.Servicios;
using X.PagedList.Extensions;

namespace ProyectoEdi.Web.Controllers
{
    public class DeportesController : Controller
    {

        private readonly IServicioDeporte? _servicio;
        private readonly IMapper? _mapper;
        private readonly IServicioZapatilla? _servicioZapatilla;

        public DeportesController(IServicioDeporte servicio, IMapper mapper, IServicioZapatilla servicioZapatilla)
        {
            _servicio = servicio;
            _mapper = mapper;
            _servicioZapatilla = servicioZapatilla;
        }
        public IActionResult Index(int? page)
        {
            int pageNumber = page ?? 1;
            int pageSize = 10;
            var deporte = _servicio?
                .GetAll(orderBy: o => o.OrderBy(c => c.NombreDeporte));
            var deporteVm = _mapper?.Map<List<DeporteListVm>>(deporte);
              
            foreach (var item in deporteVm)
            {
                item.CantidadZapatillas = _servicioZapatilla.GetCantidad(c => c.DeporteId == item.DeporteId);
            }


            return View(deporteVm.ToPagedList(pageNumber, pageSize));


        }
        public IActionResult UpSert(int? id)
        {
            if (_servicio == null || _mapper == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Dependencias no están configuradas correctamente");
            }
            DeporteEditVm deporteVm;
            if (id == null || id == 0)
            {
                deporteVm = new DeporteEditVm();
            }
            else
            {
                try
                {
                    Deporte? deporte = _servicio.Get(filter: c => c.DeporteId == id);
                    if (deporte == null)
                    {
                        return NotFound();
                    }
                    deporteVm = _mapper.Map<DeporteEditVm>(deporte);
                    return View(deporteVm);
                }
                catch (Exception)
                {
                    // Log the exception (ex) here as needed
                    return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving the record.");
                }

            }
            return View(deporteVm);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpSert(DeporteEditVm deporteVm)
        {
            if (!ModelState.IsValid)
            {
                return View(deporteVm);
            }

            if (_servicio == null || _mapper == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Dependencias no están configuradas correctamente");
            }

            try
            {
                Deporte deporte = _mapper.Map<Deporte>(deporteVm);

                if (_servicio.Existe(deporte))
                {
                    ModelState.AddModelError(string.Empty, "Record already exist");
                    return View(deporteVm);
                }

                _servicio.Guardar(deporte);
                TempData["success"] = "Record successfully added/edited";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                // Log the exception (ex) here as needed
                ModelState.AddModelError(string.Empty, "An error occurred while editing the record.");
                return View(deporteVm);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int? id)
        {
            if (id is null || id == 0)
            {
                return NotFound();
            }
            Deporte? deporte = _servicio?.Get(filter: c => c.DeporteId == id);
            if (deporte is null)
            {
                return NotFound();
            }
            try
            {
                if (_servicio == null || _mapper == null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Dependencias no están configuradas correctamente");
                }

                if (_servicio.EstaRelacionado(deporte.DeporteId))
                {
                    return Json(new { success = false, message = "Related Record... Delete Deny!!" }); ;
                }
                _servicio.Borrar(deporte);
                return Json(new { success = true, message = "Record successfully deleted" });
            }
            catch (Exception)
            {

                return Json(new { success = false, message = "Couldn't delete record!!! " }); ;

            }

        }
        public IActionResult Details(int? id, int? page)
        {

            if (id is null || id == 0)
            {
                return NotFound();
            }
            Deporte? deporte = _servicio?.Get(filter: c => c.DeporteId == id);
            if (deporte is null)
            {
                return NotFound();
            }
            var currentPage = page ?? 1;
            int pageSize = 10;
            DeporteDetailsVm deporteVm = _mapper!.Map<DeporteDetailsVm>(deporte);
            //categoryVm.ProductsQuantity = GetProductQuantity(categoryVm.CategoryId);
            var zapatilla = _servicioZapatilla!.GetAll(
                orderBy: o => o.OrderBy(p => p.Description),
                filter: p => p.DeporteId == deporteVm.DeporteId,
                propertiesNames: "Marca,Deporte,Colores,Genero");
            deporteVm.Zapatilla = _mapper!.Map<List<ZapatillasListVm>>(zapatilla).ToPagedList(currentPage, pageSize);
            return View(deporteVm);

        }
    }
}
