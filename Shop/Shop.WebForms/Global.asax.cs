using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.AspNet.WebFormsDependencyInjection.Unity;
using Microsoft.Practices.Unity.Configuration;
using Shop.CrossCutting;
using Shop.CrossCutting.Log;
using Shop.ExternalServices;
using Shop.ExternalServices.Interfaces;
using Shop.Models;
using Shop.Models.Interfaces;
using Unity;

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
            container.RegisterType<IExternalService, ExternalServiceMercadoLibre>();
            container.RegisterType<ISearchModel, SearchModel>();
            container.RegisterType<IItemModel, ItemModel>();
            container.RegisterType<ILoggerService, Log4NetLoggerService>();
        }
    }
}