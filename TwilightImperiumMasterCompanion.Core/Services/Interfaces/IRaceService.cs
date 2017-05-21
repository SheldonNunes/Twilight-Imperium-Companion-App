using System;
using System.Collections.Generic;

namespace TwilightImperiumMasterCompanion.Core
{
	public interface IRaceService
	{
		List<Race> GetRaces();

        Race GetRace(string raceName);

        List<Planet> GetStartingPlanets(Race race);
	}
}
