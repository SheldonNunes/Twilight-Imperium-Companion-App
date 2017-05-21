using System;
using System.Collections.Generic;
using TwilightImperiumMasterCompanion.Core.Enum;

namespace TwilightImperiumMasterCompanion.Core.DataAccess.Interfaces
{
    public interface IRaceDataAccess
    {
        List<Race> GetRaces(bool ShatteredEmpiresExpansion, bool ShardsOfTheThroneExpansion);

        Race GetRace(string raceName);

        List<RaceAbility> GetRaceAbility(Race race);

        List<Planet> GetStartingPlanets(int raceID);
    }
}
