using System;
using System.Collections.Generic;
using TwilightImperiumMasterCompanion.Core.Enum;

namespace TwilightImperiumMasterCompanion.Core.Services.Interfaces
{
    public interface ISessionService
    {
        void SaveExpansion(Expansion expansion, bool expansionEnabled);

        void SetSelectedRace(Race race);

        Race GetSelectedRace();

        void SavePlanet(Planet planet, bool exhausted);

        List<Planet> GetSessionPlanets();
    }
}
