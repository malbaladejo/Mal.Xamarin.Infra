using Android.App;
using Android.Runtime;
using Mal.Xamarin.Infra.Android.Containers;
using System;

namespace Mal.Xamarin.Infra.Android.DevApp
{
    [Application]
    public class App : Application
    {
        public App(IntPtr handle, JniHandleOwnership transfer) : base(handle, transfer)
        {

        }

        public override void OnCreate()
        {
            this.Initialize();
            base.OnCreate();
        }

        private void Initialize()
        {
            var bootstrapper = new AndroidAppBootstrapper();
            bootstrapper.Run(new AndroidAppBootstrapperStrategy());
        }
    }
}