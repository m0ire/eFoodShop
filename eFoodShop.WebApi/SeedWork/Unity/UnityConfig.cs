using eFoodShop.Application.Services.Implementations;
using eFoodShop.Application.Services.Interfaces;
using eFoodShop.WebAPI.Controllers;
using Microsoft.Practices.Unity;

namespace eFoodShop.WebAPI.SeedWork.Unity
{
    public static class UnityConfig
    {
        public static void RegisterComponents(IUnityContainer container)
        {
            Application.SeedWork.Unity.UnityConfig.RegisterComponents(container);
            container.RegisterType<CustomersController>();
            container.RegisterType<ProductsController>();
            container.RegisterType<ICustomerService, CustomerService>();
            container.RegisterType<IProductService, ProductService>();
        }
    }
}