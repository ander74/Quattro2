using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Widget;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using Quattro.Core.ViewModels;

namespace Quattro.Droid.Views {

    [MvxFragmentPresentation(typeof(HomeViewModel), Resource.Id.navigation_frame)]
    [Register("quattro.droid.views.MenuView")]

    public class MenuView : MvxFragment<MenuViewModel> , NavigationView.IOnNavigationItemSelectedListener {

        private NavigationView navigationView;
        private IMenuItem previousMenuItem;


        // ON CREATE VIEW
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
            var ignore = base.OnCreateView(inflater, container, savedInstanceState);

            var view = this.LayoutInflater.Inflate(Resource.Layout.MenuPage, null);
            navigationView = view.FindViewById<NavigationView>(Resource.Id.navigation_view);
            navigationView.SetNavigationItemSelectedListener(this);
            navigationView.Menu.FindItem(Resource.Id.nav_calendario).SetChecked(true);

            var botonLicencia = navigationView.Menu.FindItem(Resource.Id.nav_licencia);
            botonLicencia.SetCheckable(false);
            botonLicencia.SetChecked(true);

            previousMenuItem = botonLicencia;

            return view;
        }


        // ON NAVIGATION ITEM SELECTED
        public bool OnNavigationItemSelected(IMenuItem item) {
            if (previousMenuItem != null) previousMenuItem.SetChecked(false);

            item.SetCheckable(true);
            item.SetChecked(true);

            previousMenuItem = item;

            ((HomeView)Activity).DrawerLayout.CloseDrawers();

            Task.Delay(TimeSpan.FromMilliseconds(250));

            switch (item.ItemId) {
                case Resource.Id.nav_calendario:
                    ViewModel.CalendarioCommand.Execute(null);
                    break;
                case Resource.Id.nav_licencia:
                    ViewModel.LicenciaCommand.Execute(null);
                    break;

            }

            return true;
        }

    }
}