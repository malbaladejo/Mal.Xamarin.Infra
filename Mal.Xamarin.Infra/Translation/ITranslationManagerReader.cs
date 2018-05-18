using System.Collections.Generic;

namespace Mal.Xamarin.Infra.Translation
{
    internal interface ITranslationManagerReader
    {
        IReadOnlyCollection<ITranslationProvider> GetProviders();
    }
}