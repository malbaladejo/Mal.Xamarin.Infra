using Newtonsoft.Json;

namespace Mal.Xamarin.Infra.DevApp.OpenFoodFacts.Services.Impl.Dtos
{
    internal class FrontFrClass
    {
        [JsonProperty("normalize")]
        public string Normalize { get; set; }

        [JsonProperty("white_magic")]
        public string WhiteMagic { get; set; }

        [JsonProperty("geometry")]
        public string Geometry { get; set; }

        [JsonProperty("rev")]
        public string Rev { get; set; }

        [JsonProperty("sizes")]
        public Sizes Sizes { get; set; }

        [JsonProperty("imgid")]
        public string Imgid { get; set; }
    }
}