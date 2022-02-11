using PetShop.Domain.SeedWork.Models;

namespace PetShop.Domain.SeedWork.Contracts
{
    public interface IRepositoryDelete<TEntity> where TEntity : BaseEntity
    {
        void Delete(long Id);

    }
}
