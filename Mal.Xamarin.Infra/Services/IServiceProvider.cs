using System.Collections.Generic;

namespace Mal.Xamarin.Infra.Services
{
    public interface IServiceProvider<T>
    {
        IReadOnlyCollection<T> Items { get; }
    }
}
