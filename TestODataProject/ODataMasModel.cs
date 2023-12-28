using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

namespace TestODataProject
{
    public static class ODataMasModel
    {
        private static readonly List<string> MasNames = new List<string>()
        {
            nameof(ChemicalPriceAndEconomics),
            nameof(Mas)
        };

        public static void AddMasModels(this ODataModelBuilder modelBuilder)
        {
            modelBuilder.EntitySet<ChemicalPriceAndEconomics>(nameof(ChemicalPriceAndEconomics)).HasCountRestrictions().IsCountable(true);
            modelBuilder.EntitySet<ChemicalMasPricesProduct>(nameof(ChemicalMasPricesProduct)).HasCountRestrictions().IsCountable(true);
            modelBuilder.EntitySet<Mas>(nameof(Mas)).HasCountRestrictions().IsCountable(true);
        }

        public static void AddMasNavigationLinks(this IEdmModel edmModel)
        {
            edmModel.AddNavigationLinks(MasNames);
        }
    }
}
