using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TwilightImperiumMasterCompanion.Core
{
	public class ShipRepository : IShipRepository
	{

		private static readonly List<Ship> _ships = new List<Ship>()
		{
			new Ship("Fighter", 1, 1, 1, 0)
		};


		public async Task<IEnumerable<Ship>> GetShips()
		{
			return await Task.FromResult(_ships);
		}
	}
}
