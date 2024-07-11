using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoEdi3.Entidades;

namespace TrabajoEdi3.Windows.Helpers
{
    public static  class FiltroHelper
    {
        public static Func<Zapatilla, bool> And(this Func<Zapatilla, bool> first, Func<Zapatilla, bool> second)
        {
            return filtro => first(filtro) && second(filtro);
        }
        public static Func<Zapatilla, bool> Not(this Func<Zapatilla, bool> filtro)
        {
            return filter => !filtro(filter);
        }

    }
}
