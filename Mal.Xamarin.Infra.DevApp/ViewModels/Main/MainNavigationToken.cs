using Mal.Xamarin.Infra.Fonts;
using Mal.Xamarin.Infra.Navigation;

namespace Mal.Xamarin.Infra.DevApp.ViewModels.Main
{
    public class MainNavigationToken : NavigationToken
    {
        public MainNavigationToken() : base(IconFont.Home, "Home")
        {
        }
    }
}
