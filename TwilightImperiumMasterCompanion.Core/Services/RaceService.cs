using System.Collections.Generic;
using TwilightImperiumMasterCompanion.Core.DataAccess.Interfaces;
using TwilightImperiumMasterCompanion.Core.Dto;
using TwilightImperiumMasterCompanion.Core.Model;
using TwilightImperiumMasterCompanion.Core.Services.Interfaces;

namespace TwilightImperiumMasterCompanion.Core.Services
{
    public class RaceService : BaseService, IRaceService
	{
		private readonly IRaceDataAccess raceDataAccess;
        private readonly ISessionService sessionService;

		public RaceService(IRaceDataAccess raceDataAccess, ISessionService sessionService)
		{
            this.raceDataAccess = raceDataAccess;
            this.sessionService = sessionService;
		}

        public Race GetRace(string raceName)
        {
            return raceDataAccess.GetRace(raceName);
        }

        public List<Race> GetRaces()
		{
            return raceDataAccess.GetRaces();
		}

        public List<StartingPlanetDto> GetStartingPlanets(Race race)
        {
            return raceDataAccess.GetStartingPlanets(race.RaceID);
        }

        public List<StartingUnitDto> GetStartingUnits(Race race)
        {
            var unitList = raceDataAccess.GetStartingUnits(race.RaceID);
            return unitList;
        }

		public List<Technology> GetStartingTechnology(Race race)
		{
			var technologyList = raceDataAccess.GetStartingTechnology(race.RaceID);
            return technologyList;
		}

        public List<Leader> GetLeaders(Race race)
        {
            var leaders = raceDataAccess.GetLeaders(race.RaceID);

            foreach (var leader in leaders)
            {
                var leaderAbilities = raceDataAccess.GetLeaderAbilities(leader.LeaderType);
                leader.Abilities = leaderAbilities;
            }

            return leaders;
        }

    }
}
