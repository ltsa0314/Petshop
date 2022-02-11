using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetShop.Domain.Aggregates.OrderAggregate;

namespace PetShop.Infraestructure.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Ordenes");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Date).IsRequired();
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.TotalAmount).IsRequired();
        }
    }
}
