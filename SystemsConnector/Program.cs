using SystemsConnector.Factory;

namespace SystemsConnector
{
    class Program
    {
        static void Main(string[] args)
        {
            EstablishmentAdapterFactory establishmentAdapterFactory = new();
            var sireneAdapter = establishmentAdapterFactory.Fabricate(SystemType.Sirene);
            var gestionnaireStockApp = establishmentAdapterFactory.Fabricate(SystemType.GestionnaireDeStockApp);

            var establishment = sireneAdapter.Get("34798980800568");
            gestionnaireStockApp.Create(establishment);          
        }
    }
}
