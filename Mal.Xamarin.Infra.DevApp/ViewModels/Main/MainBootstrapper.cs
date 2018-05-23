using Mal.Xamarin.Infra.Containers;
using Mal.Xamarin.Infra.DevApp.ViewModels.BurgerMenu;
using Mal.Xamarin.Infra.DevApp.ViewModels.LazyList;
using Mal.Xamarin.Infra.Navigation;
using Mal.Xamarin.Infra.Services;

namespace Mal.Xamarin.Infra.DevApp.ViewModels.Main
{
    internal class MainBootstrapper
    {
        private readonly IContainer container;

        public MainBootstrapper(IContainer container)
        {
            this.container = container;
        }

        public void Run()
        {
            var mainItemServiceProvider = new MainItemServiceProvider();
            container.RegisterInstance<IServiceRegister<INavigationToken>>(mainItemServiceProvider);
            container.RegisterInstance<IServiceProvider<INavigationToken>>(mainItemServiceProvider);

            mainItemServiceProvider.Register(new LazyListNavigationToken());
            mainItemServiceProvider.Register(new BurgerMenuNavigationToken());
        }
    }
}