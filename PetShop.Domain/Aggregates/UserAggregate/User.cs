using PetShop.Domain.Aggregates.OrderAggregate;
using PetShop.Domain.SeedWork.Models;
using System.Collections.Generic;

namespace PetShop.Domain.Aggregates.UserAggregate
{
    public class User : BaseEntity
    {
        public UserType Type { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public virtual IEnumerable<Order> Orders { get; set; }

    }
}
