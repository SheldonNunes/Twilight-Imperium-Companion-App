using System;
using System.Collections.Generic;
using SQLite.Net;
using TwilightImperiumMasterCompanion.Core.DataAccess.Interfaces;

namespace TwilightImperiumMasterCompanion.Core.DataAccess
{
    public class UnitDataAccess : IUnitDataAccess
    {
		private readonly SQLiteConnection databaseConnection;

        public UnitDataAccess(ISQLite database)
		{
			this.databaseConnection = database.GetConnection();
		}

        public List<Unit> GetUnits(bool ShatteredEmpiresExpansion, bool ShardsOfTheThroneExpansion)
        {
			var query = "SELECT * FROM Unit WHERE Expansion = 0";
			if (ShatteredEmpiresExpansion)
				query += " OR Expansion = 1";
			if (ShardsOfTheThroneExpansion)
				query += " OR Expansion = 2";
			return (databaseConnection.Query<Unit>(query));
        }
    }
}
