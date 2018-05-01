using CommonServiceLocator;

namespace Mal.Xamarin.Infra.Containers
{
    public static class ServiceLocatorExtensions
    {
        public static bool TryGetInstance<TService>(this IServiceLocator serviceLocator, ref TService service)
        {
            try
            {
                service = serviceLocator.GetInstance<TService>();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool TryGetInstance<TService>(this IServiceLocator serviceLocator, ref TService service, string key)
        {
            try
            {
                service = serviceLocator.GetInstance<TService>(key);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }

}
