using System.Threading.Tasks;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;
using MvvmCross.Droid.Support.V7.AppCompat;
using Quattro.Core.ViewModels;
using Toolbar = Android.Support.V7.Widget.Toolbar;


namespace Quattro.Droid.Views {

    [Activity(Label = "@string/app_name")]
    public class CalendarioView : MvxAppCompatActivity<CalendarioViewModel> {

        private IMenuItem menuPrevio;
        private DrawerLayout drawer;
        private NavigationView navigationView;

        protected override void OnCreate(Bundle bundle) {
            base.OnCreate(bundle);
            this.SetContentView(Resource.Layout.CalendarioPage);

            // Definimos la ToolBar.
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            this.SetSupportActionBar(toolbar);
            SupportActionBar?.SetHomeAsUpIndicator(Resource.Drawable.ic_menu);
            SupportActionBar?.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar?.SetDisplayShowHomeEnabled(true);

            // Definimos el Drawer
            drawer = FindViewById<DrawerLayout>(Resource.Id.drawerlayout);
            var toggle = new ActionBarDrawerToggle(
                this,
                drawer,
                toolbar,
                Resource.String.OpenDrawerString,
                Resource.String.CloseDrawerString);
            drawer.AddDrawerListener(toggle);
            toggle.SyncState();

            // Definimos el menú del Drawer
            navigationView = this.FindViewById<NavigationView>(Resource.Id.navigation_view);
            navigationView.NavigationItemSelected += NavigationView_NavigationItemSelected;

        }

        private void NavigationView_NavigationItemSelected(object sender, NavigationView.NavigationItemSelectedEventArgs e) {
            if (menuPrevio != null) menuPrevio.SetChecked(false);
            e.MenuItem.SetChecked(true);
            e.MenuItem.SetCheckable(true);
            menuPrevio = e.MenuItem;
            switch (e.MenuItem.ItemId) {
                case Resource.Id.nav_calendario:
                    //NO Hacer nada, ya que estamos
                    break;
                case Resource.Id.nav_licencia:
                    Task.Run(() => ViewModel.GotoLicenciaCommand.Execute(null));
                    drawer.CloseDrawer(navigationView);
                    break;
            }
        }

        public override bool OnOptionsItemSelected(IMenuItem item) {
            if (item.ItemId == global::Android.Resource.Id.Home) { OnBackPressed(); }
            return base.OnOptionsItemSelected(item);
        }



        // AÑADIR ESTO A TODAS LAS VIEWS (ACTIVITIES)
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults) {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

    }
}