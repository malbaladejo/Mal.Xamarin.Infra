using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using GalaSoft.MvvmLight.Helpers;
using Mal.Xamarin.Infra.Android.Fonts;
using Mal.Xamarin.Infra.DevApp.Translation;
using Mal.Xamarin.Infra.DevApp.ViewModels.Main;
using Mal.Xamarin.Infra.Navigation;

namespace Mal.Xamarin.Infra.Android.DevApp
{
    [Activity(MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : AppCompatActivity
    {
        private SimpleActivityBootstrapper bootstrapper;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            this.bootstrapper = new SimpleActivityBootstrapper(this);
            this.bootstrapper.Run(Resource.Layout.Main);
            this.bootstrapper.Toolbar.Title = this.bootstrapper.TranslationService.GetTranslation(ResourceKeys.MainActivityTitle);
            this.DataContext = this.bootstrapper.BuildDataContext<MainViewModel>();

            this.GridView.Adapter = this.DataContext.Tokens.GetAdapter(this.GetAdapter);
            this.GridView.ItemClick += GridView_ItemClick;
        }

        private void GridView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            this.DataContext.NavigateCommand.Execute(this.DataContext.Tokens[e.Position]);
        }

        private View GetAdapter(int position, INavigationToken item, View convertView)
        {
            var view = this.LayoutInflater.Inflate(Resource.Layout.MainItem, null);

            var icon = view.FindViewById<TextView>(Resource.Id.main_item_icon);
            icon.SetIconTypeface(this.Assets);
            item.SetBinding<string, string>(nameof(item.Icon),
                icon, nameof(icon.Text));

            var title = view.FindViewById<TextView>(Resource.Id.main_item_title);
            item.SetBinding<string, string>(nameof(item.Title),
                title, nameof(title.Text));

            return view;
        }

        private MainViewModel DataContext { get; set; }

        public GridView GridView => this.bootstrapper.GetView<GridView>(Resource.Id.main_gridview);
    }
}