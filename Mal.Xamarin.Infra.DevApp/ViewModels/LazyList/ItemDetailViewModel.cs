using GalaSoft.MvvmLight;
using Mal.Xamarin.Infra.Navigation;

namespace Mal.Xamarin.Infra.DevApp.ViewModels.LazyList
{
    public class ItemDetailViewModel : ViewModelBase, INavigationAware
    {
        public void OnNavigatedTo(object token)
        {
            this.Item = (token as LazyListItemNavigationToken)?.Item;
        }

        public LazyListItemViewModel Item { get; set; }

        public void OnNavigatedFrom(object token)
        {
            // Nothing to do
        }
    }
}
