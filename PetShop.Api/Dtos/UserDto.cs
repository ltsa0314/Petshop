﻿using PetShop.Domain.Aggregates.UserAggregate;

namespace PetShop.Api.Dtos
{
    public class UserDto
    {
        public long Id { get; set; }
        public UserType Type { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
    }
}
