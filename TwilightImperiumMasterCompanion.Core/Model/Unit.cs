namespace TwilightImperiumMasterCompanion.Core.Model
{
    public class Unit
	{
		public int UnitID
		{
			get;
			set;
		}

		public string Name { get; set; }

		public int Cost { get; set; }

		public int Battle { get; set; }

		public int Movement { get; set; }

		public int Capacity { get; set; }
	}
}
