using Newtonsoft.Json;

namespace Mal.Xamarin.Infra.DevApp.OpenFoodFacts.Services.Impl.Dtos
{
    internal class The5
    {
        [JsonProperty("uploader")]
        public string Uploader { get; set; }

        [JsonProperty("sizes")]
        public Sizes Sizes { get; set; }

        [JsonProperty("uploaded_t")]
        public string UploadedT { get; set; }
    }
}