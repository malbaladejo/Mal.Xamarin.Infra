using Mal.Xamarin.Infra.Fonts;
using Mal.Xamarin.Infra.Navigation;

namespace Mal.Xamarin.Infra.Android.DevApp.CollapsibleHeader
{
    internal class CollapsibleHeaderToken : NavigationToken
    {
        public CollapsibleHeaderToken() : base(IconFont.ArrowCircleUp, "Collapsible Header")
        {
        }
    }
}