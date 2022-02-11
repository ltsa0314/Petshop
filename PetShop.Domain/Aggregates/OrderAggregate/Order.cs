using PetShop.Domain.Aggregates.UserAggregate;
using PetShop.Domain.SeedWork.Models;
using System;
using System.Collections.Generic;

namespace PetShop.Domain.Aggregates.OrderAggregate
{
    public class Order : BaseEntity
    {
        public long UserId { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalAmount { get; set; }
        public virtual User User { get; set; }
        public virtual IEnumerable<OrderItem> OrderItems { get; set; }


    }
}
