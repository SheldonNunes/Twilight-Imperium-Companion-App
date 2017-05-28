using System;
using System.Collections.Generic;

namespace TwilightImperiumMasterCompanion.Core
{
	public interface IRaceAbilityService
	{
		List<RaceAbility> GetRaceAbility(Race race);
	}
}
