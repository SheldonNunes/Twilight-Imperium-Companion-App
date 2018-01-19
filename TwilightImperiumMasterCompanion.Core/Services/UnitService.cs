using System.Collections.Generic;
using TwilightImperiumMasterCompanion.Core.DataAccess.Interfaces;
using TwilightImperiumMasterCompanion.Core.Model;
using TwilightImperiumMasterCompanion.Core.Services.Interfaces;

namespace TwilightImperiumMasterCompanion.Core.Services
{
    public class UnitService : IUnitService
    {
		private readonly IUnitDataAccess unitDataAccess;
		public UnitService(IUnitDataAccess unitDataAccess)
		{
            this.unitDataAccess = unitDataAccess;
		}

        public List<Unit> GetUnits()
		{
			return unitDataAccess.GetUnits();
		}
    }
}
