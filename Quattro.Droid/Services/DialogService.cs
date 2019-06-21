using System;
using Android.App;
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
            adb.SetPositiveButton(textoBotonOk, (sender, args) => {  });
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

        #endregion
        // ====================================================================================================


    }
}