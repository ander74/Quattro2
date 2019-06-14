using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using MvvmCross.Platforms.Android.Views;
using Quattro.Core.ViewModels;

namespace Quattro.Droid.Views {

    [Activity(Label = "@string/app_name")]
    public class LicenciaView : MvxActivity<LicenciaViewModel> {

        protected override void OnCreate(Bundle bundle) {
            base.OnCreate(bundle);
            this.SetContentView(Resource.Layout.LicenciaPage);
        }


        // AÑADIR ESTO A TODAS LAS VIEWS (ACTIVITIES)
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults) {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

    }
}