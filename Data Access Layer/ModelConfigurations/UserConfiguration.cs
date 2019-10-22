using Data_Access_Layer.Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data_Access_Layer.ModelConfigurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<UserDB>
    {
        public void Configure(EntityTypeBuilder<UserDB> builder)
        {
            builder.ToTable("User");

            builder.HasKey(p => p.Id);

            builder.Property(x => x.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Birthday).IsRequired(false);
            builder.Property(x => x.NumberDL).HasMaxLength(50).IsRequired();

            builder.Property(x => x.TimeAdd).IsRequired(false);
            builder.Property(x => x.TimeModified).IsRequired(false);

            builder.HasMany(x => x.Orders)
                .WithOne(y => y.User)
                .HasForeignKey(z => z.UsertId);
        }
    }
}
