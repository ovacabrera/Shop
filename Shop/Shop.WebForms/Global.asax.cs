using System;
using System.Configuration;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.AspNet.WebFormsDependencyInjection.Unity;
using Shop.Application;
using Shop.Application.Interfaces;
using Shop.CrossCutting;
using Shop.CrossCutting.Log;
using Shop.ExternalServices;
using Unity;
using Unity.Lifetime;

namespace Shop.WebForms
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Código que se ejecuta al iniciar la aplicación
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ResolveDependences();
        }

        private void ResolveDependences()
        {
            var container = this.AddUnity();

            container.RegisterType<ILoggerService, Log4NetLoggerService>();

            container.RegisterType<IItemApplication>(new ContainerControlledLifetimeManager());
            container.RegisterInstance<IItemApplication>(new ItemApplication(
                new ExternalServiceMercadoLibre(ConfigurationManager.AppSettings["APIMercadoLibre"]),
                new Log4NetLoggerService()));
        }
    }
}