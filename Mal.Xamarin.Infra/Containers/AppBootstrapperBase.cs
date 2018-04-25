using GalaSoft.MvvmLight.Views;

namespace Mal.Xamarin.Infra.Containers
{
    public abstract class AppBootstrapperBase
    {
        public void Run(IBootstrapStrategy bootstrapStrategy)
        {
            var container = this.BuildContainer();

            container.ServiceLocator = new ServiceLocator(container);

            var navigationService = new NavigationService();
            container.RegisterInstance(navigationService);
            container.RegisterInstance<INavigationService>(navigationService);

            ServiceLocator.Current = container.ServiceLocator;
            bootstrapStrategy.RegisterTypes(container);
        }

        protected abstract IContainer BuildContainer();
    }
}
