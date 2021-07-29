using Core.Domain;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi2.Presentation;
using WebApi2.Providers;

namespace WebApi2.Controllers
{
    /// <summary>
    /// Cálculo de juros
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class CalculaJurosController : ControllerBase
    {
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Construtor da classe.
        /// </summary>
        /// <param name="configuration"></param>
        public CalculaJurosController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Calcula o valor final aplicando juros compostos a partir de um valor inicial e a quantidade de meses que
        /// o valor irá render.
        /// </summary>
        /// <param name="valorInicial">Valor inicial onde serão aplicados os juros.</param>
        /// <param name="meses">Quantidade de meses que o valor inicial irá render.</param>
        /// <returns>Valor final com os juros compostos aplicados.</returns>
        [HttpGet]
        public IActionResult Get(double valorInicial, int meses)
        {
            double jurosResultado;
            try
            {
                IJurosProvider jurosProvider = new JurosProviderWebApi1(Configuration["AplicationConfig:UrlTaxaJuros"]);
                Investimento juros = new Investimento(valorInicial, meses, jurosProvider);

                jurosResultado = juros.CalcularValorFinal();
            }
            catch(ApplicationException aEx)
            {
                // TODO: Logar
                return StatusCode(400, aEx.Message);
            }
            catch (Exception)
            {
                // TODO: Logar
                // Engolindo Exception para evitar que detalhes de implementação sejam vazadaos para terceiros
                return StatusCode(500, "Houve um erro e não foi possível concluir o cálculo.");
            }

            return StatusCode(200, JurosCalculoPresentation.Fomartar(jurosResultado));
        }
    }
}
