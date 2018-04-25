namespace Mal.Xamarin.Infra.Navigation
{
    public class NavigationToken : INavigationToken
    {
        public NavigationToken(string icon, string title)
        {
            Icon = icon;
            Title = title;
        }

        public string Icon { get; }
        public string Title { get; }
    }
}