using System;

namespace TwilightImperiumMasterCompanion
{
	public class Ship : Unit
	{
		private int cost;
		private int movement;
		private int battle;
		private int health;

		public int CostModifier {
			get;
			set;
		}

		public int MovementModifier {
			get;
			set;
		}

		public int BattleModifier {
			get;
			set;
		}

		public int HealthModifier {
			get;
			set;
		}

		
		public Ship (string name, int cost, int movement, int battle, int health)
			: base (name, cost, battle, health)
		{
			
			this.movement = movement;
		}
	}
}

