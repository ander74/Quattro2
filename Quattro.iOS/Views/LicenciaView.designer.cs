﻿// WARNING
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
    [Register ("LicenciaView")]
    partial class LicenciaView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton BtAceptar { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton BtCancelar { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView LabelLicencia { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel LabelPrueba { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (BtAceptar != null) {
                BtAceptar.Dispose ();
                BtAceptar = null;
            }

            if (BtCancelar != null) {
                BtCancelar.Dispose ();
                BtCancelar = null;
            }

            if (LabelLicencia != null) {
                LabelLicencia.Dispose ();
                LabelLicencia = null;
            }

            if (LabelPrueba != null) {
                LabelPrueba.Dispose ();
                LabelPrueba = null;
            }
        }
    }
}