using Android.App;
using Android.OS;
using MvvmCross.Platforms.Android.Views;
using Quattro.Core.ViewModels;

namespace Quattro.Droid.Views {

    [Activity(Label = "@string/app_name")]
    public class LicenciaView : MvxActivity<LicenciaViewModel> {

        protected override void OnCreate(Bundle bundle) {
            base.OnCreate(bundle);
            this.SetContentView(Resource.Layout.LicenciaPage);
        }

    }
}