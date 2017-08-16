using System.Collections.Generic;
using TwilightImperiumMasterCompanion.Core.DataAccess.Interfaces;
using TwilightImperiumMasterCompanion.Core.Services.Interfaces;

namespace TwilightImperiumMasterCompanion.Core.Services
{
    public class PlanetService : IPlanetService
    {
        readonly IPlanetDataAccess planetDataAccess;

        public PlanetService(IPlanetDataAccess planetDataAccess)
        {
            this.planetDataAccess = planetDataAccess;
        }

        public List<Planet> GetPlanets()
        {
            return planetDataAccess.GetPlanets();
        }
    }
}
