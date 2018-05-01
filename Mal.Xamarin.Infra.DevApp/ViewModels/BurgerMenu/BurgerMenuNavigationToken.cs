using Mal.Xamarin.Infra.Fonts;
using Mal.Xamarin.Infra.Navigation;

namespace Mal.Xamarin.Infra.DevApp.ViewModels.BurgerMenu
{
    public class BurgerMenuNavigationToken : NavigationToken
    {
        public BurgerMenuNavigationToken() : base(IconFont.Bars, "Bruger Menu")
        {
        }
    }
}
