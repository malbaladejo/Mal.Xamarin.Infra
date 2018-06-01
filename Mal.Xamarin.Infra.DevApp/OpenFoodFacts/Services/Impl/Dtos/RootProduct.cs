using Newtonsoft.Json;

namespace Mal.Xamarin.Infra.DevApp.OpenFoodFacts.Services.Impl.Dtos
{
    internal class RootProduct : ResponseBase
    {
        [JsonProperty("product")]
        public Product Product { get; set; }

        public static RootProduct FromJson(string json) => JsonConvert.DeserializeObject<RootProduct>(json, Converter.Settings);
    }
}
