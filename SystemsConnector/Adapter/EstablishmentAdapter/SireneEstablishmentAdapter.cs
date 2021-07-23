using Nito.AsyncEx.Synchronous;
using System;
using System.Net.Http;
using System.Text.Json;
using SystemsConnector.Adapter.HttpClient.SireneApi;
using SystemsConnector.Model.SireneApiModel;

namespace SystemsConnector.Adapter.EstablishmentAdapter
{
    /// <summary>
    /// Récupère les données d'un établissement depuis l'api Sirene.fr, via un numéro de SIRET/SIREN, sous forme d'objet
    /// puis mappe cet objet provenant de l'api à un objet interne de type "Establishement"
    /// </summary>
    class SireneEstablishmentAdapter : BaseAdapter<Establishment>
    {
        /// <summary>
        /// Retourne un objet de type "Establishment", après avoir fetch l'api Sirene.fr et exécuté le mappage de l'objet
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override Establishment Get(string id)
        {
            SireneApiClient sireneApiClient = new (EnvironmentVariable.DefineSireneApiBaseUrl(id), EnvironmentVariable.SIRENE_API_KEY);
            var response = sireneApiClient.Get(id).WaitAndUnwrapException();
            return BuildEStablishementList(response);
        }

        /// <summary>
        /// Méthode requise par l'héritage, mais inutile dans le contexte de l'api Sirene.fr
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override void Create(Establishment obj)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Mappe et retourne l'objet "establishment" depuis l'objet fetché de l'api Sirene.fr
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        private static Establishment BuildEStablishementList(HttpResponseMessage response)
        {
            var responseString = response.Content.ReadAsStringAsync().Result;
            var objectResult = JsonSerializer.Deserialize<EstablishmentGroup>(responseString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            Establishment establishment = SelectEstablishmentType(objectResult);
            return establishment;
        }

        /// <summary>
        /// Détermine si l'objet de type "EstablishmentGroup" contient un ou plusieurs établissements
        /// </summary>
        /// <param name="objectResult"></param>
        /// <returns></returns>
        private static Establishment SelectEstablishmentType(EstablishmentGroup objectResult)
        {
            if (objectResult.Etablissement == null)
            {
                return objectResult.Etablissements;
            }
            else
            {
                return objectResult.Etablissement;
            }
        }
    }
}
