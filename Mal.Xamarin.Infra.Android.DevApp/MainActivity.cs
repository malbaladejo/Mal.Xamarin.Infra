using Android.App;
using Android.OS;
using Android.Widget;
using GalaSoft.MvvmLight.Helpers;
using Mal.Xamarin.Infra.Android.Fonts;
using Mal.Xamarin.Infra.DevApp.ViewModels;

namespace Mal.Xamarin.Infra.Android.DevApp
{
    [Activity(Label = "Mal.Xamarin.Infra.Android.DevApp", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : ActivityBase<MainViewModel>
    {
        int count = 1;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            Icon.SetTypeface(Assets);

            this.SetBinding(() => this.DataContext.Icon, () => this.Icon.Text);
        }

        public TextView Icon => this.IconView(Resource.Id.icon);
    }
}