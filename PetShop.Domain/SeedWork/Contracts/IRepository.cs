using PetShop.Domain.SeedWork.Models;

namespace PetShop.Domain.SeedWork.Contracts
{
    public interface IRepository<TEntity> :
        IRepositoryGet<TEntity>,
        IRepositoryInsert<TEntity>,
        IRepositoryUpdate<TEntity>,
        IRepositoryDelete<TEntity>

        where TEntity : BaseEntity
    {
    }
}
