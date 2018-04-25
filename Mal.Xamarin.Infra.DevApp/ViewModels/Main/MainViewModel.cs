using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Mal.Xamarin.Infra.DevApp.ViewModels.ListAdapter;
using Mal.Xamarin.Infra.Fonts;
using Mal.Xamarin.Infra.Navigation;
using System.Windows.Input;

namespace Mal.Xamarin.Infra.DevApp.ViewModels.Main
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel(INavigationService navigationService)
        {
            this.NavigateToListViewCommand =
                new RelayCommand(() => navigationService.NavigateToToken(new ListNavigationToken()));
        }

        public INavigationToken ListNavigationToken { get; } = new ListNavigationToken();

        public string Icon => IconFont.Android;

        public ICommand NavigateToListViewCommand { get; }
    }
}
