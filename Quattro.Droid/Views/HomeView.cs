using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Views;
using Android.Widget;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using Quattro.Core.ViewModels;

namespace Quattro.Droid.Views {

    [MvxActivityPresentation]
    [Activity(Label = "Quattro")]
    public class HomeView : MvxAppCompatActivity<HomeViewModel> {

        // DRAWER
        public DrawerLayout DrawerLayout { get; set; }


        // ON CREATE
        protected override void OnCreate(Bundle bundle) {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.HomePage);
            DrawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);

            if (bundle == null) {
                ViewModel.CalendarioCommand.Execute();
                ViewModel.MenuCommand.Execute();
            }
        }


        // ON OPTIONS ITEM SELECTED
        public override bool OnOptionsItemSelected(IMenuItem item) {
            switch (item.ItemId) {
                case Android.Resource.Id.Home:
                    DrawerLayout.OpenDrawer(GravityCompat.Start);
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }


        // ON BACK PRESSED
        public override void OnBackPressed() {
            if (DrawerLayout != null && DrawerLayout.IsDrawerOpen(GravityCompat.Start)) {
                DrawerLayout.CloseDrawers();
            } else {
                base.OnBackPressed();
            }

        }


    }
}