using Newtonsoft.Json;

namespace Mal.Xamarin.Infra.DevApp.OpenFoodFacts.Services.Impl.Dtos
{
    internal class NutrientLevels
    {
        [JsonProperty("sugars")]
        public string Sugars { get; set; }

        [JsonProperty("saturated-fat")]
        public string SaturatedFat { get; set; }

        [JsonProperty("salt")]
        public string Salt { get; set; }

        [JsonProperty("fat")]
        public string Fat { get; set; }
    }
}