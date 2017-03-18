using AutoMapper;
using eFoodShop.Application.Dto;
using eFoodShop.Application.SeedWork.Unity;
using eFoodShop.Application.Services.Interfaces;
using eFoodShop.Domain.SeedWork.Repositories;
using Microsoft.Practices.Unity;

namespace eFoodShop.Application.Services.Implementations
{
    public class CartService : ICartService
    {
        public CartDto Get(int id)
        {
            using (var uow = UnityConfig.Container.Resolve<IUnitOfWork>())
            {
                var cart = uow.Carts.GetWithCartItems(id);

                return Mapper.Map<CartDto>(cart);
            }
        }

        public void Add(int id, CartItemDto cartItemDto)
        {
            using (var uow = UnityConfig.Container.Resolve<IUnitOfWork>())
            {
                var cart = uow.Carts.GetWithCartItems(id);
                var product = uow.Products.Get(cartItemDto.Product.Id);

                cart.Add(product, cartItemDto.Count);
                uow.Complete();
            }
        }

        public void Remove(int id, CartItemDto cartItemDto)
        {
            using (var uow = UnityConfig.Container.Resolve<IUnitOfWork>())
            {
                var cart = uow.Carts.GetWithCartItems(id);
                var product = uow.Products.Get(cartItemDto.Product.Id);

                cart.Remove(product, cartItemDto.Count);
                uow.Complete();
            }
        }
    }
}