using Android.App;
using Android.Runtime;
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
            new AppBootstrapper().Run();

            this.RegisterActivities();
        }

        private void RegisterActivities()
        {
            IocFactory.Instance.RegisterType<MainViewModel>();
        }
    }
}