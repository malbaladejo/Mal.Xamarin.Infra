using CommonServiceLocator;
using LightInject;
using System;
using System.Collections.Generic;

namespace Mal.Xamarin.Infra.Containers
{
    public class LightInjectContainer : IContainer
    {
        private readonly IServiceContainer container;

        public LightInjectContainer()
        {
            this.container = new ServiceContainer();
        }

        public IServiceLocator ServiceLocator { get; set; }

        public IEnumerable<object> GetAllInstances(Type serviceType)
        => this.container.GetAllInstances(serviceType);

        public IEnumerable<TService> GetAllInstances<TService>()
        => this.container.GetAllInstances<TService>();

        public object GetInstance(Type serviceType)
        => this.container.GetInstance(serviceType);

        public object GetInstance(Type serviceType, string key)
        => this.container.GetInstance(serviceType, key);

        public TService GetInstance<TService>()
         => this.container.GetInstance<TService>();

        public TService GetInstance<TService>(string key)
        => this.container.GetInstance<TService>(key);

        public void RegisterInstance<TType>(TType instance)
        => this.container.RegisterInstance<TType>(instance);

        public void RegisterSingleton<TFrom, TTo>() where TTo : TFrom
        => this.container.Register<TFrom, TTo>(new PerContainerLifetime());

        public void RegisterType<TType>()
            => this.container.Register<TType>();

        public void RegisterType<TFrom, TTo>() where TTo : TFrom
        => this.container.Register<TFrom, TTo>();

        public void RegisterType<TFrom, TTo>(string key) where TTo : TFrom
        => this.container.Register<TFrom, TTo>(key);
    }
}
