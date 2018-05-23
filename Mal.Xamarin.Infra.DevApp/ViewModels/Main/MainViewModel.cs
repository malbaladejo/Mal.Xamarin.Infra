using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Mal.Xamarin.Infra.DevApp.ViewModels.BurgerMenu;
using Mal.Xamarin.Infra.DevApp.ViewModels.LazyList;
using Mal.Xamarin.Infra.Navigation;
using System.Collections.ObjectModel;
using Mal.Xamarin.Infra.Services;

namespace Mal.Xamarin.Infra.DevApp.ViewModels.Main
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel(INavigationService navigationService, IServiceProvider<INavigationToken> mainItemServiceProvider)
        {
            this.NavigateCommand = new RelayCommand<INavigationToken>(navigationService.NavigateToToken);
            this.Tokens = new ObservableCollection<INavigationToken>(mainItemServiceProvider.Items);
        }

        public ObservableCollection<INavigationToken> Tokens { get; }

        public RelayCommand<INavigationToken> NavigateCommand { get; }
    }
}
