using Data_Access_Layer.Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data_Access_Layer.ModelConfigurations
{
    internal class CarConfiguration : IEntityTypeConfiguration<CarDB>
    {
        public void Configure(EntityTypeBuilder<CarDB> builder)
        {
            builder.ToTable("Car");

            builder.HasKey(p => p.Id);

            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Model).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Class).HasMaxLength(50).IsRequired();
            builder.Property(x => x.DateRelease).IsRequired();
            builder.Property(x => x.RegistrationNumber).HasMaxLength(50).IsRequired();

            builder.Property(x => x.TimeAdd).IsRequired(false);
            builder.Property(x => x.TimeModified).IsRequired(false);

            builder.HasMany(x => x.Orders)
                .WithOne(y => y.Car)
                .HasForeignKey(z => z.CarId);
        }
    }
}
