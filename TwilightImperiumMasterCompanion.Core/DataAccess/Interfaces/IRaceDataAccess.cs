using System.Collections.Generic;
using TwilightImperiumMasterCompanion.Core.Dto;
using TwilightImperiumMasterCompanion.Core.Model;

namespace TwilightImperiumMasterCompanion.Core.DataAccess.Interfaces
{
    public interface IRaceDataAccess
    {
        List<Race> GetRaces();

        Race GetRace(string raceName);

        List<RaceAbility> GetRaceAbilities(Race race);

        List<StartingPlanetDto> GetStartingPlanets(int raceID);

        List<StartingUnitDto> GetStartingUnits(int raceID);

        List<Technology> GetStartingTechnology(int raceID);

        List<Leader> GetLeaders(int raceID);

        List<LeaderAbility> GetLeaderAbilities(string leaderType);
    }
}
