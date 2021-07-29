using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi2.Presentation
{
    public static class JurosCalculoPresentation
    {
        public static string Fomartar(double valor)
        {
            return string.Format(new CultureInfo("pt-BR"), "{0:0,0.00}", valor);
        }
    }
}
