using System.Collections.Generic;
using SQLite.Net;
using TwilightImperiumMasterCompanion.Core.DataAccess.Interfaces;
using TwilightImperiumMasterCompanion.Core.DataAccess.Scripts;
using TwilightImperiumMasterCompanion.Core.Model;

namespace TwilightImperiumMasterCompanion.Core.DataAccess
{
    public class UnitDataAccess : IUnitDataAccess
    {
		private readonly SQLiteConnection databaseConnection;
        private readonly IScriptRepository scriptRepository;

        public UnitDataAccess(ISQLite database, IScriptRepository scriptRepository)
		{
            this.scriptRepository = scriptRepository;
            this.databaseConnection = database.GetConnection();
		}

        public List<Unit> GetUnits()
        {
            return (databaseConnection.Query<Unit>(scriptRepository.GetScript("GetUnits.sql")));
        }
    }
}
