using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Mal.Xamarin.Infra.DevApp.OpenFoodFacts.Services;
using System.Windows.Input;

namespace Mal.Xamarin.Infra.DevApp.OpenFoodFacts.ViewModels.ManualProductSearch
{
    public class ManualProductSearchViewModel : ViewModelBase
    {
        private readonly IOpenFoodFactsService openFoodFactsService;
        private string reference;
        private readonly RelayCommand searchCommand;

        public ManualProductSearchViewModel(IOpenFoodFactsService openFoodFactsService)
        {
            this.openFoodFactsService = openFoodFactsService;
            this.searchCommand = new RelayCommand(this.Search, this.CanSearch);
        }

        private bool CanSearch() => !string.IsNullOrWhiteSpace(this.reference);

        private async void Search()
        {
            var product = await this.openFoodFactsService.GetProductAsync(this.reference);
        }

        public string Reference
        {
            get { return this.reference; }
            set
            {
                if (this.Set(ref this.reference, value))
                    this.searchCommand.RaiseCanExecuteChanged();
            }
        }

        public ICommand SearchCommand => this.searchCommand;
    }
}
