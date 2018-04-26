
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using Mal.Xamarin.Infra.DevApp.ViewModels.ListAdapter;

namespace Mal.Xamarin.Infra.Android.DevApp
{
    [Activity(Label = "List")]
    public class ListActivity : ActivityBase<ListViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.List);

            ListViewAdapter<ListViewItem>.Build(this.Items, this.DataContext.Items, this.GetAdapter, this.LayoutInflater);
        }

        public ListView Items => this.View<ListView>(Resource.Id.items);

        private View GetAdapter(ListViewItem item)
        {
            // Not reusing views here
            var view = this.LayoutInflater.Inflate(Resource.Layout.ListItemTemplate, null);
            view.FindViewById<TextView>(Resource.Id.title).Text = item.Index.ToString();

            return view;
        }
    }
}