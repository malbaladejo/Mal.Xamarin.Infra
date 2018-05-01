namespace Mal.Xamarin.Infra.Navigation
{
    public interface INavigationAware
    {
        /// <summary>Called when the implementer has been navigated to.</summary>
        /// <param name="token">The navigation context.</param>
        void OnNavigatedTo(object token);

        /// <summary>
        /// Called when the implementer is being navigated away from.
        /// </summary>
        /// <param name="token">The navigation context.</param>
        void OnNavigatedFrom(object token);
    }
}
