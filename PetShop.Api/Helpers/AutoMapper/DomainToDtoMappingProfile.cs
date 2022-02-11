using AutoMapper;
using PetShop.Api.Dtos;
using PetShop.Domain.Aggregates.OrderAggregate;
using PetShop.Domain.Aggregates.ProductAggregate;
using PetShop.Domain.Aggregates.UserAggregate;

namespace PetShop.Api.Helpers.AutoMapper
{
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile()
        {
            CreateMap<OrderItem, OrderItemDto>();
            CreateMap<Order, OrderDto>();
            CreateMap<Product, ProductDto>();
            CreateMap<User, UserDto>();

        }


    }
}
