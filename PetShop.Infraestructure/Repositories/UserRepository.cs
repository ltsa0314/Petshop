using Microsoft.EntityFrameworkCore;
using PetShop.Domain.Aggregates.UserAggregate;

namespace PetShop.Infraestructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context)
        {
        }
    }
}
