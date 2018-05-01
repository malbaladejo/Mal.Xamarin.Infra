using Android.OS;
using Android.Views;
using GalaSoft.MvvmLight.Views;
using Mal.Xamarin.Infra.Containers;
using Mal.Xamarin.Infra.Navigation;
using System.Collections.Generic;
using System.ComponentModel;

namespace Mal.Xamarin.Infra.Android
{
    public abstract class ActivityBase<TViewModel> : ActivityBase where TViewModel : INotifyPropertyChanged
    {
        private readonly Dictionary<int, View> views;

        protected ActivityBase()
        {
            this.views = new Dictionary<int, View>();
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            this.SetDataContext();

            this.SetContentView();

            this.NavigationService = ServiceLocator.Current.GetInstance<NavigationService>();
            this.OnNavigatedTo(this.NavigationService.GetAndRemoveParameter<INavigationToken>(this.Intent));
        }

        protected override void OnResume()
        {
            base.OnResume();
            this.ManageBackButton();
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            this.OnBackPressed();
            return base.OnOptionsItemSelected(item);
        }

        protected virtual void OnNavigatedTo(INavigationToken token)
        {
            // ReSharper disable once SuspiciousTypeConversion.Global
            (this.DataContext as INavigationAware)?.OnNavigatedTo(token);
        }

        protected TViewModel DataContext { get; private set; }

        protected NavigationService NavigationService { get; private set; }

        protected TView GetView<TView>(int id) where TView : View
        {
            if (!this.views.ContainsKey(id))
                this.views[id] = this.FindViewById<TView>(id);

            return (TView)this.views[id];
        }

        private void SetDataContext()
        {
            TViewModel dataContext = default(TViewModel);
            if (ServiceLocator.Current.TryGetInstance(ref dataContext))
                this.DataContext = dataContext;
        }

        private void SetContentView()
        {
            var layoutResourceId = 0;
            if (ServiceLocator.Current.TryGetInstance(ref layoutResourceId, this.GetType().FullName))
                SetContentView(layoutResourceId);
        }

        private void ManageBackButton()
        {
            if (this.NavigationService.CurrentPageKey == NavigationService.RootPageKey)
                return;

            this.ActionBar.SetDisplayHomeAsUpEnabled(true);
        }
    }
}