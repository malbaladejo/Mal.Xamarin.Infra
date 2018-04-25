
using Android.App;
using GalaSoft.MvvmLight.Views;
using Mal.Xamarin.Infra.Containers;
using Mal.Xamarin.Infra.Navigation;

namespace Mal.Xamarin.Infra.Android.Containers
{
    public static class AndroidContainerExtensions
    {
        public static void RegisterViewForNavigation<TActivityType, TToken>(this IContainer container)
            where TActivityType : Activity
            where TToken : INavigationToken
        {
            container.GetInstance<NavigationService>().Configure(typeof(TToken).FullName, typeof(TActivityType));
        }
    }
}