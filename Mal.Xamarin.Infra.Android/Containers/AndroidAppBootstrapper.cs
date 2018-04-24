using Mal.Xamarin.Infra.Containers;

namespace Mal.Xamarin.Infra.Android.Containers
{
    public class AndroidAppBootstrapper : AppBootstrapperBase
    {
        private readonly IContainer container;

        public AndroidAppBootstrapper()
        {
            this.container = new LightInjectContainer();
        }

        protected override IContainer BuildContainer() => this.container;
    }
}