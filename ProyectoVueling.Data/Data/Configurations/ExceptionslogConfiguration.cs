using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PruebaVueling.Data.Entities;

namespace PruebaVueling.Infrastructure.Data.Configurations
{
    class ExceptionsLogConfiguration : IEntityTypeConfiguration<Exceptionslog>
    {
        public void Configure(EntityTypeBuilder<Exceptionslog> builder)
        {
            builder.HasKey(e => e.Id).HasName("id");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.CreationDate)
                .HasColumnName("creation_date")
                .HasColumnType("datetime");

            builder.Property(e => e.Description)
                .HasColumnName("description")
                .IsUnicode(false);
        }
    }
}
