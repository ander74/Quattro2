using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Support.V7.AppCompat;
using Quattro.Core.ViewModels;

namespace Quattro.Droid.Views {

    [Activity(Label = "@string/app_name")]
    public class CalendarioView : MvxAppCompatActivity<CalendarioViewModel> {

        protected override void OnCreate(Bundle bundle) {
            base.OnCreate(bundle);
            this.SetContentView(Resource.Layout.CalendarioPage);

            //ENLACE AL TITULO DE LA ACTIVITY
            this.CreateBinding().For("Title").To<CalendarioViewModel>(vm => vm.Titulo).Apply();
        }


        // AÑADIR ESTO A TODAS LAS VIEWS (ACTIVITIES)
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults) {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

    }
}