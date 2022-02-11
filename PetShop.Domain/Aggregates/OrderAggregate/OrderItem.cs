using PetShop.Domain.Aggregates.ProductAggregate;
using PetShop.Domain.SeedWork.Models;

namespace PetShop.Domain.Aggregates.OrderAggregate
{
    public class OrderItem : BaseEntity
    {
        public long OrderId { get; set; }
        public long ProductId { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public decimal TotalAmount { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }


    }
}
