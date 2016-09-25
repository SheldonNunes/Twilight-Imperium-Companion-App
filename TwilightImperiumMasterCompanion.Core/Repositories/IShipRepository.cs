using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TwilightImperiumMasterCompanion.Core
{
	public interface IShipRepository
	{
		Task<IEnumerable<Ship>> GetShips();
	}
}
