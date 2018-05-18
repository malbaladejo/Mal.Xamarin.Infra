using Mal.Xamarin.Infra.Containers;
using Mal.Xamarin.Infra.DevApp.Services;
using Mal.Xamarin.Infra.DevApp.Translation;
using Mal.Xamarin.Infra.DevApp.ViewModels.BurgerMenu;
using Mal.Xamarin.Infra.DevApp.ViewModels.LazyList;
using Mal.Xamarin.Infra.DevApp.ViewModels.Main;

namespace Mal.Xamarin.Infra.DevApp
{
    public class AppBootstrapperStrategy : IBootstrapStrategy
    {
        public virtual void RegisterTypes(IContainer container)
        {
            container.RegisterType<IHomePageServiceRegister, HomePageServiceProvider>();
            container.RegisterType<IHomePageServiceProvider, HomePageServiceProvider>();

            container.RegisterType<MainViewModel>();
            container.RegisterType<LazyListViewModel>();
            container.RegisterType<ItemDetailViewModel>();
            container.RegisterType<BurgerMenuViewModel>();
            container.RegisterType<TranslationBootstrapper>();
            container.ServiceLocator.GetInstance<TranslationBootstrapper>().Run();
        }
    }
}
