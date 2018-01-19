using System;
using System.Collections.Generic;
using System.Linq;
using SQLite.Net;
using TwilightImperiumMasterCompanion.Core.DataAccess.Interfaces;
using TwilightImperiumMasterCompanion.Core.DataAccess.Scripts;
using TwilightImperiumMasterCompanion.Core.Enum;

namespace TwilightImperiumMasterCompanion.Core.DataAccess
{
    public class SessionDataAccess : ISessionDataAccess
    {
        private readonly SQLiteConnection databaseConnection;
        private readonly IScriptRepository scriptRepository;

        public SessionDataAccess(ISQLite database, IScriptRepository scriptRepository)
        {
            this.scriptRepository = scriptRepository;
            this.databaseConnection = database.GetConnection();
        }

        public Race GetSelectedRace()
        {
            var query = scriptRepository.GetScript("GetSelectedRace.sql");
            return databaseConnection.Query<Race>(query).First();
        }

        public void UpdateExpansionStatus(Expansion expansion, bool expansionEnabled)
        {
			var columnExpansionName = expansion.ToString() + "ExpansionEnabled";
            var script = scriptRepository.GetScript("UpdateExpansionStatus.sql");
            var command = String.Format(script, columnExpansionName, Convert.ToInt32(expansionEnabled));
            databaseConnection.Execute(command);
        }

        public void UpdateSelectedRace(int raceID)
        {
            databaseConnection.Execute(scriptRepository.GetScript("UpdateSelectedRace.sql"), raceID);
        }

        public void UpdatePlanet(int planetId, bool exhausted){
            int exhaustedValue = Convert.ToInt32(exhausted);
            var script = String.Format(scriptRepository.GetScript("UpdatePlanet.sql"), planetId, exhaustedValue);
            databaseConnection.Execute(script);
        }

        public List<Planet> GetSessionPlanets()
        {
            return databaseConnection.Query<Planet>(scriptRepository.GetScript("GetSessionPlanets.sql"));
        }
    }
}
