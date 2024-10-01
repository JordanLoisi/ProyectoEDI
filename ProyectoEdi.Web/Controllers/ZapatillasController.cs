using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Design;
using ProyectoEdi.Web.Views_Model.Zapatillas;
using System.Drawing;
using TrabajoEdi3.Datos;
using TrabajoEdi3.Entidades;
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
       



        public ZapatillasController(IServicioZapatilla servicio, IServicioMarca servicioMarca, IServicioDeporte servicioDeporte,
            IServicioGenero servicioGenero, IServicioColor servicioColor, IMapper mapper, DbContex dbContex)
        {
            _servicio = servicio ?? throw new ApplicationException("Dependencies not set"); ;
            _marcaServicio = servicioMarca ?? throw new ApplicationException("Dependencies not set");
            _deporteServicio = servicioDeporte ?? throw new ApplicationException("Dependencies not set");
            _colorServicio = servicioColor ?? throw new ApplicationException("Dependencies not set");
            _generoServicio = servicioGenero ?? throw new ApplicationException("Dependencies not set");
            _mapper = mapper ?? throw new ApplicationException("Dependencies not set");
           
        }
        public IActionResult Index(int? page, int? filterMarcaId, int? filterColorId, bool viewAll = false, int pageSize = 10,
            string orderBy = "Description")
        {

            int PageNumber = page ?? 1;
            ViewBag.currentPageSize = pageSize;
            ViewBag.currentOrderBy = orderBy;
           

            var marca = _marcaServicio!.GetAll(orderBy: o => o.OrderBy(b => b.MarcaNombre))!.ToList();
            var color = _colorServicio!.GetAll(orderBy: o => o.OrderBy(c => c.ColorName))!.ToList();
            IEnumerable<Zapatilla>? zapatillas
                ;

            if (viewAll || (filterMarcaId is null && filterColorId is null))
            {
                zapatillas = _servicio?.GetAll(orderBy: o => o.OrderBy(s => s.Description),
                    propertiesNames: "Marca,Deporte,Genero,Colores");
            }
            else
            {
                if (filterMarcaId.HasValue)
                {
                    zapatillas = _servicio!.GetAll(orderBy: o => o.OrderBy(s => s.Description),
                        filter: b => b.MarcaId == filterMarcaId.Value,
                        propertiesNames: "Marca,Deporte,Genero,Colores");
                }
                else if (filterColorId.HasValue)
                {
                    zapatillas = _servicio!.GetAll(orderBy: o => o.OrderBy(s => s.Description),
                    filter: s => s.ColoresId == filterColorId.Value,
                    propertiesNames: "Marca,Deporte,Genero,Colores");
                }
                else
                {
                    zapatillas = _servicio?.GetAll(orderBy: o => o.OrderBy(s => s.Description),
                        propertiesNames: "Marca,Deporte,Genero,Colores");
                }
            }

            var zapatillaVm = _mapper?.Map<List<ZapatillasListVm>>(zapatillas);

            if (orderBy == "Marca")
            {
                zapatillaVm = zapatillaVm!.OrderBy(b => b.Marca).ToList();
            }
            if (orderBy == "Genero")
            {
                zapatillaVm = zapatillaVm!.OrderBy(g => g.Genero).ToList();
            }
            if (orderBy == "Deporte")
            {
                zapatillaVm = zapatillaVm!.OrderBy(s => s.Deporte).ToList();
            }
            if (orderBy == "Colores")
            {
                zapatillaVm = zapatillaVm!.OrderBy(c => c.Color).ToList();
            }
            if (orderBy == "Modelo")
            {
                zapatillaVm = zapatillaVm!.OrderBy(s => s.Modelo).ToList();
            }

            var ZapatillaFilterVm = new ZapatillaFilterVm
            {
                Zapatilla = zapatillaVm!.ToPagedList(PageNumber, pageSize),
                Marca = marca.Select(b => new SelectListItem
                {
                    Text = b.MarcaNombre,
                    Value = b.MarcaId.ToString()
                }).ToList(),
               Color = color.Select(c => new SelectListItem
                {
                    Text = c.ColorName,
                    Value = c.ColorId.ToString()
                }).ToList()
            };
            return View(ZapatillaFilterVm);
        }

        public IActionResult UpSert(int? id)
        {
            ZapatillasEditVm zapatillaVm;
            if (id == null || id == 0)
            {
                zapatillaVm = new ZapatillasEditVm();
                zapatillaVm.Marca = GetMarca();
                zapatillaVm.Deporte = GetDeporte();
                zapatillaVm.Color = GetColor(); 
                zapatillaVm.Genero = GetGenero();


            }
            else
            {
                try
                {
                    Zapatilla? zapatilla = _servicio!.Get(filter: c => c.ZapatillaId == id);
                    if (zapatilla == null)
                    {
                        return NotFound();
                    }
                    zapatillaVm = _mapper!.Map<ZapatillasEditVm>(zapatilla);
                    zapatillaVm.Marca = GetMarca();
                    zapatillaVm.Deporte = GetDeporte();
                    zapatillaVm.Color = GetColor();
                    zapatillaVm.Genero = GetGenero();


                    return View(zapatillaVm);
                }
                catch (Exception)
                {
                    // Log the exception (ex) here as needed
                    return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving the record.");
                }

            }
            return View(zapatillaVm);

        }

        private List<SelectListItem> GetMarca()
        {
            return _marcaServicio!.GetAll(orderBy: o => o.OrderBy(c => c.MarcaNombre))!
            .Select(c => new SelectListItem
            {
                Text = c.MarcaNombre,
                Value = c.MarcaId.ToString()

            }).ToList();
        }
        private List<SelectListItem> GetDeporte()
        {
            return _deporteServicio!.GetAll(orderBy: o => o.OrderBy(c => c.NombreDeporte))!
          .Select(c => new SelectListItem
          {
              Text = c.NombreDeporte,
              Value = c.DeporteId.ToString()

          }).ToList();
        }
        private List<SelectListItem> GetColor()
        {
            return _colorServicio!.GetAll(orderBy: o => o.OrderBy(c => c.ColorName))!
          .Select(c => new SelectListItem
          {
              Text = c.ColorName,
              Value = c.ColorId.ToString()

          }).ToList();
        }
        private List<SelectListItem> GetGenero()
        {
            return _generoServicio!.GetAll(orderBy: o => o.OrderBy(c => c.GeneroNombre))!
           .Select(c => new SelectListItem
           {
               Text = c.GeneroNombre,
               Value = c.GeneroId.ToString()

           }).ToList();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpSert(ZapatillasEditVm zapatillaVm)
        {
            if (!ModelState.IsValid)
            {
                zapatillaVm.Marca = GetMarca();
                zapatillaVm.Deporte = GetDeporte();
                zapatillaVm.Color = GetColor();
                zapatillaVm.Genero = GetGenero();
                return View(zapatillaVm);
            }


            try
            {
                Zapatilla zapatilla = _mapper!.Map<Zapatilla>(zapatillaVm);

                if (_servicio!.Existe(zapatilla))
                {
                    ModelState.AddModelError(string.Empty, "Record already exist");
                    zapatillaVm.Marca = GetMarca();
                    zapatillaVm.Deporte = GetDeporte();
                    zapatillaVm.Color = GetColor();
                    zapatillaVm.Genero = GetGenero();

                    return View(zapatillaVm);
                }

                _servicio.Guardar(zapatilla);
                TempData["success"] = "Record successfully added/edited";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                // Log the exception (ex) here as needed
                ModelState.AddModelError(string.Empty, "An error occurred while editing the record.");
                zapatillaVm.Marca = GetMarca();
                zapatillaVm.Deporte = GetDeporte();
                zapatillaVm.Color = GetColor();
                zapatillaVm.Genero = GetGenero();

                return View(zapatillaVm);
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
            Zapatilla? zapatilla = _servicio?.Get(filter: c => c.ZapatillaId == id);
            if (zapatilla is null)
            {
                return NotFound();
            }
            try
            {
                if (_servicio!.EstaRelacionado(zapatilla.ZapatillaId))
                {
                    return Json(new { success = false, message = "Related Record... Delete Deny!!" }); ;
                }
                _servicio.Borrar(zapatilla);
                return Json(new { success = true, message = "Record successfully deleted" });
            }
            catch (Exception)
            {

                return Json(new { success = false, message = "Couldn't delete record!!! " }); ;

            }
        }
    }
}
