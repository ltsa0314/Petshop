using PetShop.Domain.SeedWork.Contracts;

namespace PetShop.Domain.Aggregates.OrderAggregate
{
    public interface IOrderRepository :
        IRepositoryGet<Order>,
        IRepositoryInsert<Order>
    {

    }
}
