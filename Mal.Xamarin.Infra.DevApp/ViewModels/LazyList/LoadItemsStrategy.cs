using System.Collections.Generic;
using System.Threading.Tasks;
using Mal.XF.Infra.Collections;

namespace Mal.Xamarin.Infra.DevApp.ViewModels.LazyList
{
    internal class LoadItemsStrategy : ILoadItemsStrategy<LazyListItemViewModel>
    {
        public async Task<IReadOnlyCollection<LazyListItemViewModel>> LoadItemsAsync(int pageNumber, int pageSize)
        {
            await Task.Delay(500);
            var items = new List<LazyListItemViewModel>();

            if (pageNumber >= 5)
                return items;

            for (var i = 0; i < pageSize; i++)
                items.Add(new LazyListItemViewModel((pageSize * pageNumber) + i));

            return items;
        }
    }
}