using System;
using SystemsConnector.Util;

namespace SystemsConnector
{
    /// <summary>
    /// 
    /// </summary>
    public static class EnvironmentVariable
    {
        private const string SIRENE_API_KEY = "3167a134-28df-3b47-bd1c-f658937d8cec"; //constante pour le token Sirene.fr
        private const string STOCKMANAGER_API_BASE_URL = "http://localhost:41896/api"; // constante pour la base url pour le système StockManager
        private const string SIRENE_API_BASE_URL = "https://api.insee.fr/entreprises/sirene/V3/siret"; //constante pour la base url de l'api INSEE Sirene.fr

        /// <summary>
        /// Renvoi la bonne url en fonction de la longueur de saisie du numéro de recherche (SIRET ou SIREN)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string DefineSireneApiBaseUrl(string id)
        {
            return id.Length switch
            {
                9 => $"{SIRENE_API_BASE_URL}/?q=siren:{id}",
                14 => $"{SIRENE_API_BASE_URL}/{id}",
                _ => throw new InvalidOperationException("URL non prise en charge")
            };
        }

        /// <summary>
        /// Renvoi le bon token en fonction du type énuméré "ApiKeys"
        /// </summary>
        /// <param name="apiKeys"></param>
        /// <returns></returns>
        public static string GetAnApiKey(ApiKeys apiKeys)
        {
            return apiKeys switch
            {
                ApiKeys.SireneKey => $"{SIRENE_API_KEY}",
                _ => throw new InvalidOperationException("Token non prise en charge"),
            };
        }

        /// <summary>
        /// Renvoi la bonne url en fonction du endpoint défini via le type énuméré "StockManagerEndPoints"
        /// </summary>
        /// <param name="stockManagerEndPoints"></param>
        /// <returns></returns>
        public static string DefineStockManagerApiBaseUrl(StockManagerEndPoints stockManagerEndPoints)
        {
            return stockManagerEndPoints switch
            {
                StockManagerEndPoints.Companies => $"{STOCKMANAGER_API_BASE_URL}/companies",
                StockManagerEndPoints.Invoices => $"{STOCKMANAGER_API_BASE_URL}/invoices",
                StockManagerEndPoints.Products => $"{STOCKMANAGER_API_BASE_URL}/products",
                StockManagerEndPoints.Users => $"{STOCKMANAGER_API_BASE_URL}/users",
                _ => throw new InvalidOperationException("URL non prise en charge")
            };
        }
    }
}
