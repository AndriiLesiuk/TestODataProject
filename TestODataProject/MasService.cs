namespace TestODataProject
{
    public class MasService
    {
        private readonly PostgresContext _database;

        public MasService(PostgresContext database)
        {
            _database = database;
        }

        public IQueryable<Mas?> Get()
        {
            return _database.Mas.AsQueryable();
        }
    }
}
