using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain
{
    public class Investimento
    {
        readonly double valorInicial;
        readonly int meses;
        readonly IJurosProvider jurosProvider;

        public Investimento(double valorInicial,
                     int meses,
                     IJurosProvider jurosProvider)
        {
            this.valorInicial = valorInicial;
            this.meses = meses;
            this.jurosProvider = jurosProvider;
        }

        public double CalcularValorFinal()
        {
            double juros;

            try
            {
                juros = jurosProvider.ObterTaxaJuros();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Não foi possível obter a taxa de juros.", ex);
            }

            this.Validar();

            return valorInicial * Math.Pow(1 + juros, meses);
        }

        private void Validar()
        {
            this.ValidarValorInicial();
            this.ValidarMeses();
        }

        private void ValidarValorInicial()
        {
            if (this.valorInicial <= 0)
            {
                throw new ApplicationException("Valor inicial deve ser maior que zero.");
            }
        }

        private void ValidarMeses()
        {
            if (this.meses <= 0)
            {
                throw new ApplicationException("Meses deve ser maior que zero.");
            }
        }
    }
}
