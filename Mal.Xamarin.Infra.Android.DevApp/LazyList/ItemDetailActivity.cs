using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using GalaSoft.MvvmLight.Helpers;
using Mal.Xamarin.Infra.DevApp.ViewModels.LazyList;

namespace Mal.Xamarin.Infra.Android.DevApp.LazyList
{
    [Activity(Label = "LazyLisItemtActivity")]
    public class ItemDetailActivity : AppCompatActivity
    {
        private SimpleActivityBootstrapper bootstrapper;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            this.bootstrapper = new SimpleActivityBootstrapper(this);
            this.bootstrapper.Run(Resource.Layout.LazyListItem);
            this.DataContext = this.bootstrapper.BuildDataContext<ItemDetailViewModel>();

            this.DataContext.Item?.SetBinding<string, string>(nameof(LazyListItemViewModel.Title),
                this.bootstrapper.GetView<TextView>(Resource.Id.lazylistitem_title),
                targetPropertyName: nameof(TextView.Text), mode: BindingMode.OneWay);

            this.DataContext.Item?.SetBinding<string, string>(nameof(LazyListItemViewModel.Title),
                this.bootstrapper.GetView<EditText>(Resource.Id.lazylistitem_edittitle),
                targetPropertyName: nameof(EditText.Text), mode: BindingMode.TwoWay);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            this.OnBackPressed();
            return base.OnOptionsItemSelected(item);
        }

        private ItemDetailViewModel DataContext { get; set; }
    }
}