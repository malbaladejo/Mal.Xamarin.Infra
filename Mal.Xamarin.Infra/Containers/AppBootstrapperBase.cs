namespace Mal.Xamarin.Infra.Containers
{
    public abstract class AppBootstrapperBase
    {
        public IContainer Run(IBootstrapStrategy bootstrapStrategy)
        {
            var container = this.BuildContainer();

            container.ServiceLocator = new ServiceLocator(container);
            bootstrapStrategy.RegisterTypes(container);
            return container;
        }

        protected abstract IContainer BuildContainer();
    }
}
