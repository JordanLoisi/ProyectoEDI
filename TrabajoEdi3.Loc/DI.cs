using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoEdi3.Datos;
using TrabajoEdi3.Datos.Intefaces;
using TrabajoEdi3.Datos.Repositorio;
using TrabajoEdi3.Datos.UnitOfWork;
using TrabajoEdi3.Servicios.Interfaces;
using TrabajoEdi3.Servicios.Servicios;

namespace TrabajoEdi3.Loc
{
    public static class DI
    {
        public static IServiceProvider ConfigurarServicios()
        {
            var servicios = new ServiceCollection();
            //Repositorios y sus interface
            servicios.AddScoped<IDeporteRepositorio,
                RepositorioDeporte>();
            servicios.AddScoped<IMarcaRepositorio,
                RepositorioMarca>();
            servicios.AddScoped<IColorRepositorio, RepositorioColor>();
            servicios.AddScoped<IGeneroRepositorio,
                RepositorioGenero>();
            servicios.AddScoped<IZapatillasRepositorio, RepositorioZapatillas>();
            servicios.AddScoped<ITallesRepositores,RepositorioTalles>();

            //Servicios y sus Intefaces
            servicios.AddScoped<IServicioMarca,
                ServiciosMarca>();
            servicios.AddScoped<IServicioDeporte, ServicioDeporte>();
            servicios.AddScoped<IServicioColor, ServicioColor>();
            servicios.AddScoped<IServicioGenero, ServicioGenero>();
            servicios.AddScoped<IServicioZapatilla, ServicioZapatilla>();
            servicios.AddScoped<ITallesServicio, ServicioTalles>();

            servicios.AddScoped<IUnitOfWork, UnitOfWork>();
            servicios.AddDbContext<DbContex>(optiones =>
            {
                optiones.UseSqlServer(@"Data Source=.; 
                        Initial Catalog=TrabajoPracticoEDI3; 
                        Trusted_Connection=true; 
                        TrustServerCertificate=true;");
            });

            return servicios.BuildServiceProvider();
        }
    }
}



