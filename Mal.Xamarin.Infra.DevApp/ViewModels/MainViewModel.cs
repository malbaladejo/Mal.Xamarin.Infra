using GalaSoft.MvvmLight;
using Mal.Xamarin.Infra.Fonts;

namespace Mal.Xamarin.Infra.DevApp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public string Icon => IconFont.Android;
    }
}
