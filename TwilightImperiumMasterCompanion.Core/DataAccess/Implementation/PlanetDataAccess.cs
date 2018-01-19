using System.Collections.Generic;
using SQLite.Net;
using TwilightImperiumMasterCompanion.Core.DataAccess.Interfaces;
using TwilightImperiumMasterCompanion.Core.DataAccess.Scripts;

namespace TwilightImperiumMasterCompanion.Core.DataAccess
{
    public class PlanetDataAccess : IPlanetDataAccess
    {
        private readonly SQLiteConnection databaseConnection;
        private readonly IScriptRepository scriptRepository;

        public PlanetDataAccess(ISQLite database, IScriptRepository scriptRepository)
        {
            this.scriptRepository = scriptRepository;
            this.databaseConnection = database.GetConnection();
        }

        public List<Planet> GetPlanets()
        {
			var query = scriptRepository.GetScript("GetPlanets.sql");
			return (databaseConnection.Query<Planet>(query));
        }
    }
}
