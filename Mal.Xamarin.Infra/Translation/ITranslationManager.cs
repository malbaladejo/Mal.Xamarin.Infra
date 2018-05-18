namespace Mal.Xamarin.Infra.Translation
{
    public interface ITranslationManager
    {
        void Register(ITranslationProvider provider);
    }
}