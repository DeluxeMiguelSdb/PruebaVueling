using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PruebaVueling.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaVueling.Infrastructure.Data.Configurations
{
    class RateConfiguration : IEntityTypeConfiguration<Rates>
    {
        public void Configure(EntityTypeBuilder<Rates> builder)
        {
            builder.HasNoKey();

            builder.ToTable("rates");

            builder.Property(e => e.From)
                .HasColumnName("from")
                .HasMaxLength(3)
                .IsUnicode(false);

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Rate)
                .HasColumnName("rate")
                .HasColumnType("decimal(18, 0)");

            builder.Property(e => e.To)
                .HasColumnName("to")
                .HasMaxLength(3)
                .IsUnicode(false);
        }
    }
}
