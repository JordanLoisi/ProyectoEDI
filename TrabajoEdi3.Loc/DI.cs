using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
        public static void ConfigurarServicios(IServiceCollection services, IConfiguration configuration)
        {
            //Repositorios y sus interface
            services.AddScoped<IMarcaRepositorio,
                RepositorioMarca>();
            services.AddScoped<IDeporteRepositorio,RepositorioDeporte>();
            services.AddScoped<IColorRepositorio, RepositorioColor>();
            services.AddScoped<IGeneroRepositorio, RepositorioGenero>();
            services.AddScoped<ITallesRepositores, RepositorioTalles>();
            //Servicios y sus Intefaces
            services.AddScoped<IServicioMarca,
                ServiciosMarca>();
            services.AddScoped<IServicioDeporte, ServicioDeporte>();
            services.AddScoped<IServicioColor, ServicioColor>();
            services.AddScoped<IServicioGenero, ServicioGenero>();
            services.AddScoped<ITallesServicio, ServicioTalles>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<DbContex>(optiones =>
            {
                optiones.UseSqlServer(configuration.GetConnectionString("MyConn"));
            });

        }
    }
}



