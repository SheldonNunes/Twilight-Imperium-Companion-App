using System.Collections.Generic;
using System.Threading.Tasks;

namespace TwilightImperiumMasterCompanion.Core
{
	public class ShipRepository : IShipRepository
	{

		private static readonly List<Ship> _ships = new List<Ship>()
		{
			new Ship(){
				Name = "Dreadnaught",
				Cost = 4,
				Movement = 2,
				Battle = 3,
				Capacity = 6
			},
			new Ship(){
				Name = "Carrier",
				Cost = 4,
				Movement = 2,
				Battle = 3,
				Capacity = 6
			},
						new Ship(){
				Name = "Fighter",
				Cost = 4,
				Movement = 2,
				Battle = 3,
				Capacity = 6
			},
						new Ship(){
				Name = "Ground Forces",
				Cost = 4,
				Movement = 2,
				Battle = 3,
				Capacity = 6
			},
						new Ship(){
				Name = "War Sun",
				Cost = 4,
				Movement = 2,
				Battle = 3,
				Capacity = 6
			},
						new Ship(){
				Name = "Destroyer",
				Cost = 4,
				Movement = 2,
				Battle = 3,
				Capacity = 6
			},
						new Ship(){
				Name = "PDS",
				Cost = 4,
				Movement = 2,
				Battle = 3,
				Capacity = 6
			},
		};


		public IEnumerable<Ship> GetShips()
		{
			return _ships;
		}
	}
}
