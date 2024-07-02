using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoEdi3.Servicios.Interfaces;

namespace TrabajoEdi3.Windows.Helpers
{
    public class ListBoxHelpers
    {
        private static IServiceProvider? _serviceProvider;
        public static void CargarDatosListBoxTalles(IServiceProvider? serviceProvider,
            ref CheckedListBox lst)
        {
            _serviceProvider = serviceProvider;
            ITallesServicio? servicio = _serviceProvider?
                    .GetService<ITallesServicio>();
            var lista = servicio?.GetLista();
            if (lista != null)
            {

                foreach (var talles in lista)
                {
                    lst.Items.Add(talles);
                }
                lst.DisplayMember = "Numero";
            }
        }
    }
}
