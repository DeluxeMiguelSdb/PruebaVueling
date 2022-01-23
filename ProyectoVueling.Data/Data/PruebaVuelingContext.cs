using Microsoft.EntityFrameworkCore;
using PruebaVueling.Data.Entities;
using PruebaVueling.Infrastructure.Data.Configurations;

namespace PruebaVueling.Infrastructure.Data
{
    public partial class PruebaVuelingContext : DbContext
    {
        public PruebaVuelingContext()
        {
        }

        public PruebaVuelingContext(DbContextOptions<PruebaVuelingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Rates> Rates { get; set; }
        public virtual DbSet<Transactions> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RateConfiguration());

            modelBuilder.ApplyConfiguration(new TransactionConfiguration());


        }
    }
}
