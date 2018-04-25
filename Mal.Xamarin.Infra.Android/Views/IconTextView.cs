using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Widget;
using Mal.Xamarin.Infra.Android.Fonts;
using System;

namespace Mal.Xamarin.Infra.Android.Views
{
    [Register("mal.xamarin.infra.android.views.IconTextView")]
    public class IconTextView : TextView
    {
        protected IconTextView(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {

        }

        public IconTextView(Context context) : base(context)
        {
            this.Initialze(context);
        }

        public IconTextView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            this.Initialze(context);
        }

        public IconTextView(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
            this.Initialze(context);
        }

        public IconTextView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
        {
            this.Initialze(context);
        }

        private void Initialze(Context context)
        {
            this.SetTypeface(context.Assets);
        }
    }
}