using PetShop.Domain.SeedWork.Contracts;
using PetShop.Infraestructure.Data;

namespace PetShop.Infraestructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUnitOfWorkAdapter Create()
        {
            var context = PetShopContexFactory.Create();
            return new UnitOfWorkAdapter(context);
        }

    }
}
