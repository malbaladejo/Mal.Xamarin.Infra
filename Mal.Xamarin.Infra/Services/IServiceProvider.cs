using System.Collections.Generic;

namespace Mal.XF.Infra.Services
{
    public interface IServiceRegister<T>
    {
        void Register(T token);
    }

    public interface IServiceProvider<T>
    {
        IReadOnlyCollection<T> Items { get; }
    }
}
