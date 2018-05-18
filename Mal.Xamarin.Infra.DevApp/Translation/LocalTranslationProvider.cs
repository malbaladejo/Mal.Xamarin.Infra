using System.Reflection;
using Mal.Xamarin.Infra.Translation;

namespace Mal.Xamarin.Infra.DevApp.Translation
{
    internal class LocalTranslationProvider : ITranslationProvider
    {
        public static readonly string Prefix = Assembly.GetExecutingAssembly().GetName().Name.Replace('.', '_') + "_";

        public bool CanTranslate(string key)
            => key.StartsWith(Prefix);

        public string GetTranslation(string key)
            => Resource.ResourceManager.GetString(key.Substring(Prefix.Length));
    }
}