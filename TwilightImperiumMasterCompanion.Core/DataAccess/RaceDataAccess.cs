using System.Collections.Generic;
using System.Linq;
using MvvmCross.Platform;
using SQLite.Net;
using TwilightImperiumMasterCompanion.Core.DataAccess.Interfaces;
using TwilightImperiumMasterCompanion.Core.Enum;

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
			return databaseConnection.Query<RaceAbility>("SELECT DESCRIPTION FROM RaceAbilityTranslation JOIN Race ON Race.ID = RaceAbilityTranslation.RaceID WHERE Name=?", race.Name);
		} 

	}
}
