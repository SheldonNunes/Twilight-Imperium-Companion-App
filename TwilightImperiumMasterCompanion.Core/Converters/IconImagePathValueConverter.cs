using System;
using MvvmCross.Platform.Converters;

namespace TwilightImperiumMasterCompanion.Core
{
    public class IconImagePathValueConverter : MvxValueConverter<string>
    {
        protected override object Convert(string value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var result = "res:" + value.Replace(" ", String.Empty) + "Icon";
            return result;
        }
    }
}
