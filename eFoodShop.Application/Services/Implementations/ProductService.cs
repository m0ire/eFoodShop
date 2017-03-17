using AutoMapper;
using eFoodShop.Application.Dto;
using eFoodShop.Application.SeedWork.Unity;
using eFoodShop.Application.Services.Interfaces;
using eFoodShop.Domain.Entities;
using eFoodShop.Domain.SeedWork.Repositories;
using Microsoft.Practices.Unity;

namespace eFoodShop.Application.Services.Implementations
{
    public class ProductService : IProductService
    {
        public ProductDto Get(int id)
        {
            using (var uow = UnityConfig.Container.Resolve<IUnitOfWork>())
            {
                var product = uow.Products.Get(id);
                return Mapper.Map<ProductDto>(product);
            }
        }

        public void Create(ProductDto productDto)
        {
            var product = new Product(productDto.Name);
            using (var uow = UnityConfig.Container.Resolve<IUnitOfWork>())
            {
                uow.Products.Add(product);
                uow.Complete();
                Mapper.Map(product, productDto);
            }
        }
    }
}