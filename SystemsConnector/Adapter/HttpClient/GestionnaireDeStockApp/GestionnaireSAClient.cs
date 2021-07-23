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
    /// Définie les endpoints à partir d'une base url pour GestionnaireDeStockApp
    /// </summary>
    class GestionnaireSAClient : BaseClient<Company>
    {
        /// <summary>
        /// Surchage du constructeur qui prend en paramètre la base url et un l'endpoint
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <param name="endPoint"></param>
        public GestionnaireSAClient(string baseUrl, string endPoint) : base(baseUrl, endPoint) { }

        /// <summary>
        /// Surchage du constructeur qui prend en paramètre la base url uniquement
        /// </summary>
        /// <param name="baseUrl"></param>
        public GestionnaireSAClient(string baseUrl) : base(baseUrl) { }

        /// <summary>
        /// Retourne l'objet récupéré de GestionnaireDeStockApp
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        public override Task<HttpResponseMessage> Get(string id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Renvoi le réponse de l'envoi de l'objet "company" vers GestionnaireDeStockApp
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        public override async Task<HttpResponseMessage> Post(Company company)
        {
            var content = JsonConvert.SerializeObject(company);

            HttpRequestMessage request = new(HttpMethod.Post, EndPoint)
            {
                Content = new StringContent(content, Encoding.UTF8, "application/json")
            };

            var client = HttpClientBaseUrl.NewHttpClient(BaseUrl);
            var response = await client.SendAsync(request);

            return response;
        }
    }
}
