using Newtonsoft.Json;

namespace Mal.Xamarin.Infra.DevApp.OpenFoodFacts.Services.Impl.Dtos
{
    internal class Images
    {
        [JsonProperty("1")]
        public The1 The1 { get; set; }

        [JsonProperty("2")]
        public The1 The2 { get; set; }

        [JsonProperty("3")]
        public The1 The3 { get; set; }

        [JsonProperty("4")]
        public The1 The4 { get; set; }

        [JsonProperty("5")]
        public The5 The5 { get; set; }

        [JsonProperty("6")]
        public The5 The6 { get; set; }

        [JsonProperty("7")]
        public The5 The7 { get; set; }

        [JsonProperty("front")]
        public FrontFrClass Front { get; set; }

        [JsonProperty("ingredients_fr")]
        public FrontFrClass IngredientsFr { get; set; }

        [JsonProperty("front_fr")]
        public FrontFrClass FrontFr { get; set; }

        [JsonProperty("nutrition_fr")]
        public FrontFrClass NutritionFr { get; set; }

        [JsonProperty("nutrition")]
        public FrontFrClass Nutrition { get; set; }

        [JsonProperty("ingredients")]
        public FrontFrClass Ingredients { get; set; }
    }
}