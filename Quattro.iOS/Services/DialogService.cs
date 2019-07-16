using System;
using Foundation;
using Quattro.Core.Interfaces;
using UIKit;

namespace Quattro.iOS.Services {

    public class DialogService : IDialogService {

        // ====================================================================================================
        #region CAMPOS PRIVADOS
        // ====================================================================================================

        private NSTimer temporizador;
        private UIAlertController dialogo;


        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region MÉTODOS DE INTERFAZ
        // ====================================================================================================

        public void Alert(string mensaje, string titulo, string textoBotonOk) {
            var diag = UIAlertController.Create(titulo, mensaje, UIAlertControllerStyle.Alert);
            diag.AddAction(UIAlertAction.Create(textoBotonOk, UIAlertActionStyle.Destructive, (action) => { }));
            UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(diag, true, null);
            //this.PresentViewController(dialogo, true, null);
        }


        public void Alert(string mensaje, string titulo, string textoBotonOk, Action confirmar) {
            var diag = UIAlertController.Create(titulo, mensaje, UIAlertControllerStyle.Alert);
            diag.AddAction(UIAlertAction.Create(textoBotonOk, UIAlertActionStyle.Destructive, (action) => { confirmar?.Invoke(); }));
            UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(diag, true, null);
        }


        public void Confirmar(string mensaje, string titulo, string textoBotonOk, string textoBotonCancel, Action confirmar, Action cancelar) {
            var diag = UIAlertController.Create(titulo, mensaje, UIAlertControllerStyle.Alert);
            diag.AddAction(UIAlertAction.Create(textoBotonOk, UIAlertActionStyle.Destructive, (action) => { confirmar?.Invoke(); }));
            diag.AddAction(UIAlertAction.Create(textoBotonCancel, UIAlertActionStyle.Destructive, (action) => { cancelar?.Invoke(); }));
            UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(diag, true, null);
        }


        public void ShortToast(string mensaje) {
            mostrarToast(mensaje, 2.0);
        }


        public void LongToast(string mensaje) {
            mostrarToast(mensaje, 3.5);
        }


        public void Input(string titulo, string botonOk, string botonCancelar, Action<string> confirmar) {
            //TODO: Implementar.
        }


        public void InputNuevaLinea(Action<string, string> confirmar) {
            //TODO Implementar
        }

        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region MÉTODOS PRIVADOS
        // ====================================================================================================

        private void mostrarToast(string message, double seconds) {
            temporizador = NSTimer.CreateScheduledTimer(seconds, (obj) => {
                dialogo?.DismissViewController(true, null);
                temporizador?.Dispose();
            });
            dialogo = UIAlertController.Create(null, message, UIAlertControllerStyle.Alert);
            UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(dialogo, true, null);
        }

        #endregion
        // ====================================================================================================


    }
}