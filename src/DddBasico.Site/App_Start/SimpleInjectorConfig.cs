using CommonServiceLocator;
using DddBasico.Infra.Persistencia.Contextos.Interfaces;
using DddBasico.Site.Auxiliares;
using DddBasico.Site.SimpleInjectorCustom;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace DddBasico.Site
{
    public class SimpleInjectorConfig
    {
        public static void RegisterInject()
        {
            // 1. Create a new Simple Injector container
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            DddBasico.Infra.IdC.Injetar.Carregar(container);

            // 2. Include my resolvers
            container.Register<IResolverConexao, ResolverConexao>(Lifestyle.Scoped);
            
            // 3. This is an extension method from the integration package.
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            // 4. This is an extension method from the integration package as well.
            container.RegisterMvcIntegratedFilterProvider();

            // 5. Adapter for Service Locator
            var adapter = new SimpleInjectorServiceLocatorAdapter(container);
            ServiceLocator.SetLocatorProvider(() => adapter);

            // 6. Optionally verify the container's configuration.
            container.Verify();

            // 7. Store the container for use by the application
            DependencyResolver.SetResolver(
                new SimpleInjectorDependencyResolver(container));
        }
    }
}