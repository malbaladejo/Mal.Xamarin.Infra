using GalaSoft.MvvmLight;

namespace Mal.Xamarin.Infra.DevApp.ViewModels.LazyList
{
    public class LazyListItemViewModel : ViewModelBase
    {
        private string title;
        private bool isSelected;

        public int Index { get; }

        public LazyListItemViewModel(int index)
        {
            this.Index = index;
            this.Title = $"Item {this.Index}";
        }

        public string Title
        {
            get { return this.title; }
            set { this.Set(ref this.title, value); }
        }

        public bool IsSelected
        {
            get { return this.isSelected; }
            set { this.Set(ref this.isSelected, value); }
        }
    }
}