using Mal.Xamarin.Infra.DevApp.OpenFoodFacts.Services.Data;
using Mal.Xamarin.Infra.DevApp.OpenFoodFacts.Services.Impl.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using LocalProduct = Mal.Xamarin.Infra.DevApp.OpenFoodFacts.Services.Data.Product;

namespace Mal.Xamarin.Infra.DevApp.OpenFoodFacts.Services.Impl.Mappers
{
    internal class Mapper
    {
        public LocalProduct MapProduct(RootProduct rootProduct)
        {
            return new LocalProduct(rootProduct.Code,
                                    rootProduct.Product.NutritionGrades,
                                    rootProduct.Product.ImageFrontThumbUrl,
                                    this.Map(rootProduct.Product.AdditivesOriginalTags, this.MapAdditive));
        }

        private IReadOnlyCollection<TTarget> Map<TSource, TTarget>(IReadOnlyCollection<TSource> sources, Func<TSource, TTarget> mapItem)
        {
            return sources.Select(mapItem).ToArray();
        }

        public Additive MapAdditive(string item)
        {
            var additiveCode = item.Replace("en:e", "E");

            if (!Additives.Items.ContainsKey(additiveCode))
                Additives.Items[additiveCode] = new Additive(additiveCode, additiveCode, AdditiveToxicity.Unknown);

            return Additives.Items[additiveCode];
        }
    }
}
