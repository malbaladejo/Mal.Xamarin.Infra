using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Mal.Xamarin.Infra.Fonts;
using Mal.Xamarin.Infra.Navigation;
using System.Windows.Input;
using Mal.Xamarin.Infra.DevApp.ViewModels.LazyList;

namespace Mal.Xamarin.Infra.DevApp.ViewModels.Main
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel(INavigationService navigationService)
        {
            this.NavigateToListViewCommand =
                new RelayCommand(() => navigationService.NavigateToToken(new LazyListNavigationToken()));
        }

        public INavigationToken ListNavigationToken { get; } = new LazyListNavigationToken();

        public string Icon => IconFont.Android;

        public ICommand NavigateToListViewCommand { get; }
    }
}
