namespace Mal.Xamarin.Infra.Containers
{
    public interface IBootstrapStrategy
    {
        void RegisterTypes(IContainer container);
    }
}
