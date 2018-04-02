using System;
using System.Web;
using System.Linq;
using SimpleInjector;
using System.Web.Http;
using System.Collections.Generic;
using SimpleInjector.Integration.WebApi;
using DddBasico.Api.SimpleInjectorCustom;
using SimpleInjector.Lifestyles;
using CommonServiceLocator;

namespace DddBasico.Api
{
    public class SimpleInjectorConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Create the container as usual.
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            // Register your types, for instance using the scoped lifestyle:
            DddBasico.Infra.CrossCutting.IdC.IdC.Carregar(container);
            // Registrando minhas classes api
            
            // This is an extension method from the integration package.
            container.RegisterWebApiControllers(config);

            container.Verify();
            
            // Adapter for Service Locator
            var adapter = new SimpleInjectorServiceLocatorAdapter(container);
            ServiceLocator.SetLocatorProvider(() => adapter);
            
            config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}