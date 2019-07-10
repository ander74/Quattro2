// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Quattro.iOS.Views
{
    [Register ("CalendarioView")]
    partial class CalendarioView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton BtRetroceder { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton BtSiguiente { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel LabelAcumuladas { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel LabelNocturnas { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView ListaCalendario { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView ViewNavegacion { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (BtRetroceder != null) {
                BtRetroceder.Dispose ();
                BtRetroceder = null;
            }

            if (BtSiguiente != null) {
                BtSiguiente.Dispose ();
                BtSiguiente = null;
            }

            if (LabelAcumuladas != null) {
                LabelAcumuladas.Dispose ();
                LabelAcumuladas = null;
            }

            if (LabelNocturnas != null) {
                LabelNocturnas.Dispose ();
                LabelNocturnas = null;
            }

            if (ListaCalendario != null) {
                ListaCalendario.Dispose ();
                ListaCalendario = null;
            }

            if (ViewNavegacion != null) {
                ViewNavegacion.Dispose ();
                ViewNavegacion = null;
            }
        }
    }
}