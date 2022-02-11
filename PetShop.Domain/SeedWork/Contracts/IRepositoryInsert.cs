using PetShop.Domain.SeedWork.Models;

namespace PetShop.Domain.SeedWork.Contracts
{
    public interface IRepositoryInsert<TEntity> where TEntity : BaseEntity
    {
        void Insert(TEntity entity);

    }
}
