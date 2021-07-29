using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Tests.Mocks
{
    public class JurosProviderOk : IJurosProvider
    {
        public double ObterTaxaJuros()
        {
            return 0.01;
        }
    }
}
