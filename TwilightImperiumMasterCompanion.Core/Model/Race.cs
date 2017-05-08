using SQLite;
using SQLite.Net.Attributes;

namespace TwilightImperiumMasterCompanion.Core
{
	public class Race
	{
		[PrimaryKey, AutoIncrement]
		public int ID
		{
			get;
			set;
		}

		public string NAME
		{
			get;
			set;
		}

		public int Expansion
		{
			get;
			set;
		}
	}
}
