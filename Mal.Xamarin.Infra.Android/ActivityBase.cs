using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using Mal.Xamarin.Infra.Android.Fonts;
using System.Collections.Generic;
using System.ComponentModel;

namespace Mal.Xamarin.Infra.Android
{
    public abstract class ActivityBase<TViewModel> : Activity where TViewModel : INotifyPropertyChanged
    {
        private readonly Dictionary<int, View> views;

        public ActivityBase()
        {
            this.views = new Dictionary<int, View>();
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            this.DataContext = IocFactory.Instance.Resolve<TViewModel>();
        }

        protected TViewModel DataContext { get; private set; }


        protected TView View<TView>(int id) where TView : View
        {
            if (!this.views.ContainsKey(id))
                this.views[id] = this.FindViewById<TView>(id);

            return (TView)this.views[id];
        }

        protected TextView IconView(int id)
        {
            var view = this.View<TextView>(id);
            view.SetTypeface(this.Assets);

            return view;
        }

    }
}