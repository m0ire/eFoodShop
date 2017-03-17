using AutoMapper;
using eFoodShop.Application.Dto;
using eFoodShop.Domain.Entities;

namespace eFoodShop.Application.SeedWork.AutoMapper
{
    public class ApplicationMappingProfile : Profile
    {
        public ApplicationMappingProfile()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<Cart, CartDto>();
            CreateMap<CartItem, CartItemDto>();
            CreateMap<Product, ProductDto>();
        }
    }
}
