using System.Collections.Generic;
using TwilightImperiumMasterCompanion.Core.DataAccess.Interfaces;

namespace TwilightImperiumMasterCompanion.Core.Services
{
    public class RaceAbilityService : BaseService, IRaceAbilityService
	{
		private readonly IRaceDataAccess raceDataAccess;
		public RaceAbilityService(IRaceDataAccess raceDataAccess)
		{
            this.raceDataAccess = raceDataAccess;
		}

		public List<RaceAbility> GetRaceAbility(Race race)
		{
			return raceDataAccess.GetRaceAbilities(race);
		}
	}
}
