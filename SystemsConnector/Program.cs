using SystemsConnector.Adapter.EstablishmentAdapter;
using SystemsConnector.Factory;

namespace SystemsConnector
{
    static class Program
    {
        static void Main(string[] args)
        {
            EstablishmentAdapterFactory establishmentAdapterFactory = new();
            var sireneAdapter = establishmentAdapterFactory.Fabricate(SystemType.Sirene);
            var gestionnaireStockApp = establishmentAdapterFactory.Fabricate(SystemType.StockManager);

            //var response = sireneAdapter.Get("42878504200105");
            var response = sireneAdapter.Get("380129866");

            var establishmentGroup = SireneEstablishmentAdapter.BuildEStablishementGroup(response.Result);
            StockManagerEstablishmentAdapter.Company = StockManagerEstablishmentAdapter.BuildDTOCompany(establishmentGroup)[2];
            gestionnaireStockApp.Create().Wait();
        }
    }
}
