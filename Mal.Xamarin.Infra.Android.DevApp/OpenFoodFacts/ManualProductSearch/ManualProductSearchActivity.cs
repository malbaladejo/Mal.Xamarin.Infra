
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using GalaSoft.MvvmLight.Helpers;
using Mal.Xamarin.Infra.DevApp.OpenFoodFacts.ViewModels.ManualProductSearch;

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
        }

        private EditText Reference => this.bootstrapper.GetView<EditText>(Resource.Id.OpenFoodFactsManualProductSearch_ref);
        private Button SearchButton => this.bootstrapper.GetView<Button>(Resource.Id.OpenFoodFactsManualProductSearch_search);

        private ManualProductSearchViewModel DataContext { get; set; }
    }
}