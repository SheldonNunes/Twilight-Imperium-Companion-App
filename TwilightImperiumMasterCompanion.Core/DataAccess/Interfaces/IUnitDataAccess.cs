using System.Collections.Generic;

namespace TwilightImperiumMasterCompanion.Core.DataAccess.Interfaces
{
    public interface IUnitDataAccess
    {
        List<Unit> GetUnits(bool ShatteredEmpiresExpansion, bool ShardsOfTheThroneExpansion);
    }
}
