using System.Collections.Generic;
using TwilightImperiumMasterCompanion.Core.Dto;
using TwilightImperiumMasterCompanion.Core.Model;

namespace TwilightImperiumMasterCompanion.Core.DataAccess.Interfaces
{
    public interface IRaceDataAccess
    {
        List<Race> GetRaces(bool ShatteredEmpiresExpansion, bool ShardsOfTheThroneExpansion);

        Race GetRace(string raceName);

        List<RaceAbility> GetRaceAbility(Race race);

        List<StartingPlanetDto> GetStartingPlanets(int raceID);

        List<StartingUnitDto> GetStartingUnits(int raceID);

        List<Technology> GetStartingTechnology(int raceID);
    }
}
