using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProyectoEdi.Web.Views_Model.Marca;
using ProyectoEdi.Web.Views_Model.Zapatillas;
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
        private readonly IWebHostEnvironment? _webHostEnvironment;
        private readonly IServicioZapatilla? _servicioZapatilla;
        public MarcasController(IServicioMarca servicio, IMapper mapper, IWebHostEnvironment webHostEnvironment,IServicioZapatilla servicioZapatilla)
        {
            _servicio = servicio;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
            _servicioZapatilla = servicioZapatilla;
        }
        public IActionResult Index(int? page)
        {
            int pageNumber = page ?? 1;
            int pageSize = 10;
            var marca = _servicio?
                .GetAll(orderBy: o => o.OrderBy(c => c.MarcaNombre));
            var marcaVm = _mapper?.Map<List<MarcaListVm>>(marca);
            foreach (var item in marcaVm)
            {
                item.CantidadZapatillas=_servicioZapatilla.GetCantidad(c=>c.MarcaId==item.MarcaId);
            }
            

            return View(marcaVm.ToPagedList(pageNumber,pageSize));
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
                    string? wwwWebRoot = _webHostEnvironment!.WebRootPath;
                    Marca? marca = _servicio.Get(filter: c => c.MarcaId == id);
                    if (marca == null)
                    {
                        return NotFound();
                    }
                    if (marca.ImageUrl != null)
                    {
                        var filePath = Path.Combine(wwwWebRoot, marca.ImageUrl!.TrimStart('/'));
                        ViewData["ImageExist"] = System.IO.File.Exists(filePath); 
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
                string? wwwWebRoot = _webHostEnvironment!.WebRootPath;
                Marca marca = _mapper.Map<Marca>(marcaVm);

                if (_servicio.Existe(marca))
                {
                    ModelState.AddModelError(string.Empty, "Record already exist");
                    return View(marcaVm);
                }
                if (marcaVm.ImageFile != null)
                {
                    var permittedExtensions = new string[] { ".png", ".jpg", ".jpeg", ".gif" };
                    var fileExtension = Path.GetExtension(marcaVm.ImageFile.FileName);
                    if (!permittedExtensions.Contains(fileExtension))
                    {
                        ModelState.AddModelError(string.Empty, "File not allowed");
                        return View(marcaVm);

                    }
                    if (marca.ImageUrl != null)
                    {
                        string oldFilePath = Path.Combine(wwwWebRoot, marca.ImageUrl.TrimStart('/'));
                        if (System.IO.File.Exists(oldFilePath))
                        {
                            System.IO.File.Delete(oldFilePath);
                        }
                    }
                    string fileName = $"{Guid.NewGuid()}{Path.GetExtension(marcaVm.ImageFile.FileName)}";
                    string pathName = Path.Combine(wwwWebRoot, "images", fileName);

                    using (var fileStream = new FileStream(pathName, FileMode.Create))
                    {
                        marcaVm.ImageFile.CopyTo(fileStream);
                    }
                    marca.ImageUrl = $"/images/{fileName}";
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

        [HttpPost]
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
                string? wwwWebRoot = _webHostEnvironment!.WebRootPath;

                string oldFilePath = Path.Combine(wwwWebRoot, marca.ImageUrl!.TrimStart('/'));
                if (System.IO.File.Exists(oldFilePath))
                {
                    System.IO.File.Delete(oldFilePath);
                }
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
            Marca? marca = _servicio?.Get(filter: c => c.MarcaId == id);
            if (marca is null)
            {
                return NotFound();
            }
            var currentPage = page ?? 1;
            int pageSize = 10;
            MarcaDetailsVm marcaVm = _mapper!.Map<MarcaDetailsVm>(marca);
            //categoryVm.ProductsQuantity = GetProductQuantity(categoryVm.CategoryId);
            var zapatilla = _servicioZapatilla!.GetAll(
                orderBy: o => o.OrderBy(p => p.Description),
                filter: p => p.MarcaId == marcaVm.MarcaId,
                propertiesNames: "Marca,Deporte,Colores,Genero");
            marcaVm.Zapatilla = _mapper!.Map<List<ZapatillasListVm>>(zapatilla).ToPagedList(currentPage, pageSize);
            return View(marcaVm);

        }

        }
}
