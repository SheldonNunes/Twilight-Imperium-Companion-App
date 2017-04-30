using System.Collections.Generic;

namespace TwilightImperiumMasterCompanion.Core
{
	public interface IShipRepository
	{
		IEnumerable<Ship> GetShips();
	}
}
