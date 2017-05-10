using System;
using System.Collections.Generic;
using System.Text;
using MvvmCross.Platform.Converters;

namespace TwilightImperiumMasterCompanion.Core
{
	public class RaceAbilityConverter : MvxValueConverter<List<RaceAbility>, string>
	{
		protected override string Convert(List<RaceAbility> value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			var stringBuilder = new StringBuilder();
			foreach (var ability in value)
			{
				stringBuilder.AppendLine(ability.Description);
				stringBuilder.AppendLine();
			}
			return stringBuilder.ToString();
		}
	}
}
