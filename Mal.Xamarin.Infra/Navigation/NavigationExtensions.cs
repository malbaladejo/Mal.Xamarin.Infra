using GalaSoft.MvvmLight.Views;

namespace Mal.Xamarin.Infra.Navigation
{
    public static class NavigationExtensions
    {
        public static void NavigateToToken(this INavigationService navigationService, INavigationToken token)
        {
            navigationService.NavigateTo(token.GetType().FullName, token);
        }
    }
}
