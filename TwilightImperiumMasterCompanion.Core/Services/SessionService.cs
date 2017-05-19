using System;
using TwilightImperiumMasterCompanion.Core.DataAccess.Interfaces;
using TwilightImperiumMasterCompanion.Core.Enum;

namespace TwilightImperiumMasterCompanion.Core.Services.Interfaces
{
    public class SessionService : ISessionService
    {
        private readonly ISessionDataAccess sessionDataAccess;

        public SessionService(ISessionDataAccess playerDataAccess)
        {
            this.sessionDataAccess = playerDataAccess;
        }

        public bool GetExpansionStatus(Expansion expansion)
        {
            return sessionDataAccess.GetExpansionStatus(expansion);        
        }

        public void SaveExpansion(Expansion expansion, bool expansionEnabled)
        {
            sessionDataAccess.SaveExpansion(expansion, expansionEnabled);
        }
    }
}
