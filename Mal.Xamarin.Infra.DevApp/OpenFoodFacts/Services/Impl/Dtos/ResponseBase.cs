using Newtonsoft.Json;

namespace Mal.Xamarin.Infra.DevApp.OpenFoodFacts.Services.Impl.Dtos
{
    internal abstract class ResponseBase
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("status")]
        public long Status { get; set; }

        [JsonProperty("status_verbose")]
        public string StatusVerbose { get; set; }
    }
}