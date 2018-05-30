using Newtonsoft.Json;

namespace Mal.Xamarin.Infra.DevApp.OpenFoodFacts.Services.Impl.Dtos
{
    internal class The100
    {
        [JsonProperty("h")]
        public long H { get; set; }

        [JsonProperty("w")]
        public long W { get; set; }
    }
}