using System;
using MvvmCross.Platform;
using SQLite.Net;

namespace TwilightImperiumMasterCompanion.Core
{
	public class BaseService
	{
		public static bool ShatteredEmpiresExpansionEnabled
		{
			get;
			set;
		}

		public static bool ShardsOfTheThroneExpansionEnabled
		{
			get;
			set;
		}

		public readonly SQLiteConnection dbConnection;

		public BaseService()
		{
			dbConnection = Mvx.Resolve<ISQLite>().GetConnection();
		}
	}
}
