using Android.App;
using Android.Views;
using Mal.Xamarin.Infra.Android.Navigation;
using Mal.Xamarin.Infra.Containers;
using Mal.Xamarin.Infra.Navigation;
using System.Collections.Generic;

namespace Mal.Xamarin.Infra.Android
{
    public class ActivityBootstrapper
    {
        private readonly Activity activity;
        private readonly Dictionary<int, View> views;
        private View innerView;

        public ActivityBootstrapper(Activity activity)
        {
            this.views = new Dictionary<int, View>();
            this.activity = activity;
            this.NavigationService.CurrentActivity = activity;

        }

        public TViewModel BuildDataContext<TViewModel>()
        {
            var dataContext = GetDataContext<TViewModel>();
            var token = NavigationService.GetAndRemoveParameter<INavigationToken>(this.activity.Intent);
            (dataContext as INavigationAware)?.OnNavigatedTo(token);
            return dataContext;
        }

        public void SetContentView(int layoutResourceId)
        {
            this.activity.SetContentView(layoutResourceId);
        }

        public void SetInnerContentView(int innerLayoutResourceId, int innerContainerId)
        {
            this.innerView = this.activity.LayoutInflater.Inflate(innerLayoutResourceId, null);
            this.GetView<ViewGroup>(innerContainerId).AddView(this.innerView);
        }

        public TView GetView<TView>(int id) where TView : View
        {
            if (!this.views.ContainsKey(id))
            {
                var view = this.GetViewFromActivityLayout<TView>(id);

                if (view != null)
                    this.views[id] = view;

                view = this.GetViewFromInnerActivityLayout<TView>(id);

                if (view != null)
                    this.views[id] = view;
            }

            return (TView)this.views[id];
        }

        private TView GetViewFromActivityLayout<TView>(int id) where TView : View
            => this.activity.FindViewById<TView>(id);

        private TView GetViewFromInnerActivityLayout<TView>(int id) where TView : View
            => this.innerView?.FindViewById<TView>(id);

        public void BuildToolbar()
        {
            if (this.NavigationService.CurrentPageKey == NavigationService.RootPageKey)
                return;

            this.activity.ActionBar?.SetDisplayHomeAsUpEnabled(true);
        }

        protected IAndroidNavigationService NavigationService =>
            ServiceLocator.Current.GetInstance<IAndroidNavigationService>();


        private TViewModel GetDataContext<TViewModel>()
        {
            var dataContext = default(TViewModel);
            ServiceLocator.Current.TryGetInstance(ref dataContext);
            return dataContext;
        }
    }
}