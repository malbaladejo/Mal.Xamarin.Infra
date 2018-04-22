using Unity;
using Unity.Resolution;

namespace Mal.Xamarin.Infra.Android
{
    public class IocFactory
    {
        private static IocFactory instance;

        public static IocFactory Instance
        {
            get
            {
                if (instance == null)
                    instance = new IocFactory();

                return instance;
            }
        }

        private IocFactory()
        {
            this.Container = new UnityContainer();
        }

        private IUnityContainer Container { get; }

        public TType Resolve<TType>(params ResolverOverride[] overrides) => this.Container.Resolve<TType>(overrides);
        public TType Resolve<TType>(string name, params ResolverOverride[] overrides) => this.Container.Resolve<TType>(name, overrides);

        public void RegisterType<TViewModel>()
        {
            this.Container.RegisterType<TViewModel>();
        }
    }
}