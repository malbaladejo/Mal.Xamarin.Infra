using Mal.Xamarin.Infra.Containers;

namespace Mal.Xamarin.Infra.Translation
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
            this.container.RegisterSingleton<TranslationManager, TranslationManager>();
            var translationManager = this.container.ServiceLocator.GetInstance<TranslationManager>();
            this.container.RegisterInstance<ITranslationManagerReader>(translationManager);
            this.container.RegisterInstance<ITranslationManager>(translationManager);
            this.container.RegisterType<TranslationService>();
            var multiProviderTransSvc = this.RegisterMultiProviderTranslationService();
            this.RegisterMultiKeysTranslationProvider(multiProviderTransSvc);
        }

        private void RegisterMultiKeysTranslationProvider(TranslationService translationProviderSource)
        {
            var multiTransKeyTranslationProvider = new MultiTranslationKeysTranslationService(translationProviderSource);
            this.container.RegisterInstance<ITranslationService>(multiTransKeyTranslationProvider);
        }

        private TranslationService RegisterMultiProviderTranslationService()
            => this.container.ServiceLocator.GetInstance<TranslationService>();
    }
}
