using System;
using Android.App;
using Android.Views;
using Android.Widget;
using MvvmCross;
using MvvmCross.Platforms.Android;
using Quattro.Core.Interfaces;

namespace Quattro.Droid.Services {

    public class DialogService : IDialogService {


        // ====================================================================================================
        #region MÉTODOS DE INTERFAZ
        // ====================================================================================================

        public void Alert(string mensaje, string titulo, string textoBotonOk) {

            var top = Mvx.IoCProvider.Resolve<IMvxAndroidCurrentTopActivity>();
            var act = top.Activity;
            var adb = new AlertDialog.Builder(act);
            adb.SetTitle(titulo);
            adb.SetMessage(mensaje);
            adb.SetPositiveButton(textoBotonOk, (sender, args) => { });
            adb.Create().Show();
        }

        public void Alert(string mensaje, string titulo, string textoBotonOk, Action confirmar) {

            var top = Mvx.IoCProvider.Resolve<IMvxAndroidCurrentTopActivity>();
            var act = top.Activity;
            var adb = new AlertDialog.Builder(act);
            adb.SetTitle(titulo);
            adb.SetMessage(mensaje);
            adb.SetPositiveButton(textoBotonOk, (sender, args) => { if (confirmar != null) confirmar.Invoke(); });
            adb.Create().Show();
        }

        public void Confirmar(string mensaje, string titulo, string textoBotonOk, string textoBotonCancel, Action confirmar, Action cancelar) {

            var top = Mvx.IoCProvider.Resolve<IMvxAndroidCurrentTopActivity>();
            var act = top.Activity;
            var adb = new AlertDialog.Builder(act);
            adb.SetTitle(titulo);
            adb.SetMessage(mensaje);
            adb.SetPositiveButton(textoBotonOk, (sender, args) => { if (confirmar != null) confirmar.Invoke(); });
            adb.SetNegativeButton(textoBotonCancel, (sender, args) => { if (cancelar != null) cancelar.Invoke(); });
            adb.Create().Show();
        }


        public void ShortToast(string mensaje) {
            Toast.MakeText(Application.Context, mensaje, ToastLength.Short).Show();
        }


        public void LongToast(string mensaje) {
            Toast.MakeText(Application.Context, mensaje, ToastLength.Long).Show();
        }


        public void Input(string titulo, string textoBotonOk, string textoBotonCancel, Action<string> confirmar) {
            var top = Mvx.IoCProvider.Resolve<IMvxAndroidCurrentTopActivity>();
            var act = top.Activity;
            var adb = new AlertDialog.Builder(act);
            var entrada = new EditText(act);
            adb.SetTitle(titulo);
            adb.SetView(entrada);
            adb.SetPositiveButton(textoBotonOk, (sender, args) => { if (confirmar != null) confirmar.Invoke(entrada.Text); });
            adb.SetNegativeButton(textoBotonCancel, (sender, args) => { });
            adb.Create().Show();
        }

        public void InputNuevaLinea(Action<string, string> confirmar) {
            var top = Mvx.IoCProvider.Resolve<IMvxAndroidCurrentTopActivity>();
            var act = top.Activity;
            var adb = new AlertDialog.Builder(act);
            adb.SetTitle("Nueva Línea");
            var vista = LayoutInflater.From(act).Inflate(Resource.Layout.NuevaLineaDialog, null);
            adb.SetView(vista);
            var editLinea = vista.FindViewById<EditText>(Resource.Id.editLinea);
            var editDescripcion = vista.FindViewById<EditText>(Resource.Id.editDescripcion);
            adb.SetPositiveButton("Guardar", (sender, args) => { if (confirmar != null) confirmar.Invoke(editLinea.Text, editDescripcion.Text); });
            adb.SetNegativeButton("Cancelar", (sender, args) => { });
            adb.Create().Show();
        }


        #endregion
        // ====================================================================================================


    }
}