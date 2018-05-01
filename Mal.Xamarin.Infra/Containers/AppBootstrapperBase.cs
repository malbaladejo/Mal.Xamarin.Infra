namespace Mal.Xamarin.Infra.Containers
{
    public abstract class AppBootstrapperBase
    {
        public void Run(IBootstrapStrategy bootstrapStrategy)
        {
            var container = this.BuildContainer();

            container.ServiceLocator = new ServiceLocator(container);

            ServiceLocator.Current = container.ServiceLocator;
            bootstrapStrategy.RegisterTypes(container);
        }

        protected abstract IContainer BuildContainer();
    }
}
