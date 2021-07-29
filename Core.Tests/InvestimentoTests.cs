using Core.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Core.Tests
{
    [TestClass]
    public class InvestimentoTests
    {
        [TestMethod]
        public void Calcular_juros_cenario_do_criterio_de_aceite()
        {
            const double VALOR_INICIAL = 100;
            const int MESES = 5;
            const double TOLERANCIA = 0.005;
            const double VALOR_ESPERADO = 105.1;

            Investimento investimento = new Investimento(VALOR_INICIAL, MESES, new Mocks.JurosProviderOk());

            Assert.AreEqual(investimento.CalcularValorFinal(), VALOR_ESPERADO, TOLERANCIA);
        }

        [TestMethod]
        public void Calcular_juros_com_valores_maximos_de_entrada()
        {
            const double VALOR_INICIAL = double.MaxValue;
            const int MESES = int.MaxValue;

            Investimento investimento = new Investimento(VALOR_INICIAL, MESES, new Mocks.JurosProviderOk());

            var resultado = investimento.CalcularValorFinal();
            Assert.IsTrue(double.IsInfinity(resultado));
        }

        [TestMethod]
        public void Calcular_juros_com_valores_minimos_de_entrada()
        {
            const double VALOR_INICIAL = 1;
            const int MESES = 1;
            const double TOLERANCIA = 0.005;
            const double VALOR_ESPERADO = 1.01;

            Investimento investimento = new Investimento(VALOR_INICIAL, MESES, new Mocks.JurosProviderOk());

            var resultado = investimento.CalcularValorFinal();
            Assert.AreEqual(resultado, VALOR_ESPERADO, TOLERANCIA);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException), "Está aceitando fazer cálculo com valor inicial zerado.")]
        public void Nao_aceita_valor_inicial_menor_que_zero()
        {
            const double VALOR_INICIAL = 0;
            const int MESES = 5;

            Investimento investimento = new Investimento(VALOR_INICIAL, MESES, new Mocks.JurosProviderOk());
            var resultado = investimento.CalcularValorFinal();
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException), "Está aceitando fazer cálculo com meses zerado.")]
        public void Nao_aceita_meses_menor_que_zero()
        {
            const double VALOR_INICIAL = 100;
            const int MESES = 0;

            Investimento investimento = new Investimento(VALOR_INICIAL, MESES, new Mocks.JurosProviderOk());
            var resultado = investimento.CalcularValorFinal();
        }
    }
}
