using System.Collections;
using System.Threading.Tasks;

namespace Mal.XF.Infra.Collections
{
    public interface ILazyObservableCollection : IEnumerable
    {
        Task LoadItemsAsync(object item = null);
		Task LoadItemsByIndexAsync(int itemIndex);
        bool IsBusy { get; }
    }
}
