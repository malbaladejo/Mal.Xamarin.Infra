using Mal.XF.Infra.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mal.Xamarin.Infra.DevApp.ViewModels.ListAdapter
{
    internal class LoadItemsStrategy : ILoadItemsStrategy<ListViewItem>
    {
        public async Task<IReadOnlyCollection<ListViewItem>> LoadItemsAsync(int pageNumber, int pageSize)
        {
            await Task.Delay(2000);
            var items = new List<ListViewItem>();

            if (pageNumber >= 5)
                return items;

            for (var i = 0; i < pageSize; i++)
                items.Add(new ListViewItem((pageSize * pageNumber) + i));

            return items;
        }
    }
}