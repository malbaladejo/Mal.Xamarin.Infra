using Android.App;
using Android.OS;
using Android.Widget;
using GalaSoft.MvvmLight.Helpers;
using Mal.Xamarin.Infra.Android.Fonts;
using Mal.Xamarin.Infra.DevApp.ViewModels.Main;

namespace Mal.Xamarin.Infra.Android.DevApp
{
    [Activity(Label = "DevApp", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : ActivityBase<MainViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Icon.SetTypeface(Assets);

            this.SetBinding(() => this.DataContext.ListNavigationToken.Title, () => this.ListButton.Text);

            this.ListButton.SetCommand(nameof(this.ListButton.Click), this.DataContext.NavigateToListViewCommand);

            this.SetBinding(() => this.DataContext.Icon, () => this.Icon.Text);
        }

        public TextView Icon => this.GetView<TextView>(Resource.Id.icon);
        public Button ListButton => this.GetView<Button>(Resource.Id.listButton);
    }
}