using System;
using TwilightImperiumMasterCompanion.Core.Enum;

namespace TwilightImperiumMasterCompanion.Core.Services.Interfaces
{
    public interface ISessionService
    {
        void SaveExpansion(Expansion expansion, bool expansionEnabled);

        bool GetExpansionStatus(Expansion expansion);

        void SetSelectedRace(Race race);

		Race GetSelectedRace();
    }
}
