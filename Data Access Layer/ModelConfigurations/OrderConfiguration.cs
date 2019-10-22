using Data_Access_Layer.Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Access_Layer.ModelConfigurations
{
    internal class OrderConfiguration : IEntityTypeConfiguration<OrderDB>
    {
        public void Configure(EntityTypeBuilder<OrderDB> builder)
        {
            builder.ToTable("Order");

            builder.HasKey(p => p.Id);

            builder.Property(x => x.Information).HasMaxLength(255).IsRequired(false);
            builder.Property(x => x.TimeStart).IsRequired();
            builder.Property(x => x.TimeEnd).IsRequired();

            builder.Property(x => x.TimeAdd).IsRequired(false);
            builder.Property(x => x.TimeModified).IsRequired(false);
        }
    }
}
