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
    [ApiController]
    [Route("[controller]")]
    public class CalculaJurosController : ControllerBase
    {
        public IConfiguration Configuration { get; }

        public CalculaJurosController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

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
