using Newtonsoft.Json;

namespace Mal.Xamarin.Infra.DevApp.OpenFoodFacts.Services.Impl.Dtos
{
    internal class SelectedImagesFront
    {
        [JsonProperty("display")]
        public Display Display { get; set; }

        [JsonProperty("small")]
        public Display Small { get; set; }

        [JsonProperty("thumb")]
        public Display Thumb { get; set; }
    }
}