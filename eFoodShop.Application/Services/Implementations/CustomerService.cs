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
            var customer = new Customer(0, customerDto.Name, customerDto.Email, customerDto.Password);
            using (var uow = UnityConfig.Container.Resolve<IUnitOfWork>())
            {
                uow.Customers.Add(customer);
                uow.Complete();
                Mapper.Map(customer, customerDto);
            }
        }
    }
}