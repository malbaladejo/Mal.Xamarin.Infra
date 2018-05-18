using Mal.Xamarin.Infra.Containers;
using Mal.Xamarin.Infra.Translation;

namespace Mal.Xamarin.Infra.DevApp.Translation
{
    internal class TranslationBootstrapper
    {
        private readonly IContainer container;

        public TranslationBootstrapper(IContainer container)
        {
            this.container = container;
        }

        public void Run()
        {
            this.container.ServiceLocator.GetInstance<ITranslationManager>().Register(new LocalTranslationProvider());
        }
    }
}
