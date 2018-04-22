using Unity;
using Unity.Registration;
using Unity.Resolution;

namespace Mal.Xamarin.Infra
{
    public interface IIocFactory
    {


        public void RegisterInstance(Type registeredType, string name, object instance, LifetimeManager lifetimeManager);
        public void RegisterType(Type typeFrom, Type typeTo, string name, LifetimeManager lifetimeManager, InjectionMember[] injectionMembers);
        public object Resolve(Type typeToBuild, string nameToBuild, params ResolverOverride[] resolverOverrides);

        void RegisterType<TType>(params InjectionMember[] injectionMembers) => this.Container.RegisterType<TType>(injectionMembers);
        void RegisterType<TFrom, TTo>(params InjectionMember[] injectionMembers) where TTo : TFrom;
    }

    public class IocFactory : IIocFactory
    {
        private static IIocFactory instance;

        public static IIocFactory Instance
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

        public IUnityContainer Container { get; }

        public TType Resolve<TType>(params ResolverOverride[] overrides) => this.Container.Resolve<TType>(overrides);
        public TType Resolve<TType>(string name, params ResolverOverride[] overrides) => this.Container.Resolve<TType>(name, overrides);
        // public void RegisterType<TType>(params InjectionMember[] injectionMembers) => this.Container.RegisterType<TType>(injectionMembers);
        public void RegisterType<TFrom, TTo>(params InjectionMember[] injectionMembers) where TTo : TFrom => this.Container.RegisterType<TFrom, TTo>(injectionMembers, );
    }

    public static class IocFactoryExtensions
    {
        public static TType Resolve<TType>(this IIocFactory, params ResolverOverride[] overrides)
        {

        }

        public static TType Resolve<TType>(string name, params ResolverOverride[] overrides);
    }
}