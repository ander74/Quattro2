using System.Threading.Tasks;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Views.InputMethods;
using MvvmCross.Droid.Support.V7.AppCompat;
using Quattro.Core.ViewModels;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace Quattro.Droid.Views {

    [Activity(Label = "Quattro 2")]
    public class HomeView : MvxAppCompatActivity<HomeViewModel> {

        private IMenuItem menuPrevio;
        private NavigationView navigationView;

        public DrawerLayout Drawer { get; set; }

        protected override void OnCreate(Bundle bundle) {
            base.OnCreate(bundle);
            this.SetContentView(Resource.Layout.HomePage);

            // Definimos el Drawer
            Drawer = FindViewById<DrawerLayout>(Resource.Id.drawerlayout);

            // Definimos el menú del Drawer
            navigationView = this.FindViewById<NavigationView>(Resource.Id.navigation_view);
            navigationView.NavigationItemSelected += NavigationView_NavigationItemSelected;

            if (bundle == null) {
                var itemCalendario = navigationView.Menu.FindItem(Resource.Id.nav_calendario);
                itemCalendario.SetChecked(true);
                itemCalendario.SetCheckable(true);
                menuPrevio = itemCalendario;
                ViewModel.GotoCalendarioCommand.Execute(null);
            }

        }

        private void NavigationView_NavigationItemSelected(object sender, NavigationView.NavigationItemSelectedEventArgs e) {
            if (menuPrevio == e.MenuItem) {
                //Drawer.CloseDrawer(navigationView);
                return;
            }
            if (menuPrevio != null) {
                menuPrevio.SetChecked(false);
            }
            e.MenuItem.SetChecked(true);
            e.MenuItem.SetCheckable(true);
            menuPrevio = e.MenuItem;
            switch (e.MenuItem.ItemId) {
                case Resource.Id.nav_calendario:
                    Task.Run(() => ViewModel.GotoCalendarioCommand.Execute(null));
                    Drawer.CloseDrawer(navigationView);
                    break;
            }
        }


        public override bool OnOptionsItemSelected(IMenuItem item) {
            if (item.ItemId == global::Android.Resource.Id.Home) { OnBackPressed(); }
            return base.OnOptionsItemSelected(item);
        }


        public void HideSoftKeyboard() {
            if (CurrentFocus == null) return;
            InputMethodManager inputMethodManager = (InputMethodManager)GetSystemService(InputMethodService);
            inputMethodManager.HideSoftInputFromWindow(CurrentFocus.WindowToken, 0);
            CurrentFocus.ClearFocus();
        }


        // AÑADIR ESTO A TODAS LAS VIEWS (ACTIVITIES)
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults) {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }


    }
}