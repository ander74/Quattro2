using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using Quattro.Core.ViewModels;


namespace Quattro.Droid.Views {

    [MvxFragmentPresentation(typeof(HomeViewModel), Resource.Id.contenido)]
    [Register("quattro.droid.views.CalendarioView")]
    public class CalendarioView : MvxAppCompatDialogFragment<CalendarioViewModel> {

        private Toolbar toolbar;
        private MvxActionBarDrawerToggle drawerToggle;
        public MvxAppCompatActivity ParentActivity {
            get => (MvxAppCompatActivity)Activity;
        }


        public override void OnCreate(Bundle bundle) {
            base.OnCreate(bundle);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
            var ignore = base.OnCreateView(inflater, container, savedInstanceState);
            var view = this.BindingInflate(Resource.Layout.CalendarioPage, null);


            // Inicializamos la toolbar. DEBE APARECER EN TODOS LOS FRAGMENTS
            toolbar = view.FindViewById<Toolbar>(Resource.Id.toolbar);
            if (toolbar != null) {
                ParentActivity.SetSupportActionBar(toolbar);
                ParentActivity.SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.ic_menu);
                ParentActivity.SupportActionBar.SetDisplayHomeAsUpEnabled(true);

                drawerToggle = new MvxActionBarDrawerToggle(
                    Activity,
                    ((HomeView)ParentActivity).Drawer,
                    toolbar,
                    Resource.String.OpenDrawerString,
                    Resource.String.CloseDrawerString
                );
                drawerToggle.DrawerOpened += (object sender, ActionBarDrawerEventArgs e) => ((HomeView)Activity)?.HideSoftKeyboard();
                ((HomeView)ParentActivity).Drawer.AddDrawerListener(drawerToggle);

                //this.CreateBindingSet<CalendarioView, CalendarioViewModel>().Bind(toolbar).For(c =>c.Title).To(c => c.Titulo).Apply();
            }
            return view;
        }




        // AÑADIR ESTO A TODAS LAS VIEWS (ACTIVITIES)
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults) {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

    }
}