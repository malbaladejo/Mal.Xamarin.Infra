using Newtonsoft.Json;

namespace Mal.Xamarin.Infra.DevApp.OpenFoodFacts.Services.Impl.Dtos
{
    internal class SelectedImages
    {
        [JsonProperty("nutrition")]
        public SelectedImagesFront Nutrition { get; set; }

        [JsonProperty("ingredients")]
        public SelectedImagesFront Ingredients { get; set; }

        [JsonProperty("front")]
        public SelectedImagesFront Front { get; set; }
    }
}