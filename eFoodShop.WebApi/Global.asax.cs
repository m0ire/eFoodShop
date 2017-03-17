using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using eFoodShop.Application.SeedWork.AutoMapper;
using eFoodShop.WebAPI.SeedWork.Unity;
using Microsoft.Practices.Unity;

namespace eFoodShop.WebAPI
{
    public class WebApiApplication : HttpApplication
    {
        private readonly IUnityContainer _container;

        public WebApiApplication()
        {
            _container = new UnityContainer();
        }

        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator), new UnityCompositionRoot(_container));

            UnityConfig.RegisterComponents(_container);

            MapperConfig.Initialize();
        }

        public override void Dispose()
        {
            _container.Dispose();
            base.Dispose();
        }
    }
}