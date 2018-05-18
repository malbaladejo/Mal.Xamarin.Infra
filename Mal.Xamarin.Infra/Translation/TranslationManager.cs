using System.Collections.Generic;
using Mal.Xamarin.Infra.Extensions;

namespace Mal.Xamarin.Infra.Translation
{
    internal class TranslationManager : ITranslationManager, ITranslationManagerReader
    {
        private readonly List<ITranslationProvider> providers;

        public TranslationManager()
        {
            this.providers = new List<ITranslationProvider>();
        }

        public IReadOnlyCollection<ITranslationProvider> GetProviders()
        {
            return this.providers.ToReadOnlyCollection();
        }

        public void Register(ITranslationProvider provider)
        {
            this.providers.Add(provider);
        }
    }
}