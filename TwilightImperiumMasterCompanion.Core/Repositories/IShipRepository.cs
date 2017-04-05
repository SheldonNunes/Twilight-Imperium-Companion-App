using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TwilightImperiumMasterCompanion.Core
{
	public interface IShipRepository
	{
		IEnumerable<Ship> GetShips();
	}
}
