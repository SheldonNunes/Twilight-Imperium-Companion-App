using System;
using TwilightImperiumMasterCompanion.Core.Enum;

namespace TwilightImperiumMasterCompanion.Core.DataAccess.Interfaces
{
    public interface ISessionDataAccess
    {
        bool GetExpansionStatus(Expansion expansion);

        void SaveExpansion(Expansion expansion, bool expansionEnabled);

        void SetSelectedRace(int raceID);

        Race GetSelectedRace();
    }
}
