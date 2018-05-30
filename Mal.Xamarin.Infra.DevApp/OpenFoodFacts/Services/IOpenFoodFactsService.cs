using Mal.Xamarin.Infra.DevApp.OpenFoodFacts.Services.Data;
using System.Threading.Tasks;

namespace Mal.Xamarin.Infra.DevApp.OpenFoodFacts.Services
{
    public interface IOpenFoodFactsService
    {
        Task<Product> GetProductAsync(string productCode);
    }
}
