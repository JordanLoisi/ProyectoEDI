using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProyectoEdi.Web.Views_Model.Marca;
using TrabajoEdi3.Entidades;
using TrabajoEdi3.Servicios.Interfaces;
using TrabajoEdi3.Servicios.Servicios;
using X.PagedList.Extensions;

namespace ProyectoEdi.Web.Controllers
{
    public class MarcasController : Controller
    {
        private readonly IServicioMarca? _servicio;
        private readonly IMapper? _mapper;

        public MarcasController(IServicioMarca servicio, IMapper mapper)
        {
            _servicio = servicio;
            _mapper = mapper;

        }
        public IActionResult Index(int? page)
        {
            int pageNumber = page ?? 1;
            int pageSize = 10;
            var marca = _servicio?
                .GetAll(orderBy: o => o.OrderBy(c => c.MarcaNombre));
            var marcaVm = _mapper?.Map<List<MarcaListVm>>(marca)
                .ToPagedList(pageNumber, pageSize);

            return View(marcaVm);
        }
        public IActionResult UpSert(int? id)
        {
            if (_servicio == null || _mapper == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Dependencias no están configuradas correctamente");
            }
            MarcaEditVm marcaVm;
            if (id == null || id == 0)
            {
                marcaVm = new MarcaEditVm();
            }
            else
            {
                try
                {
                    Marca? marca = _servicio.Get(filter: c => c.MarcaId == id);
                    if (marca == null)
                    {
                        return NotFound();
                    }
                    marcaVm = _mapper.Map<MarcaEditVm>(marca);
                    return View(marcaVm);
                }
                catch (Exception)
                {
                    // Log the exception (ex) here as needed
                    return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving the record.");
                }

            }
            return View(marcaVm);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpSert(MarcaEditVm marcaVm)
        {
            if (!ModelState.IsValid)
            {
                return View(marcaVm);
            }

            if (_servicio == null || _mapper == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Dependencias no están configuradas correctamente");
            }

            try
            {
                Marca marca = _mapper.Map<Marca>(marcaVm);

                if (_servicio.Existe(marca))
                {
                    ModelState.AddModelError(string.Empty, "Record already exist");
                    return View(marcaVm);
                }

                _servicio.Guardar(marca);
                TempData["success"] = "Record successfully added/edited";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                // Log the exception (ex) here as needed
                ModelState.AddModelError(string.Empty, "An error occurred while editing the record.");
                return View(marcaVm);
            }
        }

        [HttpDelete]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int? id)
        {
            if (id is null || id == 0)
            {
                return NotFound();
            }
            Marca? marca = _servicio?.Get(filter: c => c.MarcaId == id);
            if (marca is null)
            {
                return NotFound();
            }
            try
            {
                if (_servicio == null || _mapper == null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Dependencias no están configuradas correctamente");
                }

                if (_servicio.EstaRelacionado(marca.MarcaId))
                {
                    return Json(new { success = false, message = "Related Record... Delete Deny!!" }); ;
                }
                _servicio.Borrar(marca);
                return Json(new { success = true, message = "Record successfully deleted" });
            }
            catch (Exception)
            {

                return Json(new { success = false, message = "Couldn't delete record!!! " }); ;

            }
        }



    }
}
