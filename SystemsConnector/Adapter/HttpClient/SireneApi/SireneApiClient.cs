using System;
using System.Net.Http;
using System.Threading.Tasks;
using SystemsConnector.Model.SireneApiModel;
using SystemsConnector.Util;

namespace SystemsConnector.Adapter.HttpClient.SireneApi
{
    /// <summary>
    /// Définie les endpoints à partir d'une base url pour l'api Sirene.fr
    /// </summary>
    public class SireneApiClient : BaseClient<Establishment>
    {
        /// <summary>
        /// Surchage du constructeur qui prend en paramètre la base url et un l'endpoint
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <param name="token"></param>
        public SireneApiClient(string baseUrl, string token) 
            : base(baseUrl, token) { }

        /// <summary>
        /// Retourne l'objet récupéré de l'api Sirene
        /// </summary>
        /// <param name="siretOrSiren"></param>
        /// <returns></returns>
        public override async Task<HttpResponseMessage> Get(string siretOrSiren)
        {
            var client = HttpClientBaseUrl.NewHttpClient(BaseUrl, Token);
            var response = await client.GetAsync(BaseUrl);
            return response;
        }

        /// <summary>
        /// Méthode requise pour l'implémentation de "BaseClient", mais on ne peut pas POST vers l'api Sirene
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override Task<HttpResponseMessage> Post(Establishment establishment)
        {
            throw new NotImplementedException();
        }
    }
}
