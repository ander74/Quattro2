using Android.App;
using MvvmCross;
using MvvmCross.Platforms.Android;
using Quattro.Core.Interfaces;

namespace Quattro.Droid.Services {

    public class DialogService : IDialogService {
        public void Alert(string mensaje, string titulo, string textoBotonOk) {

            var top = Mvx.IoCProvider.Resolve<IMvxAndroidCurrentTopActivity>();
            var act = top.Activity;
            var adb = new AlertDialog.Builder(act);
            adb.SetTitle(titulo);
            adb.SetMessage(mensaje);
            adb.SetPositiveButton(textoBotonOk, (sender, args) => { /* Aquí puede ir código que se ejecute. */ });
            adb.Create().Show();
        }
    }
}