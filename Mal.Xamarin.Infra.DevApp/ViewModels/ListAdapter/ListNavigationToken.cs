using Mal.Xamarin.Infra.Fonts;
using Mal.Xamarin.Infra.Navigation;

namespace Mal.Xamarin.Infra.DevApp.ViewModels.ListAdapter
{
    public class ListNavigationToken : NavigationToken
    {
        public ListNavigationToken()
            : base(IconFont.List, "List view")
        {
        }
    }
}