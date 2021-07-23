using System;
using SystemsConnector.Adapter;
using SystemsConnector.Adapter.EstablishmentAdapter;
using SystemsConnector.Model.SireneApiModel;

namespace SystemsConnector.Factory
{
    /// <summary>
    /// Fabrique des adapters pour l'entité "Establishment"
    /// </summary>
    class EstablishmentAdapterFactory : BaseFactory<Establishment>
    {
        /// <summary>
        /// Renvoi un adapter
        /// </summary>
        /// <param name="systemType"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override IAdapter<Establishment> Fabricate(SystemType systemType)
        {
            return systemType switch
            {
                SystemType.Sirene => new SireneEstablishmentAdapter(),
                SystemType.GestionnaireDeStockApp => new GestionnaireSAEstablishmentAdapter(),
                _ => throw new InvalidOperationException("Adapter non pris en charge"),
            };
        }
    }
}
