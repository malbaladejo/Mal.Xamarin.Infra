using Android.Views;
using System;

namespace Mal.Xamarin.Infra.Android.Converters
{
    public class BoolToViewStatesConverter
    {
        private static Lazy<BoolToViewStatesConverter> LazyTrueToVisibleInstance = new Lazy<BoolToViewStatesConverter>(() => new BoolToViewStatesConverter(false));
        public static BoolToViewStatesConverter TrueToVisibleInstance => LazyTrueToVisibleInstance.Value;

        private static Lazy<BoolToViewStatesConverter> LazyFalseToVisibleInstance = new Lazy<BoolToViewStatesConverter>(() => new BoolToViewStatesConverter(true));
        public static BoolToViewStatesConverter FalseToVisibleInstance => LazyFalseToVisibleInstance.Value;

        private readonly bool inverse;

        private BoolToViewStatesConverter(bool inverse)
        {
            this.inverse = inverse;
        }

        public ViewStates Convert(bool value)
        {
            return (inverse ? !value : value) ? ViewStates.Visible : ViewStates.Invisible;
        }
    }
}