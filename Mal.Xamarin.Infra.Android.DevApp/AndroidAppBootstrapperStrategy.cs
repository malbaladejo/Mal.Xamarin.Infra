using Mal.Xamarin.Infra.Android.Containers;
using Mal.Xamarin.Infra.Android.DevApp.BrugerMenu;
using Mal.Xamarin.Infra.Android.DevApp.CollapsibleHeader;
using Mal.Xamarin.Infra.Android.DevApp.LazyList;
using Mal.Xamarin.Infra.Containers;
using Mal.Xamarin.Infra.DevApp;
using Mal.Xamarin.Infra.DevApp.ViewModels.BurgerMenu;
using Mal.Xamarin.Infra.DevApp.ViewModels.LazyList;
using Mal.Xamarin.Infra.DevApp.ViewModels.Main;
using Mal.Xamarin.Infra.Navigation;
using Mal.Xamarin.Infra.Services;

namespace Mal.Xamarin.Infra.Android.DevApp
{
    internal class AndroidAppBootstrapperStrategy : AppBootstrapperStrategy
    {
        public override void RegisterTypes(IContainer container)
        {
            base.RegisterTypes(container);
            container.RegisterActivityForNavigation<MainActivity, MainNavigationToken>();
            container.RegisterActivityForNavigation<LazyListActivity, LazyListNavigationToken>();
            container.RegisterActivityForNavigation<ItemDetailActivity, LazyListItemNavigationToken>();
            container.RegisterActivityForNavigation<BurgerMenuActivity, BurgerMenuNavigationToken>();
            container.RegisterActivityForNavigation<CollapsibleHeaderActivity, CollapsibleHeaderToken>();

            container.ServiceLocator.GetInstance<IServiceRegister<INavigationToken>>().Register(new CollapsibleHeaderToken());
        }
    }
}