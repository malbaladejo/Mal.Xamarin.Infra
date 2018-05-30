using Newtonsoft.Json;

namespace Mal.Xamarin.Infra.DevApp.OpenFoodFacts.Services.Impl.Dtos
{
    internal class Ingredient
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("percent", NullValueHandling = NullValueHandling.Ignore)]
        public string Percent { get; set; }

        [JsonProperty("rank")]
        public long Rank { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }
}