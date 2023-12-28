namespace TestODataProject
{
    public class ChemicalPriceAndEconomicsService
    {
        private readonly PostgresContext _database;

        public ChemicalPriceAndEconomicsService(ILogger<ChemicalPriceAndEconomicsService> logger,
                                                 PostgresContext database,
                                                 IConfiguration? configuration)
        {                                                  
            _database = database;
        }

        public IQueryable<ChemicalPriceAndEconomics?> Get()
        {
            return _database.ChemicalPriceAndEconomics.AsQueryable();
        }
    }
}
