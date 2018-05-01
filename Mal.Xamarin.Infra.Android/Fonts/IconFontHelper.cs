using Android.Content.Res;
using Android.Graphics;
using Android.Text;
using Android.Text.Style;
using Android.Views;
using Android.Widget;

namespace Mal.Xamarin.Infra.Android.Fonts
{
    public static class IconFontExtensions
    {
        private static Typeface iconTypeface;

        public static void SetIconTypeface(this TextView view, AssetManager asset)
        {
            EnsureTypeFace(asset);

            view.Typeface = iconTypeface;
        }

        public static void SetIconTypeface(this Button view, AssetManager asset)
        {
            EnsureTypeFace(asset);

            view.Typeface = iconTypeface;
        }

        public static void SetIconTypeface(this IMenuItem view, AssetManager asset)
        {
            EnsureTypeFace(asset);

            var mNewTitle = new SpannableString(view.TitleFormatted);
            mNewTitle.SetSpan(new CustomTypefaceSpan("", iconTypeface), 0, mNewTitle.Length(), SpanTypes.InclusiveInclusive);
            view.SetTitle(mNewTitle);
        }

        private static void EnsureTypeFace(AssetManager asset)
        {
            if (iconTypeface == null)
                iconTypeface = Typeface.CreateFromAsset(asset, "fontawesome.ttf");
        }
    }

    public class CustomTypefaceSpan : TypefaceSpan
    {

        private readonly Typeface newType;

        public CustomTypefaceSpan(string family, Typeface type) : base(family)
        {
            newType = type;
        }

        public override void UpdateDrawState(TextPaint ds)
        {
            ApplyCustomTypeFace(ds, newType);
        }

        public override void UpdateMeasureState(TextPaint paint)
        {
            ApplyCustomTypeFace(paint, newType);
        }

        private static void ApplyCustomTypeFace(Paint paint, Typeface tf)
        {
            paint.SetTypeface(tf);
        }
    }
}