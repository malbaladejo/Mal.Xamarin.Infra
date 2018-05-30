using Newtonsoft.Json;

namespace Mal.Xamarin.Infra.DevApp.OpenFoodFacts.Services.Impl.Dtos
{
    internal class Languages
    {
        [JsonProperty("en:french")]
        public long EnFrench { get; set; }
    }
}