using Android.App;
using Android.Runtime;
using Mal.Xamarin.Infra.Android.Containers;
using Mal.Xamarin.Infra.DevApp;
using Mal.Xamarin.Infra.DevApp.ViewModels;
using System;
using Unity;

namespace Mal.Xamarin.Infra.Android.DevApp
{
    [Application]
    public class App : ApplicationBase
    {
        public App(IntPtr handle, JniHandleOwnership transfer) : base(handle, transfer)
        {

        }

        public override void OnCreate()
        {
            this.Initialize();
            base.OnCreate();
        }

        public static UnityContainer Container { get; set; }

        private void Initialize()
        {
            var bootstrapper = new AndroidAppBootstrapper();
            var container = bootstrapper.Run(new AppBootstrapperStrategy());

            this.RegisterActivities();
        }

        private void RegisterActivities()
        {
            IocFactory.Instance.RegisterType<MainViewModel>();
        }
    }
}