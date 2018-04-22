using Android.Content.Res;
using Android.Graphics;
using Android.Widget;

namespace Mal.Xamarin.Infra.Android.Fonts
{
    public static class IconFontExtensions
    {
        private static Typeface iconTypeface;

        public static void SetTypeface(this TextView view, AssetManager asset)
        {
            if (iconTypeface == null)
                iconTypeface = Typeface.CreateFromAsset(asset, "fontawesome.ttf");

            view.Typeface = iconTypeface;
        }
    }
}