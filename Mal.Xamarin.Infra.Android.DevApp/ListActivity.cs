
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using GalaSoft.MvvmLight.Helpers;
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
            this.Items.SetBinding<ListViewItem, ListViewItem>(nameof(this.Items.SelectedItem),
                                                                this.DataContext, nameof(this.DataContext.SelectedItem), BindingMode.TwoWay);
        }

        public ListView Items => this.GetView<ListView>(Resource.Id.list_items);

        private View GetAdapter(ListViewItem item)
        {
            var view = this.LayoutInflater.Inflate(Resource.Layout.ListItemTemplate, null);

            item.SetBinding<int, string>(nameof(item.Index), view.FindViewById<TextView>(Resource.Id.listviewtemplate_index),
                                         nameof(TextView.Text), BindingMode.OneWay);

            item.SetBinding<string, string>(nameof(item.Title), view.FindViewById<TextView>(Resource.Id.listviewtemplate_title),
                                         nameof(TextView.Text), BindingMode.OneWay);

            return view;
        }
    }
}