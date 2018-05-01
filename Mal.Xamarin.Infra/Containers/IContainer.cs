using CommonServiceLocator;
using System;
using System.Collections.Generic;

namespace Mal.Xamarin.Infra.Containers
{
    public interface IContainer
    {
        IServiceLocator ServiceLocator { get; set; }

        void RegisterType<TFrom, TTo>() where TTo : TFrom;
        void RegisterType<TFrom, TTo>(string key) where TTo : TFrom;
        void RegisterType<TType>();
        void RegisterSingleton<TFrom, TTo>() where TTo : TFrom;
        void RegisterInstance<TType>(TType instance);
        void RegisterInstance<TType>(TType instance, string key);

        IEnumerable<object> GetAllInstances(Type serviceType);
        IEnumerable<TService> GetAllInstances<TService>();
        object GetInstance(Type serviceType);
        object GetInstance(Type serviceType, string key);
        TService GetInstance<TService>();
        TService GetInstance<TService>(string key);
    }
}
