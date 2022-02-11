using Microsoft.EntityFrameworkCore;
using PetShop.Domain.Aggregates.UserAggregate;
using PetShop.Infraestructure.Data;
using PetShop.Infraestructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PetShop.UnitTests.Repositories
{
    public class UserRepositoryTest
    {
        [Fact]
        public void Insert()
        {
            // Arrange
            var builder = new DbContextOptionsBuilder<PetShopContext>();
            var options = builder.UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            using var context = new PetShopContext(options);
            context.Database.EnsureDeleted();

            var entity = new User
            {
                Type = 0,
                UserName="Tatis",
                FullName="Leidy Tatiana Sanchez A.",
                Password="Abcd"
            };

            // Action
            var repository = new UserRepository(context);
             repository.Insert(entity);

            // Assert
            Assert.True(entity.Id > 0);
            Assert.True(entity.UserName == "Tatis");
            Assert.True(entity.FullName == "Leidy Tatiana Sanchez A.");
            Assert.True(entity.Password == "Abcd");


        }
    }
}
