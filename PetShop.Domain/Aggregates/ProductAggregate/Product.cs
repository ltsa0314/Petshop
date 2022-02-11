using PetShop.Domain.Aggregates.OrderAggregate;
using PetShop.Domain.SeedWork.Models;
using System.Collections.Generic;

namespace PetShop.Domain.Aggregates.ProductAggregate
{
    public class Product : BaseEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }

        public virtual IEnumerable<OrderItem> OrderItems { get; set; }


    }
}
