using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using MvvmCross.Platforms.Android.Views;

namespace Quattro.Droid.Views {

    [Activity(
        Label = "@string/app_name",
        MainLauncher = true,
        //Icon = "@drawable/icon",
        Theme = "@style/Theme.Splash",
        NoHistory = true,
        ScreenOrientation = ScreenOrientation.Portrait
        )]
    public class SplashView : MvxSplashScreenActivity {

        public SplashView() : base(Resource.Layout.SplashPage) {

        }

        protected override void OnCreate(Bundle bundle) {
            base.OnCreate(bundle);
            Xamarin.Essentials.Platform.Init(this, bundle);
        }

        // AÑADIR ESTO A TODAS LAS VIEWS (ACTIVITIES)
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults) {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}