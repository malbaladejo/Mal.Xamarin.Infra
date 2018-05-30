using Newtonsoft.Json;

namespace Mal.Xamarin.Infra.DevApp.OpenFoodFacts.Services.Impl.Dtos
{
    internal class Sizes
    {
        [JsonProperty("100")]
        public The100 The100 { get; set; }

        [JsonProperty("400")]
        public The100 The400 { get; set; }

        [JsonProperty("full")]
        public The100 Full { get; set; }

        [JsonProperty("200", NullValueHandling = NullValueHandling.Ignore)]
        public The100 The200 { get; set; }
    }
}