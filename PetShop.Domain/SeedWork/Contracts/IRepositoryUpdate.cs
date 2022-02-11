using PetShop.Domain.SeedWork.Models;

namespace PetShop.Domain.SeedWork.Contracts
{
    public interface IRepositoryUpdate<TEntity> where TEntity : BaseEntity
    {
        void Update(TEntity entity);
    }
}
