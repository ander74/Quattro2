using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using MvvmCross.Droid.Support.V7.AppCompat;
using Quattro.Core.ViewModels;
using Toolbar = Android.Support.V7.Widget.Toolbar;


namespace Quattro.Droid.Views {

    [Activity(Label = "@string/app_name")]
    public class CalendarioView : MvxAppCompatActivity<CalendarioViewModel> {

        protected override void OnCreate(Bundle bundle) {
            base.OnCreate(bundle);
            this.SetContentView(Resource.Layout.CalendarioPage);

            // Definimos la ToolBar.
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            this.SetSupportActionBar(toolbar);
            SupportActionBar?.SetDisplayHomeAsUpEnabled(true);

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