using Core.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApi2.Providers
{
    public class JurosProviderWebApi1 : IJurosProvider
    {
        private string Path { get; set; }

        public JurosProviderWebApi1(string path)
        {
            this.Path = path;
        }

        public double ObterTaxaJuros()
        {
            return BuscarTaxaJuros().Result;
        }

        public async Task<double> BuscarTaxaJuros()
        {
            TaxaJuros taxaJuros = null;

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(this.Path);

            if (response.IsSuccessStatusCode)
            {
                taxaJuros = JsonConvert.DeserializeObject<TaxaJuros>(response.Content.ReadAsStringAsync().Result);
            }
            else
            {
                throw new ApplicationException("Não foi possível obter taxa de juros.");
            }

            return taxaJuros.Valor;
        }
    }
}
