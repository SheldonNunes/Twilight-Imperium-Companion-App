using System;
using System.Collections.Generic;
using System.Text;
using MvvmCross.Platform.Converters;
using TwilightImperiumMasterCompanion.Core.Model;

namespace TwilightImperiumMasterCompanion.Core.Converters
{
    public class StringListToBulletPointValueConverter : MvxValueConverter<List<Technology>, string>
    {
        protected override string Convert(List<Technology> value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
			var stringBuilder = new StringBuilder();
			foreach (var technology in value)
			{
                stringBuilder.AppendLine("* " + technology.Name);
			}
			return stringBuilder.ToString();
        }
    }
}
