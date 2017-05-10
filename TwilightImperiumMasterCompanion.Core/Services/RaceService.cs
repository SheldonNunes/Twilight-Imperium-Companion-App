using System;
using System.Collections.Generic;

namespace TwilightImperiumMasterCompanion.Core
{
	public class RaceService : BaseService, IRaceService
	{
		private readonly RaceDataAccess raceDataAccess;
		public RaceService()
		{
			raceDataAccess = new RaceDataAccess();
		}

		public List<Race> GetRaces()
		{
			int expansionValue = 0;
			if (ShatteredEmpiresExpansionEnabled)
			{
				expansionValue++;
			}
			if (ShardsOfTheThroneExpansionEnabled)
			{
				expansionValue++;
			}
			return raceDataAccess.GetRaces(expansionValue);
		}



	}
}
