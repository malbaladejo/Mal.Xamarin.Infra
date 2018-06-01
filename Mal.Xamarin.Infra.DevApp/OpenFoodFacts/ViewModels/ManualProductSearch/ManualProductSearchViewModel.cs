using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Mal.Xamarin.Infra.DevApp.OpenFoodFacts.Services;
using System;
using System.Windows.Input;

namespace Mal.Xamarin.Infra.DevApp.OpenFoodFacts.ViewModels.ManualProductSearch
{
    public class ManualProductSearchViewModel : ViewModelBase
    {
        private readonly IOpenFoodFactsService openFoodFactsService;
        private string reference;
        private readonly RelayCommand searchCommand;
        private readonly RelayCommand scanCommand;

        public ManualProductSearchViewModel(IOpenFoodFactsService openFoodFactsService)
        {
            this.openFoodFactsService = openFoodFactsService;
            this.searchCommand = new RelayCommand(this.Search, this.CanSearch);
            this.scanCommand = new RelayCommand(this.Scan);
        }

        private bool CanSearch() => !string.IsNullOrWhiteSpace(this.reference);

        private async void Search()
        {
            try
            {
                var product = await this.openFoodFactsService.GetProductAsync(this.reference);
            }
            catch (Exception e)
            {

            }
        }

        private async void Scan()
        {
            try
            {

                var scanner = new ZXing.Mobile.MobileBarcodeScanner();
                scanner.CancelButtonText = "cancel";
                scanner.BottomText = "en bas";
                scanner.FlashButtonText = "flash";
                scanner.TopText = "en haut";
                var result = await scanner.Scan();

                if (result == null)
                    return;

                this.Reference = result.Text;
                this.Search();
            }
            catch
            {

            }
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
        public ICommand ScanCommand => this.scanCommand;
    }
}
