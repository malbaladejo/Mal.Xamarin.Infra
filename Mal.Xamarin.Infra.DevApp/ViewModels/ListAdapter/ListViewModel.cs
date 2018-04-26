using GalaSoft.MvvmLight;
using Mal.XF.Infra.Collections;

namespace Mal.Xamarin.Infra.DevApp.ViewModels.ListAdapter
{
    public class ListViewModel : ViewModelBase
    {
        private readonly ILoadItemsStrategy<ListViewItem> loadItemsStrategy;

        public ListViewModel()
        {
            this.loadItemsStrategy = new LoadItemsStrategy();
            this.Items = new LazyObservableCollection<ListViewItem>(this.loadItemsStrategy, 10);
        }

        public LazyObservableCollection<ListViewItem> Items { get; }
    }
}
