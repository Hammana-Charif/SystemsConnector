using DataTransfertObject;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using SystemsConnector.Adapter.HttpClient.GestionnaireDeStockApp;
using SystemsConnector.Model.SireneApiModel;
using SystemsConnector.Util;

namespace SystemsConnector.Adapter.EstablishmentAdapter
{
    /// <summary>
    /// Permet d'adapter les objets "establishment" et "company", l'un à l'autre, 
    /// après récupération depuis, ou pour envoi vers : StockManager
    /// </summary>
    public class StockManagerEstablishmentAdapter : BaseAdapter<Task<HttpResponseMessage>>
    {
        public static List<Company> CompanyList { get; set; }
        public static Company Company { get; set; }

        /// <summary>
        /// Renvoi un objet de type "Establishment" après l'avoir mappé depuis un objet "company" provenant de StockManager
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override Task<HttpResponseMessage> Get(string id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Exécute la méthode de mappage de l'objet "company", puis l'envoi dans StockManager
        /// </summary>
        /// <param name="establishment"></param>
        public override async Task<HttpResponseMessage> Create()
        {
            StockManagerClient stockManagerClient = new(EnvironmentVariable.DefineStockManagerApiBaseUrl(StockManagerEndPoints.Companies));
            return await stockManagerClient.Post(Company);
        }

        /// <summary>
        /// Mappe l'objet "establishment" à l'objet "company" 
        /// </summary>
        /// <param name="establishmentList"></param>
        /// <returns></returns>
        public static List<Company> BuildDTOCompany(EstablishmentGroup establishmentGroup)
        {
            CompanyList = new List<Company>();
            CompanyList.Clear();

            var establishmentList = SelectEstablishmentType(establishmentGroup);

            establishmentList.ForEach( establishment =>
                       CompanyList.Add(
                           new Company()
                           {
                               Siren = establishment.Siren,
                               Nic = establishment.Nic,
                               DateCreationEtablissement = establishment.DateCreationEtablissement,
                               DenominationUniteLegale = establishment.UniteLegale.DenominationUniteLegale,
                               ActivitePrincipaleUniteLegale = establishment.UniteLegale.ActivitePrincipaleUniteLegale,
                               NomenclatureActivitePrincipaleUniteLegale = establishment.UniteLegale.NomenclatureActivitePrincipaleUniteLegale,
                               SigleUniteLegale = establishment.UniteLegale.SigleUniteLegale,
                               CategorieJuridiqueUniteLegale = establishment.UniteLegale.CategorieJuridiqueUniteLegale,
                               TrancheEffectifsUniteLegale = establishment.UniteLegale.TrancheEffectifsUniteLegale,
                               AdresseEtablissement = new()
                               {
                                   NumeroVoieEtablissement = establishment.AdresseEtablissement.NumeroVoieEtablissement,
                                   TypeVoieEtablissement = establishment.AdresseEtablissement.TypeVoieEtablissement,
                                   LibelleVoieEtablissement = establishment.AdresseEtablissement.LibelleVoieEtablissement,
                                   LibelleCommuneEtablissement = establishment.AdresseEtablissement.LibelleCommuneEtablissement,
                                   CodeCommuneEtablissement = establishment.AdresseEtablissement.CodeCommuneEtablissement,
                                   LibellePaysEtrangerEtablissement = establishment.AdresseEtablissement.LibellePaysEtrangerEtablissement ?? "FRANCE"
                               }
                           })
            );

            return CompanyList;
        }

        /// <summary>
        /// Détermine si l'objet de type "EstablishmentGroup" contient un ou plusieurs établissements
        /// </summary>
        /// <param name="objectResult"></param>
        /// <returns></returns>
        private static List<Establishment> SelectEstablishmentType(EstablishmentGroup establishmentGroup)
        {
            List<Establishment> establishmentList = new();

            if (establishmentGroup.Etablissement == null)
            {
                return establishmentGroup.Etablissements;
            }
            else
            {
                establishmentList.Add(establishmentGroup.Etablissement);
                return establishmentList;
            }
        }
    }
}

