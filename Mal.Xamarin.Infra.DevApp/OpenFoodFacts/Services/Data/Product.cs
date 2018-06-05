using System.Collections.Generic;

namespace Mal.Xamarin.Infra.DevApp.OpenFoodFacts.Services.Data
{
    public class Product
    {
        public Product(string code, string name, string brand, string nutriScore, string pictureUrl, IReadOnlyCollection<Additive> additives)
        {
            this.Code = code;
            this.Name = name;
            this.Brand = brand;
            this.NutriScore = nutriScore;
            this.PictureUrl = pictureUrl;
            this.Additives = additives;
        }

        public string Code { get; }
        public string Name { get; }
        public string Brand { get; }
        public string NutriScore { get; }
        public string PictureUrl { get; }
        public IReadOnlyCollection<Additive> Additives { get; }
    }
}
