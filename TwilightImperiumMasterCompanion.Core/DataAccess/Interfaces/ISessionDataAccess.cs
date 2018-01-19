using System.Collections.Generic;
using TwilightImperiumMasterCompanion.Core.Enum;

namespace TwilightImperiumMasterCompanion.Core.DataAccess.Interfaces
{
    public interface ISessionDataAccess
    {
        void UpdateExpansionStatus(Expansion expansion, bool expansionEnabled);

        void UpdateSelectedRace(int raceID);

        Race GetSelectedRace();

        void UpdatePlanet(int planetId, bool exhausted = true);

		List<Planet> GetSessionPlanets();

	}
}
