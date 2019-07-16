using System;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.View;
using Android.Support.V7.Widget;
using Android.Views;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using Quattro.Core.Interfaces;
using Quattro.Core.ViewModels;
using Quattro.Droid.Interfaces;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace Quattro.Droid.Views {

    [MvxFragmentPresentation(typeof(HomeViewModel), Resource.Id.contenido)]
    [Register("quattro.droid.views.CalendarioView")]
    public class CalendarioView : MvxAppCompatDialogFragment<CalendarioViewModel>, IBaseFragment {

        private Toolbar toolbar;
        private MvxActionBarDrawerToggle drawerToggle;
        private GestureDetector gestureDetector;

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
                toolbar.NavigationClick += Toolbar_NavigationClick; ;

                //this.CreateBindingSet<CalendarioView, CalendarioViewModel>().Bind(toolbar).For(c =>c.Title).To(c => c.Titulo).Apply();
            }

            // Ponemos la lista de días en el día actual.
            MvxRecyclerView lista = view.FindViewById<MvxRecyclerView>(Resource.Id.lista_calendario);
            if (ViewModel.Fecha.Year == DateTime.Now.Year && ViewModel.Fecha.Month == DateTime.Now.Month) {
                lista.ScrollToPosition(DateTime.Now.Day - 1);
            }

            // Añadimos los comandos Anterior y Siguiente a los gestos Swipe
            gestureDetector = new GestureDetector(ParentActivity, new GestureListener(SwipeLeft, SwipeRight, null, null));
            CardView navegador = view.FindViewById<CardView>(Resource.Id.navegador);
            navegador.Touch += Navegador_Touch;


            // Registramos el listener de la propiedad IsInSelectionMode.
            ViewModel.PropertyChanged += ViewModel_PropertyChanged;

            return view;
        }

        private void Navegador_Touch(object sender, View.TouchEventArgs e) {
            gestureDetector.OnTouchEvent(e.Event);
        }



        private void Toolbar_NavigationClick(object sender, Toolbar.NavigationClickEventArgs e) {
            if (ViewModel.IsInSelectMode) {
                ViewModel.DesseleccionarTodoCommand.Execute(null);
                return;
            }
            ((HomeView)ParentActivity).Drawer.OpenDrawer(GravityCompat.Start);
        }

        private void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e) {
            if (e.PropertyName == "IsInSelectMode") {
                if (ViewModel.IsInSelectMode) {
                    ParentActivity.SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.ic_ok);
                } else {
                    ParentActivity.SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.ic_menu);
                }
            }
        }

        // GESTOS SWIPE
        private void SwipeLeft() {
            ViewModel.SiguientePulsadoAsyncCommand.Execute(null);
        }

        private void SwipeRight() {
            ViewModel.AnteriorPulsadoAsyncCommand.Execute(null);
        }


        // PARTE DE LA INTERFAZ BASE FRAGMENT
        public bool OnBackPressed() {
            if (ViewModel.IsInSelectMode) {
                ViewModel.DesseleccionarTodoCommand.Execute(null);
                return true;
            }
            return false;
        }

        // AÑADIR ESTO A TODAS LAS VIEWS (ACTIVITIES)
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults) {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

    }
}