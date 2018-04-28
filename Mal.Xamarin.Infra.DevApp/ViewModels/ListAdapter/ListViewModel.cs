using GalaSoft.MvvmLight;
using Mal.XF.Infra.Collections;

namespace Mal.Xamarin.Infra.DevApp.ViewModels.ListAdapter
{
    public class ListViewModel : ViewModelBase
    {
        private readonly ILoadItemsStrategy<ListViewItem> loadItemsStrategy;
        private ListViewItem selectedItem;
        private bool multiSelectionEnabled;

        public ListViewModel()
        {
            this.loadItemsStrategy = new LoadItemsStrategy();
            this.Items = new LazyObservableCollection<ListViewItem>(this.loadItemsStrategy, 10);
        }

        public LazyObservableCollection<ListViewItem> Items { get; }

        public ListViewItem SelectedItem
        {
            get { return this.selectedItem; }
            set { this.Set(ref this.selectedItem, value); }
        }

        public bool MultiSelectionEnabled
        {
            get { return this.multiSelectionEnabled; }
            set
            {
                this.Set(ref this.multiSelectionEnabled, value);

                if (this.MultiSelectionEnabled)
                    return;

                foreach (var item in this.Items)
                    item.IsSelected = false;
            }
        }
    }
}
