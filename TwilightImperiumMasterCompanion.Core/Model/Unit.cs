using SQLite.Net.Attributes;

namespace TwilightImperiumMasterCompanion.Core
{
	public class Unit
	{
		[PrimaryKey, AutoIncrement]
		public int ID
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
