using System;
using System.Net.Http;
using System.Threading.Tasks;
using SystemsConnector.Adapter;
using SystemsConnector.Adapter.EstablishmentAdapter;

namespace SystemsConnector.Factory
{
    /// <summary>
    /// Fabrique des adapters pour l'entité "Establishment"
    /// </summary>
    public class EstablishmentAdapterFactory : BaseFactory<Task<HttpResponseMessage>>
    {
        /// <summary>
        /// Renvoi un adapter
        /// </summary>
        /// <param name="systemType"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override IAdapter<Task<HttpResponseMessage>> Fabricate(SystemType systemType)
        {
            return systemType switch
            {
                SystemType.Sirene => new SireneEstablishmentAdapter(),
                SystemType.StockManager => new StockManagerEstablishmentAdapter(),
                _ => throw new InvalidOperationException("Adapter non pris en charge"),
            };
        }
    }
}
