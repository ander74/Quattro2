using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using MvvmCross.Plugin.Color;
using MvvmCross.UI;

namespace Quattro.Core.Converters {

    public class ColorDiaValueConverter : MvxColorValueConverter<(DateTime, bool)> {
        protected override MvxColor Convert((DateTime, bool) value, object parameter, CultureInfo culture) {
            if (value.Item1.DayOfWeek == DayOfWeek.Sunday) return new MvxColor(255, 0, 0);
            if (value.Item2) return new MvxColor(255, 0, 0);
            return new MvxColor(0, 0, 0);
        }
    }
}
