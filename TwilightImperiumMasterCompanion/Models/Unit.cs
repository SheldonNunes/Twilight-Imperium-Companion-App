using System;

namespace TwilightImperiumMasterCompanion
{
	public abstract class Unit
	{
		public string Name {
			get;
			set;
		}
		public int Cost {
			get;
			set;
		}

		public int Battle {
			get;
			set;
		}

		public int Health {
			get;
			set;
		}

		public Unit (string name, int cost, int battle, int health)
		{
			Name = name;
			Cost = cost;
			Battle = battle;
			Health = health;
		}
	}
}

