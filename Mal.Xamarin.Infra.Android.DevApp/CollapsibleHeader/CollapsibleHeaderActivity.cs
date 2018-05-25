
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using GalaSoft.MvvmLight.Helpers;

namespace Mal.Xamarin.Infra.Android.DevApp.CollapsibleHeader
{
    [Activity(Label = "CollapsibleHeaderActivity")]
    public class CollapsibleHeaderActivity : AppCompatActivity
    {
        private AppCompatActivityBootstrapper bootstrapper;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            this.bootstrapper = new AppCompatActivityBootstrapper(this);
            this.bootstrapper.SetContentView(Resource.Layout.CollapsibleHeader);
            this.DataContext = this.bootstrapper.BuildDataContext<CollapsibleHeaderViewModel>();
            this.bootstrapper.BuildToolbar(Resource.Id.collapsibleheader_toolbar).Title = "Collapsible Header";
            this.Items.Adapter = this.DataContext.Items.GetAdapter(this.GetAdapter);
        }

        private View GetAdapter(int position, CollapsibleHeaderItemViewModel item, View convertView)
        {
            var view = this.LayoutInflater.Inflate(Resource.Layout.CollapsibleheaderItemTemplate, null);

            var itemText = view.FindViewById<TextView>(Resource.Id.collapsibleitem_item);
            item.SetBinding<string, string>(nameof(item.Text),
                itemText, nameof(itemText.Text));

            return view;
        }

        private CollapsibleHeaderViewModel DataContext { get; set; }

        private ListView Items => this.bootstrapper.GetView<ListView>(Resource.Id.collapsibleheader_items);
    }
}