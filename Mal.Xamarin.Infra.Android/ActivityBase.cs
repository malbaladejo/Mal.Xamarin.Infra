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
            this.DataContext = ServiceLocator.Current.GetInstance<TViewModel>();
            this.NavigationService = ServiceLocator.Current.GetInstance<NavigationService>();

            this.OnNavigatedTo(this.NavigationService.GetAndRemoveParameter<INavigationToken>(this.Intent));
        }

        protected override void OnResume()
        {
            base.OnResume();
            this.ManageBackButton();
        }

        private void ManageBackButton()
        {
            if (this.NavigationService.CurrentPageKey == NavigationService.RootPageKey)
                return;

            this.ActionBar.SetDisplayHomeAsUpEnabled(true);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            this.OnBackPressed();
            return base.OnOptionsItemSelected(item);
        }

        protected virtual void OnNavigatedTo(INavigationToken token)
        {
            // Nothing to do
        }

        protected TViewModel DataContext { get; private set; }

        protected NavigationService NavigationService { get; private set; }

        protected TView View<TView>(int id) where TView : View
        {
            if (!this.views.ContainsKey(id))
                this.views[id] = this.FindViewById<TView>(id);

            return (TView)this.views[id];
        }
    }
}