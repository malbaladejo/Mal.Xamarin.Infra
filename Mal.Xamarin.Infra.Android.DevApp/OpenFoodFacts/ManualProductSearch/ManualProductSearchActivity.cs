using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using GalaSoft.MvvmLight.Helpers;
using Mal.Xamarin.Infra.Android.Converters;
using Mal.Xamarin.Infra.DevApp.OpenFoodFacts.ViewModels.ManualProductSearch;
using ZXing.Mobile;
using AndroidViews = Android.Views;
namespace Mal.Xamarin.Infra.Android.DevApp.OpenFoodFacts.ManualSearch
{
    [Activity(Label = "Search")]
    public class ManualProductSearchActivity : AppCompatActivity
    {
        private SimpleActivityBootstrapper bootstrapper;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            this.bootstrapper = new SimpleActivityBootstrapper(this);
            this.bootstrapper.Run(Resource.Layout.OpenFoodFactsManualProductSearch);
            this.bootstrapper.Toolbar.Title = "Manual search";
            this.DataContext = this.bootstrapper.BuildDataContext<ManualProductSearchViewModel>();

            this.DataContext.SetBinding<string, string>(nameof(this.DataContext.Reference),
                this.Reference, nameof(EditText.Text), mode: BindingMode.TwoWay);

            this.SearchButton.SetCommand(nameof(Button.Click), this.DataContext.SearchCommand);
            this.ScanButton.SetCommand(nameof(Button.Click), this.DataContext.ScanCommand);

            var progressBarBinding = this.DataContext.SetBinding<bool, AndroidViews.ViewStates>(nameof(this.DataContext.IsSearchInProgress),
                                        this.ProgressBar, nameof(this.ProgressBar.Visibility));
            progressBarBinding.ConvertSourceToTarget(BoolToViewStatesConverter.TrueToVisibleInstance.Convert);

            this.DataContext.SetBinding<string, string>(nameof(this.DataContext.ProductName),
                this.ProductName, nameof(TextView.Text));

            this.DataContext.SetBinding<string, string>(nameof(this.DataContext.ProductBrand),
                this.ProductBrand, nameof(TextView.Text));

            this.DataContext.SetBinding<string, string>(nameof(this.DataContext.ProductNutriScore),
                this.NutriScore, nameof(TextView.Text));

            MobileBarcodeScanner.Initialize(Application);
        }       

        private EditText Reference => this.bootstrapper.GetView<EditText>(Resource.Id.OpenFoodFactsManualProductSearch_ref);
        private Button SearchButton => this.bootstrapper.GetView<Button>(Resource.Id.OpenFoodFactsManualProductSearch_search);
        private Button ScanButton => this.bootstrapper.GetView<Button>(Resource.Id.OpenFoodFactsManualProductSearch_scan);
        private ProgressBar ProgressBar => this.bootstrapper.GetView<ProgressBar>(Resource.Id.OpenFoodFactsManualProductSearch_busyindicator);
        private TextView ProductName => this.bootstrapper.GetView<TextView>(Resource.Id.OpenFoodFactsManualProductSearch_productName);
        private TextView ProductBrand => this.bootstrapper.GetView<TextView>(Resource.Id.OpenFoodFactsManualProductSearch_productBrand);
        private TextView NutriScore => this.bootstrapper.GetView<TextView>(Resource.Id.OpenFoodFactsManualProductSearch_nutriScore);

        private ManualProductSearchViewModel DataContext { get; set; }

        protected override void OnResume()
        {
            base.OnResume();

            if (ZXing.Net.Mobile.Android.PermissionsHandler.NeedsPermissionRequest(this))
                ZXing.Net.Mobile.Android.PermissionsHandler.RequestPermissionsAsync(this);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            global::ZXing.Net.Mobile.Android.PermissionsHandler.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}