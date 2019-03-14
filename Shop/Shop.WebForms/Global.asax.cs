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
            InstanceGlobalObjects();
        }

        private void InstanceGlobalObjects()
        {
            IItemApplication itemApplication = new ItemApplication(new ExternalServiceMercadoLibre(ConfigurationManager.AppSettings["APIMercadoLibre"]), new Log4NetLoggerService());
            Application["IItemApplication"] = itemApplication;
        }

        private void ResolveDependences()
        {
            var container = this.AddUnity();

            //container.RegisterType<IExternalService, ExternalServiceMercadoLibre>();
            //container.RegisterType<IItemDomain, ItemDomain>();
            //container.RegisterType<IItemApplication, ItemApplication>();

            container.RegisterType<ILoggerService, Log4NetLoggerService>();
            
        }
    }
}