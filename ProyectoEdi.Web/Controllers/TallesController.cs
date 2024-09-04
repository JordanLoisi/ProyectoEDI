using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProyectoEdi.Web.Views_Model.Marca;
using ProyectoEdi.Web.Views_Model.Talles;
using TrabajoEdi3.Entidades;
using TrabajoEdi3.Servicios.Interfaces;
using X.PagedList.Extensions;

namespace ProyectoEdi.Web.Controllers
{
    public class TallesController : Controller
    {
        private readonly ITallesServicio? _servicio;
        private readonly IMapper? _mapper;

        public TallesController(ITallesServicio servicio,IMapper mapper )
        {
            _servicio = servicio;
            _mapper = mapper;
        }
        public IActionResult Index(int? page)
        {
            int pageNumber = page ?? 1;
            int pageSize = 10;
            var talle = _servicio?
                .GetAll(orderBy: o => o.OrderBy(c => c.TallesNumbero));
            var talleVm = _mapper?.Map<List<TallesListVm>>(talle)
                .ToPagedList(pageNumber, pageSize);
            return View(talleVm);
        }
        public IActionResult UpSert(int? id)
        {
            if (_servicio == null || _mapper == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Dependencias no están configuradas correctamente");
            }
            TallesEditVm tallesVm;
            if (id == null || id == 0)
            {
                tallesVm = new TallesEditVm();
            }
            else
            {
                try
                {
                    Talles? talles = _servicio.Get(filter: c => c.TallesId == id);
                    if (talles == null)
                    {
                        return NotFound();
                    }
                    tallesVm = _mapper.Map<TallesEditVm>(talles);
                    return View(tallesVm);
                }
                catch (Exception)
                {
                    // Log the exception (ex) here as needed
                    return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving the record.");
                }

            }
            return View(tallesVm);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpSert(TallesEditVm tallesVm)
        {
            if (!ModelState.IsValid)
            {
                return View(tallesVm);
            }

            if (_servicio == null || _mapper == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Dependencias no están configuradas correctamente");
            }

            try
            {
                Talles talles = _mapper.Map<Talles>(tallesVm);

                if (_servicio.Existe(talles))
                {
                    ModelState.AddModelError(string.Empty, "Record already exist");
                    return View(tallesVm);
                }

                _servicio.Guardar(talles);
                TempData["success"] = "Record successfully added/edited";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                // Log the exception (ex) here as needed
                ModelState.AddModelError(string.Empty, "An error occurred while editing the record.");
                return View(tallesVm);
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
            Talles? talles = _servicio?.Get(filter: c => c.TallesId == id);
            if (talles is null)
            {
                return NotFound();
            }
            try
            {
                if (_servicio == null || _mapper == null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Dependencias no están configuradas correctamente");
                }

                if (_servicio.EstaRelacionado(talles.TallesId))
                {
                    return Json(new { success = false, message = "Related Record... Delete Deny!!" }); ;
                }
                _servicio.Borrar(talles);
                return Json(new { success = true, message = "Record successfully deleted" });
            }
            catch (Exception)
            {

                return Json(new { success = false, message = "Couldn't delete record!!! " }); ;

            }
        }
    }
}
