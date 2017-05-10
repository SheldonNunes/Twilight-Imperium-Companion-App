using System;
using System.Collections.Generic;
using System.Linq;
using MvvmCross.Platform;
using SQLite.Net;

namespace TwilightImperiumMasterCompanion.Core
{
	public class RaceDataAccess
	{
		SQLiteConnection dbConn;

		public RaceDataAccess()
		{
			dbConn = Mvx.Resolve<ISQLite>().GetConnection();
		}

		public List<Race> GetRaces(int expansionLevel)
		{
			return (dbConn.Table<Race>().Where(r => r.Expansion <= expansionLevel).ToList());
		}

		public List<RaceAbility> GetRaceAbility(Race race)
		{
			var test = dbConn.Query<RaceAbility>("SELECT DESCRIPTION FROM RaceAbilityTranslation JOIN Race ON Race.ID = RaceAbilityTranslation.RaceID WHERE Name= ?", race.Name);
			return dbConn.Query<RaceAbility>("SELECT DESCRIPTION FROM RaceAbilityTranslation JOIN Race ON Race.ID = RaceAbilityTranslation.RaceID WHERE Name=?", race.Name);
		}

	}
}
