using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PruebaVueling.Data.Entities;

namespace PruebaVueling.Infrastructure.Data.Configurations
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transactions>
    {
        public void Configure(EntityTypeBuilder<Transactions> builder)
        {


            builder.ToTable("transactions");

            builder.HasKey(e => e.Id).HasName("id");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.Amount)
                .HasColumnName("amount")
                .HasColumnType("float(53)");

            builder.Property(e => e.Currency)
                    .HasColumnName("currency")
                    .HasMaxLength(3)
                    .IsUnicode(false);

            builder.Property(e => e.Sku)
                .HasColumnName("sku")
                .HasMaxLength(5)
                .IsUnicode(false);
        }
    }
}
