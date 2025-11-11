using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BethanysPieShopAdmin.Models.Configuration
{
    public class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
                .Property(b => b.ZipCode)
                .IsRequired(); 

            builder
                .Property(b => b.Email)
                .IsRequired();
        }
    }
}
