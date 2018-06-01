using Mal.Xamarin.Infra.DevApp.OpenFoodFacts.Services.Impl.Dtos;
using Mal.Xamarin.Infra.DevApp.OpenFoodFacts.Services.Impl.Mappers;
using Newtonsoft.Json;
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
            var root = await this.GatDataAsync<RootProduct>(new Uri(GetFormatedUrl(productCode), UriKind.Absolute));
            return this.mapper.MapProduct(root);
        }

        private async Task<T> GatDataAsync<T>(Uri uri) where T : ResponseBase
        {
            using (var webClient = new WebClient())
            {
                var json = await webClient.DownloadStringTaskAsync(uri);
                var response = JsonConvert.DeserializeObject<T>(json, Converter.Settings);

                if (response.Status == 0)
                    throw new WebException(response.StatusVerbose);

                return response;
            }
        }

        private static string GetFormatedUrl(string productCode)
            => string.Format(ServiceUrlFormat, productCode);
    }
}
