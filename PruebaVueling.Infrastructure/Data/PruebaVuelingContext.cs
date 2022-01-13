using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PruebaVueling.Core.Entities;

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
            modelBuilder.Entity<Rates>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("rates");

                entity.Property(e => e.From)
                    .HasColumnName("from")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Rate)
                    .HasColumnName("rate")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.To)
                    .HasColumnName("to")
                    .HasMaxLength(3)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Transactions>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("transactions");

                entity.Property(e => e.Aomunt)
                    .HasColumnName("aomunt")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Currency)
                    .HasColumnName("currency")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Sku)
                    .HasColumnName("sku")
                    .HasMaxLength(5)
                    .IsUnicode(false);
            });


        }
    }
}
