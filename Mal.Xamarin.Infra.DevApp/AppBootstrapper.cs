using Mal.Xamarin.Infra.DevApp.Services;

namespace Mal.Xamarin.Infra.DevApp
{
    public class AppBootstrapper
    {
        public void Run()
        {
            IocFactory.Instance.RegisterType<IHomePageServiceRegister, HomePageServiceProvider>();
            IocFactory.Instance.RegisterType<IHomePageServiceProvider, HomePageServiceProvider>();
        }
    }
}
