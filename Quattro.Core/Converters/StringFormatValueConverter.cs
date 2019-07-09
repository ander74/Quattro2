using System;
using System.Globalization;
using MvvmCross.Converters;

namespace Quattro.Core.Converters {

    public class StringFormatValueConverter : MvxValueConverter {

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value == null) return null;
            if (parameter == null) return value;
            var format = $"{{0:{parameter.ToString()}}}";
            return string.Format(format, value);
        }

    }
}
