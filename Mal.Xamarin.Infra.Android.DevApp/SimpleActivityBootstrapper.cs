using Android.Support.V7.App;
using Android.Support.V7.Widget;

namespace Mal.Xamarin.Infra.Android.DevApp
{
    internal class SimpleActivityBootstrapper : AppCompatActivityBootstrapper
    {
        public SimpleActivityBootstrapper(AppCompatActivity activity) : base(activity)
        {
        }

        public void Run(int innerViewLayoutId)
        {
            this.SetContentView(Resource.Layout.ActivityWithToolbarLayout);
            this.SetInnerContentView(innerViewLayoutId, Resource.Id.activitywithtoolbar_content_frame);
            this.BuildToolbar(Resource.Id.activitywithtoolbar_toolbar);
        }

        public Toolbar Toolbar => this.GetView<Toolbar>(Resource.Id.activitywithtoolbar_toolbar);
    }
}