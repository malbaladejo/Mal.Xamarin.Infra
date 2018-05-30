namespace Mal.Xamarin.Infra.DevApp.Services
{
    public class HomePageItem
    {
        public HomePageItem(string icon, string title, string description)
        {
            Icon = icon;
            Title = title;
            Description = description;
        }

        public string Icon { get; }
        public string Title { get; }
        public string Description { get; }
    }
}