using GalaSoft.MvvmLight.Views;
using Mal.Xamarin.Infra.Android.Navigation;
using Mal.Xamarin.Infra.Containers;

namespace Mal.Xamarin.Infra.Android.Containers
{
    public class AndroidAppBootstrapper : AppBootstrapperBase
    {
        private readonly IContainer container;

        public AndroidAppBootstrapper()
        {
            this.container = new LightInjectContainer();
        }

        protected override IContainer BuildContainer()
        {
            var navigationService = new AndroidNavigationService();
            container.RegisterInstance<INavigationService>(navigationService);
            container.RegisterInstance<IAndroidNavigationService>(navigationService);
            container.RegisterSingleton<IDialogService, AndroidDialogService>();
            return this.container;
        }
    }
}