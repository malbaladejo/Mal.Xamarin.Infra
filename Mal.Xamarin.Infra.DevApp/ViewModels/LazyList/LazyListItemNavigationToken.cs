using Mal.Xamarin.Infra.Fonts;
using Mal.Xamarin.Infra.Navigation;

namespace Mal.Xamarin.Infra.DevApp.ViewModels.LazyList
{
    public class LazyListItemNavigationToken : NavigationToken
    {
        public LazyListItemViewModel Item { get; }

        public LazyListItemNavigationToken(LazyListItemViewModel item)
            : base(IconFont.List, "List view")
        {
            Item = item;
        }
    }
}