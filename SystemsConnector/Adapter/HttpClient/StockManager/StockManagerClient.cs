using DataTransfertObject;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using SystemsConnector.Util;

namespace SystemsConnector.Adapter.HttpClient.GestionnaireDeStockApp
{
    /// <summary>
    /// Définie les endpoints à partir d'une base url pour StockManager
    /// </summary>
    public class StockManagerClient : BaseClient<Company>
    {
        /// <summary>
        /// Surchage du constructeur qui prend en paramètre la base url et un l'endpoint
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <param name="endPoint"></param>
        public StockManagerClient(string baseUrl, string endPoint) : base(baseUrl, endPoint) { }

        /// <summary>
        /// Surchage du constructeur qui prend en paramètre la base url uniquement
        /// </summary>
        /// <param name="baseUrl"></param>
        public StockManagerClient(string baseUrl) : base(baseUrl) { }

        /// <summary>
        /// Retourne l'objet récupéré de StockManager
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override Task<HttpResponseMessage> Get(string id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Envoi de l'objet "company" vers StockManager
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        public override async Task<HttpResponseMessage> Post(Company company)
        {
            var content = JsonConvert.SerializeObject(company);

            HttpRequestMessage request = new()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(BaseUrl),
                Content = new StringContent(content, Encoding.UTF8, "application/json")
            };

            var client = HttpClientBaseUrl.NewHttpClient(BaseUrl);
            var response = await client.SendAsync(request);

            return response;
        }
    }
}
