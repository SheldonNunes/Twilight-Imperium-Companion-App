namespace TwilightImperiumMasterCompanion.Core
{
	public class Ship
	{
		public string Name { get; set; }

		public int Cost { get; set; }

		public int Battle { get; set; }

		public int Movement { get; set; }

		public int Capacity { get; set; }

		public SpecialAbilities[] Special { get; set; }
	}
}
