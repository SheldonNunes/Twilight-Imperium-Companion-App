using System.Collections.Generic;
using TwilightImperiumMasterCompanion.Core.Model;

namespace TwilightImperiumMasterCompanion.Core.DataAccess.Interfaces
{
    public interface IUnitDataAccess
    {
        List<Unit> GetUnits(bool ShatteredEmpiresExpansion, bool ShardsOfTheThroneExpansion);
    }
}
