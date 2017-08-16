using System.Collections.Generic;
using System.Linq;
using SQLite.Net;
using TwilightImperiumMasterCompanion.Core.DataAccess.Interfaces;
using TwilightImperiumMasterCompanion.Core.Dto;
using TwilightImperiumMasterCompanion.Core.Model;
using TwilightImperiumMasterCompanion.Core.DataAccess.Scripts;

namespace TwilightImperiumMasterCompanion.Core.DataAccess
{
    public class RaceDataAccess : IRaceDataAccess
	{
        private readonly SQLiteConnection databaseConnection;
        private readonly IScriptRepository scriptRepository;

        public RaceDataAccess(ISQLite database, IScriptRepository scriptRepository)
		{
            this.scriptRepository = scriptRepository;
            this.databaseConnection = database.GetConnection();
		}

		public List<Race> GetRaces()
		{
            var query = scriptRepository.GetScript("GetRaces.sql");
            return (databaseConnection.Query<Race>(query));
		}

		public List<RaceAbility> GetRaceAbilities(Race race)
		{
            var query = scriptRepository.GetScript("GetRaceAbilities.sql");
			return databaseConnection.Query<RaceAbility>(query, race.Name);
		}

        public Race GetRace(string raceName)
        {
			var query = scriptRepository.GetScript("GetRace.sql");
			return databaseConnection.Query<Race>(query, raceName).FirstOrDefault();
        }

        public List<StartingPlanetDto> GetStartingPlanets(int raceID)
        {
            var query = scriptRepository.GetScript("GetStartingPlanets.sql");
            return databaseConnection.Query<StartingPlanetDto>(query, raceID);
        }

        public List<StartingUnitDto> GetStartingUnits(int raceID)
        {
            var query = scriptRepository.GetScript("GetStartingUnits.sql"); 
            return databaseConnection.Query<StartingUnitDto>(query, raceID);
        }

        public List<Technology> GetStartingTechnology(int raceID){
			var query = scriptRepository.GetScript("GetStartingTechnology.sql");
			return databaseConnection.Query<Technology>(query, raceID);
        }

        public List<Leader> GetLeaders(int raceID)
        {
			var query = scriptRepository.GetScript("GetLeaders.sql");
            return databaseConnection.Query<Leader>(query, raceID);
        }

		public List<LeaderAbility> GetLeaderAbilities(string LeaderType)
		{
            var query = scriptRepository.GetScript("GetLeaderAbilities.sql");
            return databaseConnection.Query<LeaderAbility>(query, LeaderType);
		}
    }
}
