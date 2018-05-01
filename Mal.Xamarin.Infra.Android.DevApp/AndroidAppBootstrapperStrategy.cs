using Mal.Xamarin.Infra.Android.Containers;
using Mal.Xamarin.Infra.Android.DevApp.BrugerMenu;
using Mal.Xamarin.Infra.Android.DevApp.LazyList;
using Mal.Xamarin.Infra.Containers;
using Mal.Xamarin.Infra.DevApp;
using Mal.Xamarin.Infra.DevApp.ViewModels.BurgerMenu;
using Mal.Xamarin.Infra.DevApp.ViewModels.LazyList;
using Mal.Xamarin.Infra.DevApp.ViewModels.Main;

namespace Mal.Xamarin.Infra.Android.DevApp
{
    internal class AndroidAppBootstrapperStrategy : AppBootstrapperStrategy
    {
        public override void RegisterTypes(IContainer container)
        {
            base.RegisterTypes(container);
            container.RegisterActivityForNavigation<MainActivity, MainNavigationToken>();//(Resource.Layout.Main);
            container.RegisterActivityForNavigation<LazyListActivity, LazyListNavigationToken>();//(Resource.Layout.LazyList);
            container.RegisterActivityForNavigation<ItemDetailActivity, LazyListItemNavigationToken>();//(Resource.Layout.LazyListItem);
            container.RegisterActivityForNavigation<BurgerMenuActivity, BurgerMenuNavigationToken>();//(Resource.Layout.BurgerMenu);
        }
    }
}