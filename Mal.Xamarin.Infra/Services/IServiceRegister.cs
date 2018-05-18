namespace Mal.Xamarin.Infra.Services
{
    public interface IServiceRegister<T>
    {
        void Register(T token);
    }
}