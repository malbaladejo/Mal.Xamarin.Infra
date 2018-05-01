using Android.Views;
using Android.Widget;
using GalaSoft.MvvmLight.Helpers;
using Mal.XF.Infra.Collections;
using System;
using System.ComponentModel;

namespace Mal.Xamarin.Infra.Android
{
    public class ListViewAdapter<T>
    {
        private readonly ListView list;
        private readonly LazyObservableCollection<T> lazyObservableCollection;
        private readonly Func<T, View> getView;

        private readonly View footerView;

        private ListViewAdapter(ListView list, LazyObservableCollection<T> lazyObservableCollection, Func<T, View> getView, LayoutInflater layoutInflater)
        {
            try
            {
                this.list = list;
                this.lazyObservableCollection = lazyObservableCollection;
                this.getView = getView;
                this.footerView = layoutInflater.Inflate(Resource.Layout.ListViewBusyIndicatorFooter, null);
                list.Adapter = this.lazyObservableCollection.GetAdapter(this.GetAdapter);

                this.InitializeCollection(this.lazyObservableCollection);
            }
            catch (Exception e)
            {
                
            }
        }

        public static ListViewAdapter<T> Build(ListView list, LazyObservableCollection<T> lazyObservableCollection, Func<T, View> getView, LayoutInflater layoutInflater)
        {
            var adapter = new ListViewAdapter<T>(list, lazyObservableCollection, getView, layoutInflater);

#pragma warning disable 4014
            lazyObservableCollection.LoadItemsAsync();
#pragma warning restore 4014

            return adapter;
        }

        private void InitializeCollection(INotifyPropertyChanged collection)
        {
            collection.PropertyChanged += OnCollectionPropertyChanged;
        }

        private void OnCollectionPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != nameof(this.lazyObservableCollection.IsBusy))
                return;

            if (this.lazyObservableCollection.IsBusy)
                this.list.AddFooterView(this.footerView);
            else
                this.list.RemoveFooterView(this.footerView);
        }

        private View GetAdapter(int position, T item, View convertView)
        {
#pragma warning disable 4014
            this.lazyObservableCollection.LoadItemsByIndexAsync(position);
#pragma warning restore 4014
            return this.getView(item);
        }
    }
}