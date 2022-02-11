using PetShop.Domain.Aggregates.OrderAggregate;
using PetShop.Domain.Aggregates.ProductAggregate;
using PetShop.Domain.Aggregates.UserAggregate;

namespace PetShop.Domain.SeedWork.Contracts
{
    public interface IUnitOfWorkRepositories
    {
        IOrderRepository OrderRepository { get; }
        IProductRepository ProductRepository { get; }
        IUserRepository UserRepository { get; }

    }
}
