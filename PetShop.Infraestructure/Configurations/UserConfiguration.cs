using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetShop.Domain.Aggregates.UserAggregate;
using System.Collections.Generic;

namespace PetShop.Infraestructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Usuarios");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.UserName).IsRequired().HasMaxLength(20);
            builder.Property(x => x.FullName).IsRequired().HasMaxLength(20);
            builder.Property(x => x.Type).IsRequired();

            builder.HasData(new List<User>
            {
                new User {
                    Id = 1,
                    Type = UserType.Admin,
                    UserName = "leidy",
                    FullName = "Leidy Tatina",                   
                    Password = "123456"
                },
                new User {
                    Id = 2,
                    Type = UserType.Buyer,
                    UserName = "pepito",
                    FullName = "Pepito Perez",
                    Password = "123456"
                }
            });
        }
    }
}
