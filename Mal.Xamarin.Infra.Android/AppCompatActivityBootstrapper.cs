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
            this.activity.SetSupportActionBar(toolbar);

            if (this.NavigationService.CurrentPageKey == NavigationService.RootPageKey)
                return;

            this.activity.SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            this.activity.SupportActionBar.SetHomeButtonEnabled(true);
        }
    }
}