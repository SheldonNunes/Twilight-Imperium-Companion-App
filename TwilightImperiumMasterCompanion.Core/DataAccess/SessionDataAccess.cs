using System;
using System.Collections.Generic;
using System.Linq;
using SQLite.Net;
using TwilightImperiumMasterCompanion.Core.DataAccess.Interfaces;
using TwilightImperiumMasterCompanion.Core.Enum;
using TwilightImperiumMasterCompanion.Core.Model;

namespace TwilightImperiumMasterCompanion.Core.DataAccess
{
    public class SessionDataAccess : ISessionDataAccess
    {
        private readonly SQLiteConnection databaseConnection;

        public SessionDataAccess(ISQLite database)
        {
            this.databaseConnection = database.GetConnection();
        }

        public bool GetExpansionStatus(Expansion expansion)
        {
            var session = databaseConnection.Query<Session>("SELECT * FROM Session").FirstOrDefault();

            if (expansion == Expansion.ShatteredEmpire)
                return session.ShatteredEmpireExpansionEnabled;
            if (expansion == Expansion.ShardsOfTheThrone)
                return session.ShardsOfTheThroneExpansionEnabled;

            throw new Exception("UnknownExpansion");
        }

        public Race GetSelectedRace()
        {
            var selectedRace = databaseConnection.Query<Race>("SELECT * FROM Race JOIN Session ON Session.RaceID = Race.RaceID").First();
            return selectedRace;
        }

        public void SaveExpansion(Expansion expansion, bool expansionEnabled)
        {
            var columnExpansionName = expansion.ToString() + "ExpansionEnabled";
            var script = String.Format("UPDATE Session SET {0} = '{1}'", columnExpansionName, Convert.ToInt32(expansionEnabled));
            databaseConnection.Execute(script);
        }

        public void SetSelectedRace(int raceID)
        {
            databaseConnection.Execute("UPDATE Session SET RaceID = ?", raceID);
        }

        public void SavePlanet(int planetId, bool exhausted){
            int exhaustedValue = exhausted ? 1 : 0;
            var script = String.Format("INSERT INTO SessionPlanet (PlanetId, Exhausted) VALUES ({0},{1});", planetId, exhaustedValue);
            databaseConnection.Execute(script);
        }

        public List<Planet> GetSessionPlanets()
        {
            return databaseConnection.Query<Planet>("SELECT * FROM SessionPlanet JOIN Planet ON SessionPlanet.PlanetId = Planet.ID");
        }
    }
}
