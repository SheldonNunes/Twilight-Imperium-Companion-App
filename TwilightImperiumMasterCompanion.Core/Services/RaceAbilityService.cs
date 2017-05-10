using System;
using System.Collections.Generic;

namespace TwilightImperiumMasterCompanion.Core
{
	public class RaceAbilityService : BaseService, IRaceAbilityService
	{
		private readonly RaceDataAccess raceDataAccess;
		public RaceAbilityService()
		{
			raceDataAccess = new RaceDataAccess();
		}

		public List<RaceAbility> GetRaceAbility(Race race)
		{
			return raceDataAccess.GetRaceAbility(race);
		}
	}
}
