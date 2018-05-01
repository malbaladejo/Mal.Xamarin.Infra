
using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Mal.Xamarin.Infra.Android.Fonts;
using Mal.Xamarin.Infra.DevApp.ViewModels.BurgerMenu;
using Mal.Xamarin.Infra.Fonts;

namespace Mal.Xamarin.Infra.Android.DevApp.BrugerMenu
{
    // https://www.c-sharpcorner.com/article/xamarin-android-create-left-drawer-layout/
    // https://developer.xamarin.com/samples/monodroid/android5.0/NavigationDrawer/

    [Activity(Label = "BurgerMenuActivity")]
    public class BurgerMenuActivity : AppCompatActivity
    {
        private AppCompatActivityBootstrapper bootstrapper;
        private IMenuItem currentMenuItem;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            this.bootstrapper = new AppCompatActivityBootstrapper(this);
            this.bootstrapper.SetContentView(Resource.Layout.BurgerMenu);
            this.DataContext = this.bootstrapper.BuildDataContext<BurgerMenuViewModel>();
            this.bootstrapper.BuildToolbar(Resource.Id.burgermenu_toolbar);

            //this.bootstrapper.GetView<NavigationView>(Resource.Id.burgermenu_nav_view).men

            //this.SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.abc_ic_menu_copy_mtrl_am_alpha);
            //drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            // navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);

            //this.NavigationView.NavigationItemSelected += NavigationView_NavigationItemSelected;

            this.BuildMenu();
        }

        private void BuildMenu()
        {
            var icons = new[] { IconFont.Apple, IconFont.MinusCircle,  IconFont.Facebook };

            for (var groupId = 0; groupId < 3; groupId++)
            {
                for (var i = 0; i < 3; i++)
                {
                    this.NavigationView.Menu.Add(groupId, groupId * 10 + i, groupId * 10 + i, $"{icons[i]} Item{groupId}-{i}");
                }
            }

            for (var i = 0; i < this.NavigationView.Menu.Size(); i++)
            {
                var mi = this.NavigationView.Menu.GetItem(i);

                //for aapplying a font to subMenu ...
                var subMenu = mi.SubMenu;
                if (subMenu != null && subMenu.Size() > 0)
                {
                    for (int j = 0; j < subMenu.Size(); j++)
                    {
                        var subMenuItem = subMenu.GetItem(j);
                        subMenuItem.SetIconTypeface(this.Assets);
                    }
                }

                //the method we have create in activity
                mi.SetIconTypeface(this.Assets);
            }
        }

        private void NavigationView_NavigationItemSelected(object sender, NavigationView.NavigationItemSelectedEventArgs e)
        {
            this.currentMenuItem?.SetChecked(false);
            this.currentMenuItem = e.MenuItem;
            this.currentMenuItem.SetChecked(true);

            this.DrawerLayout.CloseDrawers();

            var view = this.LayoutInflater.Inflate(Resource.Layout.LazyListItemTemplate, null);

            view.FindViewById<TextView>(Resource.Id.listviewtemplate_title).Text = "test";

            this.FrameLayout.AddView(view);
        }

        private DrawerLayout DrawerLayout => this.bootstrapper.GetView<DrawerLayout>(Resource.Id.burgermenu_drawer_layout);
        private NavigationView NavigationView => this.bootstrapper.GetView<NavigationView>(Resource.Id.burgermenu_nav_view);
        private FrameLayout FrameLayout => this.bootstrapper.GetView<FrameLayout>(Resource.Id.burgermenu_content_frame);


        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            this.DrawerLayout.OpenDrawer(GravityCompat.Start);
            return true;
        }

        private BurgerMenuViewModel DataContext { get; set; }
    }
}