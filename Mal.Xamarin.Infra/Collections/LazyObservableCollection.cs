using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Mal.XF.Infra.Collections
{
    public sealed class LazyObservableCollection<T> : ObservableCollection<T>, ILazyObservableCollection
    {
        private readonly ILoadItemsStrategy<T> loadItemsStrategy;
        private readonly int pageSize;
        private bool isBusy;

        private int lastIndex = 0;
        private int lastLoadedPage = -1;

        public LazyObservableCollection(ILoadItemsStrategy<T> loadItemsStrategy, int pageSize)
        {
            this.loadItemsStrategy = loadItemsStrategy;
            this.pageSize = pageSize;
            this.CollectionChanged += this.OnCollectionChanged;
        }

        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Remove:
                case NotifyCollectionChangedAction.Reset:
                    this.lastIndex = 0;
                    this.lastLoadedPage = -1;
                    break;
            }
        }

        public async Task LoadItemsAsync(object item = null)
        {
            await Task.Delay(0);
            if (this.IsBusy)
                return;

            await this.LoadItemsByIndexAsync(this.GetIndex((T)item));
        }

        public async Task LoadItemsByIndexAsync(int index)
        {
            if (this.IsBusy)
                return;

            var pageNumber = this.GetPageNumberByIndex(index);

            if (pageNumber < this.lastLoadedPage)
                return;

            this.IsBusy = true;
            try
            {
                this.lastLoadedPage++;
                var newItems = await this.loadItemsStrategy.LoadItemsAsync(this.lastLoadedPage, this.pageSize);
                foreach (var newItem in newItems)
                    this.Add(newItem);
            }
            finally
            {
                this.IsBusy = false;
            }
        }

        private int GetPageNumberByIndex(int index)
        {
            var pageNumber = index / this.pageSize;
            return pageNumber;
        }

        private int GetIndex(T item)
        {
            if (item == null)
                return 0;

            for (int i = lastIndex; i < this.Count; i++)
            {
                if (this[i].Equals(item))
                {
                    this.lastIndex = i;
                    return i;
                }
            }

            return -1;
        }

        public bool IsBusy
        {
            get { return this.isBusy; }
            private set
            {
                this.isBusy = value;
                this.OnPropertyChanged(new PropertyChangedEventArgs(nameof(this.IsBusy)));
            }
        }
    }
}
