using System;
using System.Collections.Generic;

namespace PetShop.Api.Dtos
{
    public class OrderDto
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalAmount { get; set; }
        public IEnumerable<OrderItemDto> OrderItems { get; set; }
    }
}
