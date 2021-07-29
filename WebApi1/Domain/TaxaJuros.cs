using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi1.Domain
{
    public class TaxaJuros
    {
        private const double TAXA_PADRAO = 0.01;

        public double Valor { get; set; }

        public TaxaJuros()
        {
            this.Valor = TAXA_PADRAO;
        }
    }
}
