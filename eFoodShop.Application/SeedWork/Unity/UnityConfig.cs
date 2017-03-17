using eFoodShop.Domain.SeedWork.Repositories;
using eFoodShop.Infrastructure.EF;
using Microsoft.Practices.Unity;

namespace eFoodShop.Application.SeedWork.Unity
{
    public static class UnityConfig
    {
        public static IUnityContainer Container { get; private set; }

        public static void RegisterComponents(IUnityContainer container)
        {
            Container = container;

            Infrastructure.SeedWork.Unity.UnityConfig.RegisterComponents(container);

            container.RegisterType<IUnitOfWork, UnitOfWork>();
        }
    }
}