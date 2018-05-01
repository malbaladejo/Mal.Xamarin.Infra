using CommonServiceLocator;
using System;
using System.Collections.Generic;

namespace Mal.Xamarin.Infra.Containers
{
    public class ServiceLocator : IServiceLocator
    {
        private readonly IContainer container;

        public ServiceLocator(IContainer container)
        {
            this.container = container;
        }

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

        public object GetService(Type serviceType)
        => this.container.GetInstance(serviceType);

        public static IServiceLocator Current { get; internal set; }
    }

}
