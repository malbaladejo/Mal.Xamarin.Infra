namespace Mal.Xamarin.Infra.Translation
{
    public interface ITranslationProvider
    {
        bool CanTranslate(string key);

        string GetTranslation(string key);
    }
}