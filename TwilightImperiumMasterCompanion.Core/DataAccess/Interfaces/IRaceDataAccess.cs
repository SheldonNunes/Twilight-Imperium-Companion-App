using System;
using System.Collections.Generic;
using TwilightImperiumMasterCompanion.Core.Enum;

namespace TwilightImperiumMasterCompanion.Core.DataAccess.Interfaces
{
    public interface IRaceDataAccess
    {
        List<Race> GetRaces(bool ShatteredEmpiresExpansion, bool ShardsOfTheThroneExpansion);

        List<RaceAbility> GetRaceAbility(Race race);
    }
}
