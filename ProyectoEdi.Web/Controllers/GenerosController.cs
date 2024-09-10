using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProyectoEdi.Web.Views_Model.Generos;
using TrabajoEdi3.Entidades;
using TrabajoEdi3.Servicios.Interfaces;
using X.PagedList.Extensions;

namespace ProyectoEdi.Web.Controllers
{
    public class GenerosController : Controller
    {
        private readonly IServicioGenero? _servicio;
        private readonly IMapper? _mapper;

        public GenerosController(IServicioGenero servicio, IMapper mapper)
        {
            _servicio = servicio;
            _mapper = mapper;
        }
        public IActionResult Index(int? page)
        {
            int pageNumber = page ?? 1;
            int pageSize = 10;
            var genero = _servicio?
                .GetAll(orderBy: o => o.OrderBy(c => c.GeneroNombre));
            var generoVm = _mapper?.Map<List<GenerosListVm>>(genero)
                .ToPagedList(pageNumber, pageSize);

            return View(generoVm);
        }
        public IActionResult UpSert(int? id)
        {
            if (_servicio == null || _mapper == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Dependencias no están configuradas correctamente");
            }
            GenerosEditVm generoVm;
            if (id == null || id == 0)
            {
                generoVm = new GenerosEditVm();
            }
            else
            {
                try
                {
                    Genero? genero = _servicio.Get(filter: c => c.GeneroId == id);
                    if (genero == null)
                    {
                        return NotFound();
                    }
                    generoVm = _mapper.Map<GenerosEditVm>(genero);
                    return View(generoVm);
                }
                catch (Exception)
                {
                    // Log the exception (ex) here as needed
                    return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving the record.");
                }

            }
            return View(generoVm);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpSert(GenerosEditVm generoVm)
        {
            if (!ModelState.IsValid)
            {
                return View(generoVm);
            }

            if (_servicio == null || _mapper == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Dependencias no están configuradas correctamente");
            }

            try
            {
                Genero genero = _mapper.Map<Genero>(generoVm);

                if (_servicio.Existe(genero))
                {
                    ModelState.AddModelError(string.Empty, "Record already exist");
                    return View(generoVm);
                }

                _servicio.Guardar(genero);
                TempData["success"] = "Record successfully added/edited";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                // Log the exception (ex) here as needed
                ModelState.AddModelError(string.Empty, "An error occurred while editing the record.");
                return View(generoVm);
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
            Genero? genero = _servicio?.Get(filter: c => c.GeneroId == id);
            if (genero is null)
            {
                return NotFound();
            }
            try
            {
                if (_servicio == null || _mapper == null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Dependencias no están configuradas correctamente");
                }

                if (_servicio.EstaRelacionado(genero.GeneroId))
                {
                    return Json(new { success = false, message = "Related Record... Delete Deny!!" }); ;
                }
                _servicio.Borrar(genero);
                return Json(new { success = true, message = "Record successfully deleted" });
            }
            catch (Exception)
            {

                return Json(new { success = false, message = "Couldn't delete record!!! " }); ;

            }
        }
    }
}
