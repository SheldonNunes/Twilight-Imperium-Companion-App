using System;
using System.Collections.Generic;

namespace TwilightImperiumMasterCompanion.Core.DataAccess.Interfaces
{
    public interface IPlanetDataAccess
    {
        List<Planet> GetPlanets();
    }
}
