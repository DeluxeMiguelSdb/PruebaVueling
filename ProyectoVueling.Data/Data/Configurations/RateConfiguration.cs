using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PruebaVueling.Data.Entities;

namespace PruebaVueling.Infrastructure.Data.Configurations
{
    class RateConfiguration : IEntityTypeConfiguration<Rates>
    {
        public void Configure(EntityTypeBuilder<Rates> builder)
        {
            builder.ToTable("rates");

            builder.HasKey(e => e.Id).HasName("id");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.From)
                .HasColumnName("from")
                .HasMaxLength(3)
                .IsUnicode(false);

            //builder.Property(e => e.Id)
            //    .HasColumnName("id")
            //    .ValueGeneratedOnAdd();
            //  TODO: Revisar valuegeneratedonadd. Esta presente en los rates pero no estaba en 
            //  Transactions


            builder.Property(e => e.Rate)
                .HasColumnName("rate")
                .HasColumnType("float(53)");

            builder.Property(e => e.To)
                .HasColumnName("to")
                .HasMaxLength(3)
                .IsUnicode(false);
        }
    }
}
