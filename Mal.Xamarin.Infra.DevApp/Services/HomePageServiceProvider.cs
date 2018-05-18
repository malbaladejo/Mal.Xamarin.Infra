using Mal.Xamarin.Infra.Services;

namespace Mal.Xamarin.Infra.DevApp.Services
{
    internal class HomePageServiceProvider : ServiceProvider<HomePageItem>, IHomePageServiceRegister, IHomePageServiceProvider
    {
    }

    public interface IHomePageServiceRegister : IServiceRegister<HomePageItem>
    {

    }

    public interface IHomePageServiceProvider : IServiceProvider<HomePageItem>
    {

    }


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
