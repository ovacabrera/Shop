using System;
using Microsoft.Practices.Unity.Configuration;
using Unity;
using Unity.Injection;


namespace Shop.CrossCutting
{
    public static class IoC
    {
        private static IUnityContainer _modelContainer;

        private static IUnityContainer ModelContainer
        {
            get
            {
                if (_modelContainer == null)
                {
                    _modelContainer = new UnityContainer();
                    _modelContainer.LoadConfiguration("modelContainer");
                }

                return _modelContainer;
            }
        }


        private static IUnityContainer _externalServiceContainer;

        private static IUnityContainer ExternalServiceContainer
        {
            get
            {
                if (_externalServiceContainer == null)
                {
                    _externalServiceContainer = new UnityContainer();
                    _externalServiceContainer.LoadConfiguration("externalServiceContainer");
                }

                return _externalServiceContainer;
            }
        }

        private static IUnityContainer _loggerServiceContainer;

        private static IUnityContainer LoggerService
        {
            get
            {
                if (_loggerServiceContainer == null)
                {
                    _loggerServiceContainer = new UnityContainer();
                    _loggerServiceContainer.LoadConfiguration("loggerServiceContainer");
                }

                return _loggerServiceContainer;
            }
        }


        public static T GetObjectModel<T>()
        {
            return ModelContainer.Resolve<T>();
        }

        public static T GetObjectExternalService<T>()
        {
            return ExternalServiceContainer.Resolve<T>();
        }

        public static T GetLogger<T>()
        {
            return LoggerService.Resolve<T>();
        }
    }
}