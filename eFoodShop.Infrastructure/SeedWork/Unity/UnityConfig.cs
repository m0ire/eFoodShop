using eFoodShop.Domain.SeedWork.Repositories;
using eFoodShop.Infrastructure.EF;
using Microsoft.Practices.Unity;

namespace eFoodShop.Infrastructure.SeedWork.Unity
{
    public static class UnityConfig
    {
        public static IUnityContainer Container { get; private set; }

        public static void RegisterComponents(IUnityContainer container)
        {
            Container = container;
            container.RegisterType<IUnitOfWork, UnitOfWork>(new PerResolveLifetimeManager());
        }
    }
}