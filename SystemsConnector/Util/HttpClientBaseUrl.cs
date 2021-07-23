using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace SystemsConnector.Util
{
    /// <summary>
    /// Défini la base url, le token et les headers pour la requête à envoyer
    /// </summary>
    class HttpClientBaseUrl
    {
        /// <summary>
        /// Défini la base url, le token et les headers pour la requête à envoyer
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <returns></returns>
        public static HttpClient NewHttpClient(string baseUrl, string token)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(baseUrl)
            };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
                );
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return client;
        }

        /// <summary>
        /// Surcharge de la méthode qui défini la base url et les headers pour la requête à envoyer, sans le token
        /// Méthode amenée à disparaître, quand les credentials et token seront mis en place pour l'api GestionnaireDeStockApp
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <returns></returns>
        public static HttpClient NewHttpClient(string baseUrl)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(baseUrl)
            };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
                );
            return client;
        }
    }
}
