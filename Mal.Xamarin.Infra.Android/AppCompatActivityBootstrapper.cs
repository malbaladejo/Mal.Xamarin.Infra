using Android.Support.V7.App;
using Android.Support.V7.Widget;

namespace Mal.Xamarin.Infra.Android
{
    public class AppCompatActivityBootstrapper : ActivityBootstrapper
    {
        private readonly AppCompatActivity activity;

        public AppCompatActivityBootstrapper(AppCompatActivity activity) : base(activity)
        {
            this.activity = activity;
        }

        protected AppCompatActivity AppCompatActivity => this.activity;

        public void BuildToolbar(int toolbarId)
        {
            var toolbar = this.GetView<Toolbar>(toolbarId);
            // HACK: si toolbar.Title est null avant SetSupportActionBar, les champs de title ne seront pas pris en compte par la suite.
            // Mettre un title non null permet de le modifier plus tard.
            // https://stackoverflow.com/questions/26486730/in-android-app-toolbar-settitle-method-has-no-effect-application-name-is-shown#26506858
            toolbar.Title = string.Empty;
            this.activity.SetSupportActionBar(toolbar);

            if (this.NavigationService.CurrentPageKey == NavigationService.RootPageKey)
                return;

            this.activity.SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            this.activity.SupportActionBar.SetHomeButtonEnabled(true);
        }
    }
}