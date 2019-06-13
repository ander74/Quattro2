
using Android.App;
using Android.Content.PM;
using MvvmCross.Platforms.Android.Core;
using MvvmCross.Platforms.Android.Views;
using Quattro.Core;

namespace Quattro.Droid.Views {

    [Activity(
        Label = "@string/app_name",
        MainLauncher = true,
        //Icon = "@drawable/icon",
        Theme = "@style/Theme.Splash",
        NoHistory = true,
        ScreenOrientation = ScreenOrientation.Portrait
        )]
    public class SplashView : MvxSplashScreenActivity<MvxAndroidSetup<App>, App> {

        public SplashView() : base(Resource.Layout.SplashPage) {

        }

    }
}