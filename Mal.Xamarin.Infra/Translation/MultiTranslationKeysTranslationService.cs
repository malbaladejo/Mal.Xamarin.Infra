using System.Linq;
using System.Text.RegularExpressions;

namespace Mal.Xamarin.Infra.Translation
{
    /// <summary>
    /// Facade d'appel encapsulant une instance de <see cref="ITranslationService"/> (fourni dans le ctor) responsable de traduire les clés lors de l'appel à <see cref="ITranslationService.GetTranslatedString"/>.
    /// Cette facade permet l'usage de plusieurs clés à traduire dans la chaine fournie. Le format attendu est le suivant <c>{@key:KeyToTranslate}</c> où KeyToTranslate correspond à la clé de la ressource.
    /// La chaine peut contenir n clés, exemple : "{@key:My.firstkey.to.translate} blablabla {@key:My.secondkey.to.translate} ..."
    /// Dans le cas où le format n'est pas trouvé, il délègue la traduction sans autre intervention.
    /// </summary>
    public class MultiTranslationKeysTranslationService : ITranslationService
    {
        private readonly ITranslationService baseProvider;

        public MultiTranslationKeysTranslationService(ITranslationService realProvider)
        {
            this.baseProvider = realProvider;
        }

        public string GetTranslation(string key)
        {
            var keyMatches = ExtractMultiKeysRegex.Matches(key);
            var multiKeysResult = key;
            var sentinelleHasMultiKeys = false;

            foreach (var keyMatch in keyMatches
                .OfType<Match>()
                .Where(keyMatch => keyMatch.Success))
            {
                sentinelleHasMultiKeys = true;
                var value = this.baseProvider.GetTranslation(keyMatch.Groups[KeyValueRegexGroup].Value) ?? (keyMatch.Groups[KeyNodeRegexGroup].Value);
                multiKeysResult = multiKeysResult.Replace(keyMatch.Groups[KeyNodeRegexGroup].Value, value);
            }

            return sentinelleHasMultiKeys ? multiKeysResult : this.baseProvider.GetTranslation(key);
        }

        private const string KeyNodeRegexGroup = "keyNode"; // non inclu dans la regex => ne pas briser l'assistant regex R#
        private const string KeyValueRegexGroup = "keyValue"; // non inclu dans la regex => ne pas briser l'assistant regex R#
        private static readonly Regex ExtractMultiKeysRegex = new Regex(@"(?<keyNode>{@key:(?<keyValue>[^\s{}\n]+)})",
            RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase);
    }
}