using Mal.Xamarin.Infra.Android.Containers;
using Mal.Xamarin.Infra.Android.DevApp.OpenFoodFacts.ManualSearch;
using Mal.Xamarin.Infra.Containers;
using Mal.Xamarin.Infra.DevApp.OpenFoodFacts.ViewModels.ManualProductSearch;

namespace Mal.Xamarin.Infra.Android.DevApp.OpenFoodFacts
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
            container.RegisterActivityForNavigation<ManualProductSearchActivity, ManualProductSearchToken>();
        }
    }
}
