using Mal.Xamarin.Infra.Fonts;
using Mal.Xamarin.Infra.Navigation;

namespace Mal.Xamarin.Infra.DevApp.ViewModels.LazyList
{
    public class LazyListNavigationToken : NavigationToken
    {
        public LazyListNavigationToken()
            : base(IconFont.List, "List view")
        {
        }
    }
}