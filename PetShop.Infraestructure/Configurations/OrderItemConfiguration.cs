using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetShop.Domain.Aggregates.OrderAggregate;

namespace PetShop.Infraestructure.Configurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrdenItems");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.OrderId).IsRequired();
            builder.Property(x => x.ProductId).IsRequired();
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.Count).IsRequired();
            builder.Property(x => x.TotalAmount).IsRequired();

        }
    }
}
