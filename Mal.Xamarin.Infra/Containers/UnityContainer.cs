using CommonServiceLocator;
using System;
using System.Collections.Generic;
using Unity;

namespace Mal.Xamarin.Infra.Containers
{
    public class UnityContainer : IContainer
    {
        private readonly Unity.UnityContainer container;

        public UnityContainer()
        {
            this.container = new Unity.UnityContainer();
        }

        public IServiceLocator ServiceLocator { get; set; }

        public IEnumerable<object> GetAllInstances(Type serviceType)
            => this.container.ResolveAll(serviceType);

        public IEnumerable<TService> GetAllInstances<TService>()
            => this.container.ResolveAll<TService>();

        public object GetInstance(Type serviceType)
            => this.container.Resolve(serviceType);

        public object GetInstance(Type serviceType, string key)
            => this.container.Resolve(serviceType, key);

        public TService GetInstance<TService>()
            => this.container.Resolve<TService>();

        public TService GetInstance<TService>(string key)
            => this.container.Resolve<TService>(key);

        public void RegisterInstance<TType>(TType instance)
            => this.container.RegisterInstance<TType>(instance);

        public void RegisterSingleton<TFrom, TTo>() where TTo : TFrom
            => this.container.RegisterSingleton<TFrom, TTo>();

        public void RegisterType<TFrom, TTo>() where TTo : TFrom
            => this.container.RegisterType<TFrom, TTo>();

        public void RegisterType<TFrom, TTo>(string key) where TTo : TFrom
            => this.container.RegisterType<TFrom, TTo>(key);
    }
}