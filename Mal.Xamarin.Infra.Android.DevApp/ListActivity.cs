
using Android.App;
using Android.OS;
using Mal.Xamarin.Infra.DevApp.ViewModels.ListAdapter;
using Mal.Xamarin.Infra.Navigation;

namespace Mal.Xamarin.Infra.Android.DevApp
{
    [Activity(Label = "List")]
    public class ListActivity : ActivityBase<ListViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.List);
        }

        protected override void OnNavigatedTo(INavigationToken token)
        {
            base.OnNavigatedTo(token);
        }
    }
}