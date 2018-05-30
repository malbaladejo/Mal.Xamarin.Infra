using System.Collections.Generic;

namespace Mal.Xamarin.Infra.DevApp.OpenFoodFacts.Services.Data
{
    public class Product
    {
        public Product(string code, string nutriScore, string pictureUrl, IReadOnlyCollection<Additive> additives)
        {
            Code = code;
            NutriScore = nutriScore;
            PictureUrl = pictureUrl;
            Additives = additives;
        }

        public string Code { get; }
        public string NutriScore { get; }
        public string PictureUrl { get; }
        public IReadOnlyCollection<Additive> Additives { get; }
    }
}
