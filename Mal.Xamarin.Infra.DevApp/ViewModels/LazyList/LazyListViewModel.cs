using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Mal.Xamarin.Infra.Navigation;
using Mal.XF.Infra.Collections;
using System.Windows.Input;

namespace Mal.Xamarin.Infra.DevApp.ViewModels.LazyList
{
    public class LazyListViewModel : ViewModelBase
    {
        private readonly INavigationService navigationService;
        private LazyListItemViewModel selectedItem;
        private bool multiSelectionEnabled;

        public LazyListViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            this.Items = new LazyObservableCollection<LazyListItemViewModel>(new LoadItemsStrategy(), 10);

            this.SelectItemCommand = new RelayCommand<LazyListItemViewModel>(this.SelectItem);
            this.EnableMultiSelectCommand = new RelayCommand<LazyListItemViewModel>(this.EnableMultiSelect);
        }

        private void EnableMultiSelect(LazyListItemViewModel item)
        {
            this.MultiSelectionEnabled = true;
            item.IsSelected = true;
        }

        private void SelectItem(LazyListItemViewModel item)
        {
            if (this.MultiSelectionEnabled)
            {
                item.IsSelected = !item.IsSelected;
                return;
            }

            this.navigationService.NavigateToToken(new LazyListItemNavigationToken(item));
        }

        public LazyObservableCollection<LazyListItemViewModel> Items { get; }

        public ICommand SelectItemCommand { get; }

        public ICommand EnableMultiSelectCommand { get; }

        public LazyListItemViewModel SelectedItem
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
