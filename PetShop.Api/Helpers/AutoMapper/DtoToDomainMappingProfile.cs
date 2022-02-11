using AutoMapper;
using PetShop.Api.Dtos;
using PetShop.Domain.Aggregates.OrderAggregate;
using PetShop.Domain.Aggregates.ProductAggregate;
using PetShop.Domain.Aggregates.UserAggregate;

namespace PetShop.Api.Helpers.AutoMapper
{
    public class DtoToDomainMappingProfile : Profile
    {
        public DtoToDomainMappingProfile()
        {
            CreateMap<OrderItemDto, OrderItem>();
            CreateMap<OrderDto, Order>();
            CreateMap<ProductDto, Product>();
            CreateMap<UserDto, User>();
        }
    }
}
