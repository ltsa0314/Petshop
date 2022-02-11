using PetShop.Domain.Aggregates.OrderAggregate;
using PetShop.Domain.Aggregates.ProductAggregate;
using PetShop.Domain.Aggregates.UserAggregate;
using PetShop.Domain.SeedWork.Contracts;
using PetShop.Infraestructure.Data;
using PetShop.Infraestructure.Repositories;

namespace PetShop.Infraestructure.UnitOfWork
{
    public class UnitOfWorkRepositories : IUnitOfWorkRepositories
    {
        public IOrderRepository OrderRepository { get; }
        public IProductRepository ProductRepository { get; }
        public IUserRepository UserRepository { get; }

        public UnitOfWorkRepositories(PetShopContext context)
        {
            if (OrderRepository == null) OrderRepository = new OrderRepository(context);
            if (ProductRepository == null) ProductRepository = new ProductRepository(context);
            if (UserRepository == null) UserRepository = new UserRepository(context);
        }
    }
}
