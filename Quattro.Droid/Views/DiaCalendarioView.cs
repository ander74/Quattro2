using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Droid.Support.V7.AppCompat;
using Quattro.Core.Common;
using Quattro.Core.ViewModels;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace Quattro.Droid.Views {

    [Activity(Label = "DiaCalendario")]
    public class DiaCalendarioView : MvxAppCompatActivity<DiaCalendarioViewModel> {

        protected override void OnCreate(Bundle bundle) {
            base.OnCreate(bundle);
            this.SetContentView(Resource.Layout.DiaCalendarioPage);

            var toolbar = this.FindViewById<Toolbar>(Resource.Id.toolbar);
            if (toolbar != null) {
                this.SetSupportActionBar(toolbar);
                this.SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            }
            var editInicio = this.FindViewById<EditText>(Resource.Id.editInicio);
            editInicio.Touch += EditInicio_Touch;
            var editFinal = this.FindViewById<EditText>(Resource.Id.editFinal);
            editFinal.Touch += EditFinal_Touch;

        }

        private void EditInicio_Touch(object sender, View.TouchEventArgs e) {
            if (e.Event.Action == MotionEventActions.Up) {
                TimePickerDialog timeDialog = new TimePickerDialog(this, TiempoInicio, ViewModel.Dia.Inicio.Horas, ViewModel.Dia.Inicio.Minutos, true);
                timeDialog.SetMessage("Hora de Inicio");
                timeDialog.Show();
                ((EditText)sender).RequestFocus();
                ((EditText)sender).SetSelection(0);
                e.Handled = true;
            }
        }

        private void EditFinal_Touch(object sender, View.TouchEventArgs e) {
            if (e.Event.Action == MotionEventActions.Up) {
                TimePickerDialog timeDialog = new TimePickerDialog(this, TiempoFinal, ViewModel.Dia.Final.Horas, ViewModel.Dia.Final.Minutos, true);
                timeDialog.SetMessage("Hora de Final");
                timeDialog.Show();
                ((EditText)sender).RequestFocus();
                ((EditText)sender).SetSelection(0);
                e.Handled = true;
            }
        }

        private void TiempoInicio(object sender, TimePickerDialog.TimeSetEventArgs e) {
            ViewModel.Dia.Inicio = new Tiempo(e.HourOfDay, e.Minute);
        }

        private void TiempoFinal(object sender, TimePickerDialog.TimeSetEventArgs e) {
            ViewModel.Dia.Final = new Tiempo(e.HourOfDay, e.Minute);
        }


        public override bool OnOptionsItemSelected(IMenuItem item) {
            if (item.ItemId == global::Android.Resource.Id.Home) {
                OnBackPressed();
            }
            return base.OnOptionsItemSelected(item);
        }


        // AÑADIR ESTO A TODAS LAS VIEWS (ACTIVITIES)
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults) {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

    }
}