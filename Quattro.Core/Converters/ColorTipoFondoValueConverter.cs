using System;
using System.Globalization;
using MvvmCross.Plugin.Color;
using MvvmCross.UI;
using Quattro.Core.Common;

namespace Quattro.Core.Converters {
    public class ColorTipoFondoValueConverter : MvxColorValueConverter<Fondo> {

        protected override MvxColor Convert(Fondo value, object parameter, CultureInfo culture) {
            switch (value) {
                case Fondo.Alterno: return new MvxColor(230, 255, 230);
                case Fondo.NormalSeleccionado: return new MvxColor(255, 209, 179);
                case Fondo.AlternoSeleccionado: return new MvxColor(255, 209, 179);
            }
            return new MvxColor(248, 248, 248);

        }
    }
}
