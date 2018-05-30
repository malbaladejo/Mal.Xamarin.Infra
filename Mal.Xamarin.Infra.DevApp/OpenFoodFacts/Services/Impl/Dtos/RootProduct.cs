using Newtonsoft.Json;

namespace Mal.Xamarin.Infra.DevApp.OpenFoodFacts.Services.Impl.Dtos
{
    internal class RootProduct
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("product")]
        public Product Product { get; set; }

        [JsonProperty("status")]
        public long Status { get; set; }

        [JsonProperty("status_verbose")]
        public string StatusVerbose { get; set; }

        public static RootProduct FromJson(string json) => JsonConvert.DeserializeObject<RootProduct>(json, Converter.Settings);
    }
}
