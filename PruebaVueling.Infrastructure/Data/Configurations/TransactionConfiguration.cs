using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PruebaVueling.Core.Entities;

namespace PruebaVueling.Infrastructure.Data.Configurations
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transactions>
    {
        public void Configure(EntityTypeBuilder<Transactions> builder)
        {
            builder.HasNoKey();

                builder.ToTable("transactions");

                builder.Property(e => e.Aomunt)
                    .HasColumnName("aomunt")
                    .HasColumnType("decimal(18, 0)");

                builder.Property(e => e.Currency)
                    .HasColumnName("currency")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                builder.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                builder.Property(e => e.Sku)
                    .HasColumnName("sku")
                    .HasMaxLength(5)
                    .IsUnicode(false);
        }
    }
}
