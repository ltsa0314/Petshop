using PetShop.Domain.SeedWork.Contracts;

namespace PetShop.Domain.Aggregates.UserAggregate
{
    public interface IUserRepository :
        IRepositoryGet<User>,
        IRepositoryInsert<User>,
        IRepositoryUpdate<User>
    {
    }
}
