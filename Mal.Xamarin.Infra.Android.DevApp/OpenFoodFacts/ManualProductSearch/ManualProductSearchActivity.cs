using Android.App;
using Android.Content.PM;
using Android.Graphics;
using Android.Media;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using GalaSoft.MvvmLight.Helpers;
using Mal.Xamarin.Infra.DevApp.OpenFoodFacts.ViewModels.ManualProductSearch;
using ZXing;
using ZXing.Mobile;

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

            MobileBarcodeScanner.Initialize(Application);

            //var reader = new BarcodeReader();
            //// load a bitmap
            //var barcodeBitmap = (Bitmap)Image.LoadFrom("C:\\sample-barcode-image.png");
            //// detect and decode the barcode inside the bitmap
            //var result = reader.Decode(barcodeBitmap);
            //// do something with the result
            //if (result != null)
            //{
            //    txtDecoderType.Text = result.BarcodeFormat.ToString();
            //    txtDecoderContent.Text = result.Text;
            //}
        }

        private EditText Reference => this.bootstrapper.GetView<EditText>(Resource.Id.OpenFoodFactsManualProductSearch_ref);
        private Button SearchButton => this.bootstrapper.GetView<Button>(Resource.Id.OpenFoodFactsManualProductSearch_search);
        private Button ScanButton => this.bootstrapper.GetView<Button>(Resource.Id.OpenFoodFactsManualProductSearch_scan);

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