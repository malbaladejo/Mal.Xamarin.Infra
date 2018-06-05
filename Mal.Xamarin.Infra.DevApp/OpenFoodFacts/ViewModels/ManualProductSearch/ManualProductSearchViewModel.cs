using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Mal.Xamarin.Infra.DevApp.OpenFoodFacts.Services;
using Mal.Xamarin.Infra.DevApp.OpenFoodFacts.Services.Data;
using Mal.Xamarin.Infra.DevApp.Translation;
using Mal.Xamarin.Infra.Translation;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace Mal.Xamarin.Infra.DevApp.OpenFoodFacts.ViewModels.ManualProductSearch
{
    public class ManualProductSearchViewModel : ViewModelBase
    {
        private readonly IOpenFoodFactsService openFoodFactsService;
        private readonly IDialogService dialogService;
        private readonly ITranslationService translationService;
        private string reference;
        private readonly RelayCommand searchCommand;
        private readonly RelayCommand scanCommand;
        private bool isSearchInProgress;
        private bool isScanInProgress;
        private Product product;

        public ManualProductSearchViewModel(IOpenFoodFactsService openFoodFactsService,
                                            IDialogService dialogService,
                                            ITranslationService translationService)
        {
            this.openFoodFactsService = openFoodFactsService;
            this.dialogService = dialogService;
            this.translationService = translationService;
            this.searchCommand = new RelayCommand(this.Search, this.CanSearch);
            this.scanCommand = new RelayCommand(this.Scan, this.CanScan);
        }

        private bool CanSearch() => !this.IsSearchInProgress && !string.IsNullOrWhiteSpace(this.reference);

        private async void Search()
        {
            try
            {
                this.IsSearchInProgress = true;
                this.Product = await this.openFoodFactsService.GetProductAsync(this.reference);
                this.IsSearchInProgress = false;
            }
            catch (Exception e)
            {
                this.IsSearchInProgress = false;
                this.dialogService.ShowError(e,
                    this.translationService.GetTranslation(ResourceKeys.Error),
                    this.translationService.GetTranslation(ResourceKeys.OK), () => { });
            }
            finally
            {
                this.IsSearchInProgress = false;
            }
        }

        private bool CanScan() => !this.IsScanInProgress;

        private async void Scan()
        {
            try
            {
                this.IsScanInProgress = true;
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
            catch (Exception e)
            {
                this.IsScanInProgress = false;
                await this.dialogService.ShowError(e,
                    this.translationService.GetTranslation(ResourceKeys.Error),
                    this.translationService.GetTranslation(ResourceKeys.OK), () => { });
            }
            finally
            {
                this.IsScanInProgress = false;
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

        public bool IsSearchInProgress
        {
            get { return this.isSearchInProgress; }
            set
            {
                if (this.Set(ref this.isSearchInProgress, value))
                    this.searchCommand.RaiseCanExecuteChanged();
            }
        }

        public bool IsScanInProgress
        {
            get { return this.isScanInProgress; }
            set
            {
                if (this.Set(ref this.isScanInProgress, value))
                    this.scanCommand.RaiseCanExecuteChanged();
            }
        }

        private Product Product
        {
            get { return this.product; }
             set {
                if (!this.Set(ref this.product, value))
                    return;

                this.RaisePropertyChanged(nameof(this.ProductName));
                this.RaisePropertyChanged(nameof(this.ProductBrand));
                this.RaisePropertyChanged(nameof(this.ProductNutriScore));
                this.RaisePropertyChanged(nameof(this.ProductPictureUrl));
                this.RaisePropertyChanged(nameof(this.ProductAdditives));
            }
        }

        public string ProductName => this.Product?.Name;
        public string ProductBrand => this.Product?.Brand;
        public string ProductNutriScore => this.Product?.NutriScore;
        public string ProductPictureUrl => this.Product?.PictureUrl;
        public IReadOnlyCollection<Additive> ProductAdditives => this.Product?.Additives ?? new Additive[0];
    }
}
