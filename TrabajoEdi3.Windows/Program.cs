using Microsoft.Extensions.DependencyInjection;
using TrabajoEdi3.Loc;

namespace TrabajoEdi3.Windows
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

             var serviceProvider = DI.ConfigurarServicios();
            
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new FrmPrincipal(serviceProvider));
        }
    }
}