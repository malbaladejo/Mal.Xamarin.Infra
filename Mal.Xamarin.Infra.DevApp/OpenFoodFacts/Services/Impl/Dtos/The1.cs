using Newtonsoft.Json;

namespace Mal.Xamarin.Infra.DevApp.OpenFoodFacts.Services.Impl.Dtos
{
    internal class The1
    {
        [JsonProperty("uploader")]
        public string Uploader { get; set; }

        [JsonProperty("sizes")]
        public Sizes Sizes { get; set; }

        [JsonProperty("uploaded_t")]
        public long UploadedT { get; set; }
    }
}