using System.Collections.Generic;
using TwilightImperiumMasterCompanion.Core.DataAccess.Interfaces;
using TwilightImperiumMasterCompanion.Core.Enum;

namespace TwilightImperiumMasterCompanion.Core.Services
{
    public class SessionService : BaseService, ISessionService
    {
        private readonly ISessionDataAccess sessionDataAccess;
        private readonly IRaceDataAccess raceDataAccess;

        public SessionService(ISessionDataAccess playerDataAccess, IRaceDataAccess raceDataAccess)
        {
            this.raceDataAccess = raceDataAccess;
            this.sessionDataAccess = playerDataAccess;
        }

        public Race GetSelectedRace()
        {
            return sessionDataAccess.GetSelectedRace();
        }

        public void SaveExpansion(Expansion expansion, bool expansionEnabled)
        {
            sessionDataAccess.UpdateExpansionStatus(expansion, expansionEnabled);
        }

        public void SetSelectedRace(Race race)
        {
            sessionDataAccess.UpdateSelectedRace(race.RaceID);

            var startingPlanets = raceDataAccess.GetStartingPlanets(race.RaceID);

            foreach (var startingPlanet in startingPlanets)
            {
                var planet = new Planet()
                {
                    PlanetId = startingPlanet.PlanetId,
                    Name = startingPlanet.Title,
                    Resource = startingPlanet.Resource,
                    Influence = startingPlanet.Influence,
                    ExpansionLevel = startingPlanet.ExpansionLevel
                };

                SavePlanet(planet, false);
            }
        }

        public void SavePlanet(Planet planet, bool exhausted = true){
            sessionDataAccess.UpdatePlanet(planet.PlanetId, exhausted);
        }

        public List<Planet> GetSessionPlanets(){
            return sessionDataAccess.GetSessionPlanets();
        }
    }
}
