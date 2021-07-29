using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShowMeTheCodeController : ControllerBase
    {
        public IConfiguration Configuration { get; }

        public ShowMeTheCodeController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Retonar o endereço do repositório no Github.
        /// </summary>
        /// <returns>Endereço do repositório Github</returns>
        [HttpGet]
        public string Get()
        {
            return Configuration["AplicationConfig:Github"];
        }
    }
}
