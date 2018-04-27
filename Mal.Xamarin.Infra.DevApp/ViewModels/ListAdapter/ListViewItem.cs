using GalaSoft.MvvmLight;
using System;
using System.Threading.Tasks;

namespace Mal.Xamarin.Infra.DevApp.ViewModels.ListAdapter
{
    public class ListViewItem : ViewModelBase
    {
        private string title;

        public int Index { get; }

        public ListViewItem(int index)
        {
            Index = index;
            this.StartTimer();
        }

        private async void StartTimer()
        {
            while (true)
            {
                await Task.Delay(1000);
                this.Title = DateTime.Now.ToString("YY/MM/dd HH:mm:ss");
            }
        }

        public string Title
        {
            get { return this.title; }
            set { this.Set(ref this.title, value); }
        }
    }
}