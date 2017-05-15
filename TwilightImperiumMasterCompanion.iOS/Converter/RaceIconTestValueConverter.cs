using System;
using MvvmCross.Platform.Converters;
using UIKit;

namespace TwilightImperiumMasterCompanion.Core
{
	public class RaceIconTestValueConverter : MvxValueConverter<string, UIImage>
	{
		public RaceIconTestValueConverter()
		{
		}

		protected override UIImage Convert(string value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return UIImage.FromBundle(value.Replace(" ", String.Empty) + "Icon");
			//return base.Convert(value, targetType, parameter, culture);
		}

	}
}
