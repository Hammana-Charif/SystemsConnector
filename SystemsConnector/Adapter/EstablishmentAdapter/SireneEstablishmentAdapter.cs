using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using SystemsConnector.Adapter.HttpClient.SireneApi;
using SystemsConnector.Model.SireneApiModel;
using SystemsConnector.Util;

namespace SystemsConnector.Adapter.EstablishmentAdapter
{
    /// <summary>
    /// Récupère les données d'un établissement depuis l'api Sirene.fr, via un numéro de SIRET/SIREN, sous forme d'objet
    /// puis mappe cet objet provenant de l'api à un objet interne de type "Establishement"
    /// </summary>
    public class SireneEstablishmentAdapter : BaseAdapter<Task<HttpResponseMessage>>
    {
        /// <summary>
        /// Retourne un objet de type "Establishment", après avoir fetch l'api Sirene.fr et exécuté le mappage de l'objet
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override async Task<HttpResponseMessage> Get(string id)
        {
            SireneApiClient sireneApiClient = new (
                EnvironmentVariable.DefineSireneApiBaseUrl(id), 
                EnvironmentVariable.GetAnApiKey(ApiKeys.SireneKey)
                );
            return await sireneApiClient.Get(id);
        }

        /// <summary>
        /// Méthode requise par l'héritage, mais inutile dans le contexte de l'api Sirene.fr
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override Task<HttpResponseMessage> Create()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Mappe et retourne l'objet "establishment" depuis l'objet fetché de l'api Sirene.fr
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public static EstablishmentGroup BuildEStablishementGroup(HttpResponseMessage response)
        {
            var responseString = response.Content.ReadAsStringAsync().Result;
            var establishmentGroup = JsonSerializer.Deserialize<EstablishmentGroup>(
                responseString, 
                new JsonSerializerOptions 
                { 
                    PropertyNameCaseInsensitive = true 
                });
            return establishmentGroup;
        }
    }
}
