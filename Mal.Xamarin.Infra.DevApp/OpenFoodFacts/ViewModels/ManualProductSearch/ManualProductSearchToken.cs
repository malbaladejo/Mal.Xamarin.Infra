using Mal.Xamarin.Infra.Fonts;
using Mal.Xamarin.Infra.Navigation;

namespace Mal.Xamarin.Infra.DevApp.OpenFoodFacts.ViewModels.ManualProductSearch
{
    public class ManualProductSearchToken : NavigationToken
    {
        public ManualProductSearchToken() : base(IconFont.Search, "Manual search")
        {
        }
    }
}