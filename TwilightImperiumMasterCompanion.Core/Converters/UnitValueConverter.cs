using System;
using MvvmCross.Platform.Converters;

namespace TwilightImperiumMasterCompanion.Core.Converters
{
    public class UnitValueConverter : MvxValueConverter<int, string>
    {
        protected override string Convert(int value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value < 0)
            {
                return "-";
            }
            else
            {
                return value.ToString();
            }
        }
    }
}
