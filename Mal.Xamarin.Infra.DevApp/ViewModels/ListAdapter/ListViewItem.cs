using GalaSoft.MvvmLight;

namespace Mal.Xamarin.Infra.DevApp.ViewModels.ListAdapter
{
    public class ListViewItem : ViewModelBase
    {
        private string title;
        private bool isSelected;

        public int Index { get; }

        public ListViewItem(int index)
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