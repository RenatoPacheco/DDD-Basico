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
using DddBasico.Api.Auxiliares;
using DddBasico.Infra.Persistencia.Contextos.Interfaces;

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
            DddBasico.Infra.IdC.Injetar.Carregar(container);
            // Registrando minhas classes api
            
            // This is an extension method from the integration package.
            container.RegisterWebApiControllers(config);

            // Registrando minhas classes api
            container.Register<IResolverConexao, ResolverConexao>(Lifestyle.Scoped);

            container.Verify();
            
            // Adapter for Service Locator
            var adapter = new SimpleInjectorServiceLocatorAdapter(container);
            ServiceLocator.SetLocatorProvider(() => adapter);
            
            config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}