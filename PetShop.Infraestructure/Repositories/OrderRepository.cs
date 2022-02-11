using Microsoft.EntityFrameworkCore;
using PetShop.Domain.Aggregates.OrderAggregate;

namespace PetShop.Infraestructure.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(DbContext context) : base(context)
        {
        }
    }
}
