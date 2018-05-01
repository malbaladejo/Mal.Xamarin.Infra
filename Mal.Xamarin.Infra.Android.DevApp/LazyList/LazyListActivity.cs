using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Widget;
using GalaSoft.MvvmLight.Helpers;
using Mal.Xamarin.Infra.Android.Converters;
using Mal.Xamarin.Infra.DevApp.ViewModels.LazyList;

namespace Mal.Xamarin.Infra.Android.DevApp.LazyList
{
    [Activity(Label = "List")]
    public class LazyListActivity : ActivityBase<LazyListViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            ListViewAdapter<LazyListItemViewModel>.Build(this.Items, this.DataContext.Items, this.GetAdapter, this.LayoutInflater);

            this.Items.ChoiceMode = ChoiceMode.Single;
            this.Items.ItemClick += Items_ItemClick;
            this.Items.ItemLongClick += Items_ItemLongClick;
        }

        public override void OnBackPressed()
        {
            if (!this.DataContext.MultiSelectionEnabled)
            {
                base.OnBackPressed();
                return;
            }

            this.DataContext.MultiSelectionEnabled = false;
        }

        private void Items_ItemLongClick(object sender, AdapterView.ItemLongClickEventArgs e)
        {
            if (this.DataContext.EnableMultiSelectCommand.CanExecute(this.DataContext.Items[e.Position]))
                this.DataContext.EnableMultiSelectCommand.Execute(this.DataContext.Items[e.Position]);
        }

        private void Items_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            if (this.DataContext.SelectItemCommand.CanExecute(this.DataContext.Items[e.Position]))
                this.DataContext.SelectItemCommand.Execute(this.DataContext.Items[e.Position]);
        }

        public ListView Items => this.GetView<ListView>(Resource.Id.list_items);

        private View GetAdapter(LazyListItemViewModel item)
        {
            var view = this.LayoutInflater.Inflate(Resource.Layout.LazyListItemTemplate, null);

            var checkbox = view.FindViewById<CheckBox>(Resource.Id.listviewtemplate_check);

            checkbox.Focusable = false;
            checkbox.FocusableInTouchMode = false;

            this.DataContext.SetBinding<bool, ViewStates>(nameof(this.DataContext.MultiSelectionEnabled),
                                    checkbox, nameof(CheckBox.Visibility), BindingMode.OneWay)
                            .ConvertSourceToTarget(BoolToViewStatesConverter.TrueToVisibleInstance.Convert);

            item.SetBinding<bool, bool>(nameof(item.IsSelected),
                checkbox, nameof(CheckBox.Checked), BindingMode.TwoWay)
                .WhenSourceChanges(() => this.SetItemBackground(view, item));

            item.SetBinding<string, string>(nameof(item.Title), view.FindViewById<TextView>(Resource.Id.listviewtemplate_title),
                                         nameof(TextView.Text), BindingMode.OneWay);

            return view;
        }

        private void SetItemBackground(View view, LazyListItemViewModel item)
        {
            if (item.IsSelected && this.DataContext.MultiSelectionEnabled)
                view.SetBackgroundResource(Resource.Color.blue_200);
            else
                view.SetBackgroundColor(Color.Transparent);
        }
    }
}