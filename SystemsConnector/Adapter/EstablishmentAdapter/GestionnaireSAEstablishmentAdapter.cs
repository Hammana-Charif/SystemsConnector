using DataTransfertObject;
using System;
using SystemsConnector.Adapter.HttpClient.GestionnaireDeStockApp;
using SystemsConnector.Model.SireneApiModel;

namespace SystemsConnector.Adapter.EstablishmentAdapter
{
    /// <summary>
    /// Permet d'adapter les objets "establishment" et "company", l'un à l'autre, 
    /// après récupération depuis, ou pour envoi vers : GestionnaireDeStockApp
    /// </summary>
    class GestionnaireSAEstablishmentAdapter : BaseAdapter<Establishment>
    {
        /// <summary>
        /// Renvoi un objet de type "Establishment" après l'avoir mappé depuis un objet "company" provenant de GestionnaireDeStockApp
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override Establishment Get(string id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Exécute la méthode de mappage de l'objet "company", puis l'envoi dans GestionnaireDeStockApp
        /// </summary>
        /// <param name="establishment"></param>
        public override void Create(Establishment establishment)
        {
            var company = BuildDTOCompany(establishment);
            GestionnaireSAClient gestionnaireDeStockAppAdapter = new(EnvironmentVariable.GESTIONNAIRESTOCKAPP_API_BASE_URL);
            gestionnaireDeStockAppAdapter.Post(company).Wait();
        }

        /// <summary>
        /// Mappe l'objet "establishment" à l'objet "company" 
        /// </summary>
        /// <param name="establishment"></param>
        /// <returns></returns>
        private static Company BuildDTOCompany(Establishment establishment)
        {
            if (establishment == null)
                throw new Exception();

            Company company = new()
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
            };

            return company;
        }
    }
}

