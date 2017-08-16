using System;
using System.Collections.Generic;

namespace TwilightImperiumMasterCompanion.Core.Services.Interfaces
{
	public interface IRaceAbilityService
	{
		List<RaceAbility> GetRaceAbility(Race race);
	}
}
