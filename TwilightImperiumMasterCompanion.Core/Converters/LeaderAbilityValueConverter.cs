using System;
using System.Collections.Generic;
using System.Text;
using MvvmCross.Platform.Converters;
using TwilightImperiumMasterCompanion.Core.Model;

namespace TwilightImperiumMasterCompanion.Core.Converters
{
    public class LeaderAbilityValueConverter : MvxValueConverter<List<LeaderAbility>, string>
    {
        protected override string Convert(List<LeaderAbility> value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
			var stringBuilder = new StringBuilder();
            foreach (var leaderAbility in value)
			{
                stringBuilder.AppendLine(leaderAbility.Description);
                stringBuilder.AppendLine();
			}
			return stringBuilder.ToString();
        }
    }
}
