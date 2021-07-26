using System;

namespace SystemsConnector
{
    /// <summary>
    /// 
    /// </summary>
    static class EnvironmentVariable
    {
        public const string SIRENE_API_KEY = ""; //constante pour le token
        public const string GESTIONNAIRESTOCKAPP_API_BASE_URL = "http://localhost:51822/api/companies"; // constante pour la base url pour le système GestionnaireDeStockApp
        private const string SIRENE_API_BASE_URL = "https://api.insee.fr/entreprises/sirene/V3"; //constante pour la base url de l'api INSEE Sirene.fr

        /// <summary>
        /// Renvoi la bonne url en fonction de la longueur de saisie du numéro de recherche (SIRET ou SIREN)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string DefineSireneApiBaseUrl(string id)
        {
            return id.Length switch
            {
                9 => $"{SIRENE_API_BASE_URL}/siren/",
                14 => $"{SIRENE_API_BASE_URL}/siret/",
                _ => throw new InvalidOperationException("URL non prise en charge"),
            };
        }
    }
}
