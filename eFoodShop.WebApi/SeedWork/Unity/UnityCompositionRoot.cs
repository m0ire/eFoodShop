using System;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using Microsoft.Practices.Unity;

namespace eFoodShop.WebAPI.SeedWork.Unity
{
    public class UnityCompositionRoot : IHttpControllerActivator
    {
        private readonly IUnityContainer _container;

        public UnityCompositionRoot(IUnityContainer container)
        {
            _container = container;
        }

        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            var controller = _container.Resolve(controllerType);

            return (IHttpController)controller;
        }
    }
}