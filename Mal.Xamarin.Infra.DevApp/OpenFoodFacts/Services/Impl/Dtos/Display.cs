using Newtonsoft.Json;

namespace Mal.Xamarin.Infra.DevApp.OpenFoodFacts.Services.Impl.Dtos
{
    internal class Display
    {
        [JsonProperty("fr")]
        public string Fr { get; set; }
    }
}