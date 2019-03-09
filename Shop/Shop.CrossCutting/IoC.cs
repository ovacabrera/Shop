using Microsoft.Practices.Unity.Configuration;
using Unity;


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


        public static T GetObjectModel<T>()
        {
            return ModelContainer.Resolve<T>();
        }

        public static T GetObjectExternalService<T>()
        {
            return ExternalServiceContainer.Resolve<T>();
        }
    }
}