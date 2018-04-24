using Mal.Xamarin.Infra.Containers;
using Mal.Xamarin.Infra.DevApp.Services;

namespace Mal.Xamarin.Infra.DevApp
{
    public class AppBootstrapperStrategy : IBootstrapStrategy
    {
        public void RegisterTypes(IContainer container)
        {
            container.RegisterType<IHomePageServiceRegister, HomePageServiceProvider>();
            container.RegisterType<IHomePageServiceProvider, HomePageServiceProvider>();
        }
    }
}
