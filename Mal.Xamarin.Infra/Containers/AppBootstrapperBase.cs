using Mal.Xamarin.Infra.Translation;

namespace Mal.Xamarin.Infra.Containers
{
    public abstract class AppBootstrapperBase
    {
        public void Run(IBootstrapStrategy bootstrapStrategy)
        {
            var container = this.BuildContainer();

            container.ServiceLocator = new ServiceLocator(container);
            container.RegisterInstance(container);
            container.RegisterType<TranslationBootstrapper>();
            ServiceLocator.Current = container.ServiceLocator;
            container.ServiceLocator.GetInstance<TranslationBootstrapper>().Run();
            bootstrapStrategy.RegisterTypes(container);
        }

        protected abstract IContainer BuildContainer();
    }
}
