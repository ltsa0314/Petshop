using System;

namespace PetShop.Domain.SeedWork.Contracts
{
    public interface IUnitOfWorkAdapter : IDisposable
    {
        IUnitOfWorkRepositories Repositories { get; }
        void Commit();
    }
}
