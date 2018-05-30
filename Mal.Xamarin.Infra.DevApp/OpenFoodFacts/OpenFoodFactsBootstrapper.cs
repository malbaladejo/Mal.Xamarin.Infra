using Mal.Xamarin.Infra.Containers;
using Mal.Xamarin.Infra.DevApp.OpenFoodFacts.Services;
using Mal.Xamarin.Infra.DevApp.OpenFoodFacts.Services.Impl;
using Mal.Xamarin.Infra.DevApp.OpenFoodFacts.ViewModels.ManualProductSearch;
using Mal.Xamarin.Infra.Navigation;
using Mal.Xamarin.Infra.Services;

namespace Mal.Xamarin.Infra.DevApp.OpenFoodFacts
{
    internal class OpenFoodFactsBootstrapper
    {
        private readonly IContainer container;

        public OpenFoodFactsBootstrapper(IContainer container)
        {
            this.container = container;
        }

        public void Run()
        {
            this.container.RegisterSingleton<IOpenFoodFactsService, OpenFoodFactsService>();
            container.RegisterType<ManualProductSearchToken>();
            container.RegisterType<ManualProductSearchViewModel>();
            
            container.ServiceLocator.GetInstance<IServiceRegister<INavigationToken>>().Register(new ManualProductSearchToken());
        }
    }
}
