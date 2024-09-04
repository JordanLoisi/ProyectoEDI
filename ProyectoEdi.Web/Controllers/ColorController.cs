using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProyectoEdi.Web.Views_Model.Color;
using TrabajoEdi3.Entidades;
using TrabajoEdi3.Servicios.Interfaces;
using X.PagedList.Extensions;

namespace ProyectoEdi.Web.Controllers
{
    public class ColorController : Controller
    {
        private readonly IServicioColor? _servicio;
        private readonly IMapper? _mapper;

        public ColorController(IServicioColor servicio, IMapper mapper)
        {
            _servicio = servicio;
            _mapper = mapper;
        }
        public IActionResult Index(int? page)
        {
            int pageNumber = page ?? 1;
            int pageSize = 10;
            var color = _servicio?
                .GetAll(orderBy: o => o.OrderBy(c => c.ColorName));
            var colorVm = _mapper?.Map<List<ColorListVm>>(color)
                .ToPagedList(pageNumber, pageSize);

            return View(colorVm);

        }
        public IActionResult UpSert(int? id)
        {
            if (_servicio == null || _mapper == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Dependencias no están configuradas correctamente");
            }
            ColorEditVm colorVm;
            if (id == null || id == 0)
            {
                colorVm = new ColorEditVm();
            }
            else
            {
                try
                {
                    Color? color = _servicio.Get(filter: c => c.ColorId == id);
                    if (color == null)
                    {
                        return NotFound();
                    }
                    colorVm = _mapper.Map<ColorEditVm>(color);
                    return View(colorVm);
                }
                catch (Exception)
                {
                    // Log the exception (ex) here as needed
                    return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving the record.");
                }

            }
            return View(colorVm);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpSert(ColorEditVm colorVm)
        {
            if (!ModelState.IsValid)
            {
                return View(colorVm);
            }

            if (_servicio == null || _mapper == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Dependencias no están configuradas correctamente");
            }

            try
            {
                Color color = _mapper.Map<Color>(colorVm);

                if (_servicio.Existe(color))
                {
                    ModelState.AddModelError(string.Empty, "Record already exist");
                    return View(colorVm);
                }

                _servicio.Guardar(color);
                TempData["success"] = "Record successfully added/edited";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                // Log the exception (ex) here as needed
                ModelState.AddModelError(string.Empty, "An error occurred while editing the record.");
                return View(colorVm);
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
            Color? color = _servicio?.Get(filter: c => c.ColorId == id);
            if (color is null)
            {
                return NotFound();
            }
            try
            {
                if (_servicio == null || _mapper == null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Dependencias no están configuradas correctamente");
                }

                if (_servicio.EstaRelacionado(color.ColorId))
                {
                    return Json(new { success = false, message = "Related Record... Delete Deny!!" }); ;
                }
                _servicio.Borrar(color);
                return Json(new { success = true, message = "Record successfully deleted" });
            }
            catch (Exception)
            {

                return Json(new { success = false, message = "Couldn't delete record!!! " }); ;

            }
        }

    }
}
