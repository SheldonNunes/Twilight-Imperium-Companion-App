using System;
using System.Collections.Generic;
using MvvmCross.Platform.Converters;

namespace TwilightImperiumMasterCompanion.Core
{
	public class RaceListConverter : MvxValueConverter<List<Race>, List<Race>>
	{
		protected override List<Race> Convert(List<Race> value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if (value.Count > 0)
			{
				var first = value[0];
				var last = value[value.Count - 1];

				value.Insert(0, last);
				value.Insert(value.Count, first);
			}
			return value;
		}
	}
}
