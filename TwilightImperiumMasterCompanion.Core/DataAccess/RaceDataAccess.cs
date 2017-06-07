using System;
using System.Collections.Generic;
using System.Linq;
using SQLite.Net;
using TwilightImperiumMasterCompanion.Core.DataAccess.Interfaces;
using TwilightImperiumMasterCompanion.Core.Dto;
using TwilightImperiumMasterCompanion.Core.Model;

namespace TwilightImperiumMasterCompanion.Core
{
    public class RaceDataAccess : IRaceDataAccess
	{
        private readonly SQLiteConnection databaseConnection;

        public RaceDataAccess(ISQLite database)
		{
            this.databaseConnection = database.GetConnection();
		}

		public List<Race> GetRaces(bool ShatteredEmpiresExpansion, bool ShardsOfTheThroneExpansion)
		{
            var query = "SELECT * FROM Race WHERE Expansion = 0";
            if (ShatteredEmpiresExpansion)
                query += " OR Expansion = 1";
            if (ShardsOfTheThroneExpansion)
                query += " OR Expansion = 2";
            return (databaseConnection.Query<Race>(query));
		}

		public List<RaceAbility> GetRaceAbility(Race race)
		{
			return databaseConnection.Query<RaceAbility>("SELECT DESCRIPTION FROM RaceAbilityTranslation JOIN Race ON Race.RaceID = RaceAbilityTranslation.RaceID WHERE Name=?", race.Name);
		}

        public Race GetRace(string raceName)
        {
            return databaseConnection.Query<Race>("Select * FROM RACE WHERE Name = ? LIMIT 1", raceName).FirstOrDefault();
        }

        public List<StartingPlanetDto> GetStartingPlanets(int raceID)
        {
            var query = "" +
                "SELECT Name AS Title FROM Planet " +
                "JOIN RaceStartingPlanets " +
                "ON Planet.ID = RaceStartingPlanets.PlanetID " +
                "WHERE RaceStartingPlanets.RaceID = ?";

            return databaseConnection.Query<StartingPlanetDto>(query, raceID);
        }

        public List<StartingUnitDto> GetStartingUnits(int raceID)
        {
            var query = "SELECT * FROM Unit JOIN RaceStartingUnits ON Unit.UnitID = RaceStartingUnits.UnitID WHERE RaceStartingUnits.RaceID = ?";
            return databaseConnection.Query<StartingUnitDto>(query, raceID);
        }

        public List<Technology> GetStartingTechnology(int raceID){
			var query = "SELECT * FROM RaceStartingTechnology JOIN Technology ON RaceStartingTechnology.TechnologyID = Technology.TechnologyID WHERE RaceStartingTechnology.RaceID = ?";
            return databaseConnection.Query<Technology>(query, raceID);
        }

        public List<Leader> GetLeaders(int raceID)
        {
            var query = "SELECT Name, LeaderType  FROM Leader JOIN RaceLeader ON Leader.LeaderID = RaceLeader.LeaderID WHERE RaceID = ?";
            return databaseConnection.Query<Leader>(query, raceID);
        }

		public List<LeaderAbility> GetLeaderAbilities(string LeaderType)
		{
			var query = "SELECT Description FROM LeaderAbilityTranslation JOIN Leader ON Leader.LeaderID = LeaderAbilityTranslation.LeaderID WHERE LeaderType = ?";
            return databaseConnection.Query<LeaderAbility>(query, LeaderType);
		}
    }
}
