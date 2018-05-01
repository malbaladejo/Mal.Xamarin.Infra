
using Android.App;
using GalaSoft.MvvmLight.Views;
using Mal.Xamarin.Infra.Containers;
using Mal.Xamarin.Infra.Navigation;

namespace Mal.Xamarin.Infra.Android.Containers
{
    public static class AndroidContainerExtensions
    {
        public static void RegisterActivityForNavigation<TActivityType, TToken>(this IContainer container, int layoutResourceId)
           where TActivityType : Activity
           where TToken : INavigationToken
        {
            container.RegisterActivityForNavigation<TActivityType, TToken>();
            container.RegisterActivityLayoutResourceId<TActivityType>(layoutResourceId);
        }

        public static void RegisterActivityForNavigation<TActivityType, TToken>(this IContainer container)
            where TActivityType : Activity
            where TToken : INavigationToken
        {
            container.GetInstance<NavigationService>().Configure(typeof(TToken).FullName, typeof(TActivityType));
        }

        public static void RegisterActivityLayoutResourceId<TActivityType>(this IContainer container, int layoutResourceId)
            where TActivityType : Activity
        {
            container.RegisterInstance<int>(layoutResourceId, typeof(TActivityType).FullName);
        }
    }
}