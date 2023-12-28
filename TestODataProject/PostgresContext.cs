using Microsoft.EntityFrameworkCore;

namespace TestODataProject
{
    public class PostgresContext : DbContext
    {
        private readonly IConfiguration config;

        public PostgresContext(DbContextOptions<PostgresContext> options, IConfiguration config) : base(options)
        {
            this.config = config;
        }

        public DbSet<ChemicalPriceAndEconomics> ChemicalPriceAndEconomics { get; set; }

        public DbSet<ChemicalMasPricesProduct> ChemicalMasPricesProduct { get; set; }

        public DbSet<Mas> Mas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ChemicalPriceAndEconomics>()
                .HasMany(d => d.observations)
                .WithOne(d => d.ChemicalPriceAndEconomics)
                .HasForeignKey(b => b.source_id);

            modelBuilder.Entity<ObservationMas>(entity =>
            {
                entity.HasKey(e => new { e.source_id, e.date });
            });
        }
    }
}
