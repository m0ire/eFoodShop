using AutoMapper;
using eFoodShop.Application.Dto;
using eFoodShop.Application.SeedWork.Unity;
using eFoodShop.Application.Services.Interfaces;
using eFoodShop.Domain.Entities;
using eFoodShop.Domain.SeedWork.Repositories;
using Microsoft.Practices.Unity;

namespace eFoodShop.Application.Services.Implementations
{
    public class CustomerService : ICustomerService
    {

        public CustomerDto Get(int id)
        {
            using (var uow = UnityConfig.Container.Resolve<IUnitOfWork>())
            {
                var customer = uow.Customers.GetWithCart(id);

                return Mapper.Map<CustomerDto>(customer);
            } 
        }

        public void Register(CustomerDto customerDto)
        {
            var customer = new Customer(customerDto.Name, customerDto.Email, customerDto.Password);
            using (var uow = UnityConfig.Container.Resolve<IUnitOfWork>())
            {
                uow.Customers.Add(customer);
                uow.Complete();
                Mapper.Map(customer, customerDto);
            }
        }

        public void AddToCart(int id, CartItemDto cartItemDto)
        {
            using (var uow = UnityConfig.Container.Resolve<IUnitOfWork>())
            {
                var customer = uow.Customers.GetWithCart(id);
                var product = uow.Products.Get(cartItemDto.Product.Id);

                customer.AddToCart(product, cartItemDto.Count);
                uow.Complete();
            }
        }

        public void RemoveFromCart(int id, CartItemDto cartItemDto)
        {
            using (var uow = UnityConfig.Container.Resolve<IUnitOfWork>())
            {
                var customer = uow.Customers.GetWithCart(id);
                var product = uow.Products.Get(cartItemDto.Product.Id);

                customer.RemoveFromCart(product, cartItemDto.Count);
                uow.Complete();
            }
        }
    }
}