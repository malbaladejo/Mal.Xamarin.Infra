using Android.App;
using Android.Runtime;
using System;

namespace Mal.Xamarin.Infra.Android
{
    public abstract class ApplicationBase : Application
    {
        protected ApplicationBase(IntPtr handle, JniHandleOwnership transfer)
            : base(handle, transfer)
        {

        }
    }
}
