using System;
using MvvmCross.Platform.Converters;

namespace TwilightImperiumMasterCompanion.Core
{
	public class RaceIconImagePathValueConverter : MvxValueConverter<string>
	{
		public RaceIconImagePathValueConverter()
		{
		}

		protected override object Convert(string value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			var result = "res:" + value.Replace(" ", String.Empty) + "Icon";// + ".png";
																			//result = result.ToLower();
			return result;
			//return base.Convert(value, targetType, parameter, culture);
		}
	}
}
