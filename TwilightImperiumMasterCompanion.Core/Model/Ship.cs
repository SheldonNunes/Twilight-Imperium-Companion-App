using System;
namespace TwilightImperiumMasterCompanion.Core
{
	public class Ship
	{
		public string Name { get; set; }

		public int Cost { get; set; }

		public int Battle { get; set; }

		public int Movement { get; set; }

		public int Capacity { get; set; }

		public Special[] Special { get; set; }


		public Ship(string name, int cost, int battle, int movement, int capacity)
		{
		}
	}
}
