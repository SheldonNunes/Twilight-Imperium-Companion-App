using System;
using System.Collections.Generic;
using SQLite.Net;
using TwilightImperiumMasterCompanion.Core.DataAccess.Interfaces;

namespace TwilightImperiumMasterCompanion.Core.DataAccess
{
    public class PlanetDataAccess : IPlanetDataAccess
    {
        private SQLiteConnection databaseConnection;

        public PlanetDataAccess(ISQLite database)
        {
            this.databaseConnection = database.GetConnection();
        }

        public List<Planet> GetPlanets()
        {
            var query = "SELECT * FROM Planet";// WHERE Expansion = 0";
			//if (ShatteredEmpiresExpansion)
			//	query += " OR Expansion = 1";
			//if (ShardsOfTheThroneExpansion)
				//query += " OR Expansion = 2";
			return (databaseConnection.Query<Planet>(query));
        }
    }
}
