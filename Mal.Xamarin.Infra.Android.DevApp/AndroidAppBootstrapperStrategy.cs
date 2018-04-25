using Mal.Xamarin.Infra.Android.Containers;
using Mal.Xamarin.Infra.Containers;
using Mal.Xamarin.Infra.DevApp;
using Mal.Xamarin.Infra.DevApp.ViewModels.ListAdapter;
using Mal.Xamarin.Infra.DevApp.ViewModels.Main;

namespace Mal.Xamarin.Infra.Android.DevApp
{
    internal class AndroidAppBootstrapperStrategy : AppBootstrapperStrategy
    {
        public override void RegisterTypes(IContainer container)
        {
            base.RegisterTypes(container);
            container.RegisterViewForNavigation<MainActivity, MainNavigationToken>();
            container.RegisterViewForNavigation<ListActivity, ListNavigationToken>();
        }
    }
}