using Android.App;
using Android.OS;
using Android.Widget;
using GalaSoft.MvvmLight.Helpers;
using Mal.Xamarin.Infra.DevApp.ViewModels.LazyList;
using Mal.Xamarin.Infra.Navigation;

namespace Mal.Xamarin.Infra.Android.DevApp.LazyList
{
    [Activity(Label = "LazyLisItemtActivity")]
    public class ItemDetailActivity : ActivityBase<ItemDetailViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            SetContentView(Resource.Layout.LazyListItem);
            base.OnCreate(savedInstanceState);
        }

        protected override void OnNavigatedTo(INavigationToken token)
        {
            base.OnNavigatedTo(token);

            this.DataContext.Item?.SetBinding<string, string>(nameof(LazyListItemViewModel.Title),
                this.GetView<TextView>(Resource.Id.lazylistitem_title),
                targetPropertyName: nameof(TextView.Text), mode: BindingMode.OneWay);

            this.DataContext.Item?.SetBinding<string, string>(nameof(LazyListItemViewModel.Title),
                this.GetView<EditText>(Resource.Id.lazylistitem_edittitle),
                targetPropertyName: nameof(EditText.Text), mode:BindingMode.TwoWay);
        }
    }
}