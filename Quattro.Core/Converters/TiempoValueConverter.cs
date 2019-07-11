using System;
using System.Globalization;
using MvvmCross.Converters;
using Quattro.Core.Common;

namespace Quattro.Core.Converters {

    public class TiempoValueConverter : MvxValueConverter<Tiempo, string> {

        protected override string Convert(Tiempo value, Type targetType, object parameter, CultureInfo culture) {
            return value.ToString("hm");
        }

        protected override Tiempo ConvertBack(string value, Type targetType, object parameter, CultureInfo culture) {
            if (Tiempo.TryParse(value, out Tiempo resultado)) {
                return resultado;
            }
            return null;
        }
    }
}
