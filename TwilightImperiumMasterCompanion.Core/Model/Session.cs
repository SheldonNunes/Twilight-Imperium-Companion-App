using System;
using SQLite.Net.Attributes;

namespace TwilightImperiumMasterCompanion.Core.Model
{
    public class Session
    {
		[PrimaryKey, AutoIncrement]
		public int ID
		{
			get;
			set;
		}

		public int RaceID
		{
			get;
			set;
		}

		public bool ShatteredEmpireExpansionEnabled
		{
			get;
			set;
		}

		public bool ShardsOfTheThroneExpansionEnabled
		{
			get;
			set;
		}
    }
}
