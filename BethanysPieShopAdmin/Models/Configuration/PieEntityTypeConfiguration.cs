using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BethanysPieShopAdmin.Models.Configuration
{
    public class PieEntityTypeConfiguration : IEntityTypeConfiguration<Pie>
    {
        public void Configure(EntityTypeBuilder<Pie> builder)
        {
            builder
                .Property(b => b.Name)
                .IsRequired();

            builder
                .Property(b => b.ShortDescription)
                .HasMaxLength(100);

            builder
                .Property(b => b.LongDescription)
                .HasMaxLength(1000);

            builder
                .Property(b => b.AllergyInformation)
                .HasMaxLength(1000);
        }
    }
}
