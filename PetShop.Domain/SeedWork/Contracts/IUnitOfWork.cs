namespace PetShop.Domain.SeedWork.Contracts
{
    public interface IUnitOfWork
    {
        IUnitOfWorkAdapter Create();
    }
}
