using Mal.Xamarin.Infra.DevApp.OpenFoodFacts.Services.Impl.Dtos;
using Mal.Xamarin.Infra.DevApp.OpenFoodFacts.Services.Impl.Mappers;
using System;
using System.Net;
using System.Threading.Tasks;
using Product = Mal.Xamarin.Infra.DevApp.OpenFoodFacts.Services.Data.Product;

namespace Mal.Xamarin.Infra.DevApp.OpenFoodFacts.Services.Impl
{
    internal class OpenFoodFactsService : IOpenFoodFactsService
    {
        private readonly Mapper mapper;
        private const string ServiceUrlFormat = "https://fr.openfoodfacts.org/api/v0/produit/{0}.json";

        public OpenFoodFactsService()
        {
            this.mapper = new Mapper();
        }

        public async Task<Product> GetProductAsync(string productCode)
        {
            using (var webClient = new WebClient())
            {
                var json = await webClient.DownloadStringTaskAsync(new Uri(GetFormatedUrl(productCode), UriKind.Absolute));
                var root = RootProduct.FromJson(json);

                return this.mapper.MapProduct(root);
            }
        }

        private static string GetFormatedUrl(string productCode)
            => string.Format(ServiceUrlFormat, productCode);
    }
}
