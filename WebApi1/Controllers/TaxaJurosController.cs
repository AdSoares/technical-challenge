using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi1.Domain;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaxaJurosController : ControllerBase
    {
        /// <summary>
        /// Retorna a taxa de juros aplicável.
        /// </summary>
        /// <returns>Valor da taxa de juros a ser aplicada.</returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new TaxaJuros());
        }
    }
}
