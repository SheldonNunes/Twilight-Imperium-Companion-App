using System;
using SQLite;

namespace TwilightImperiumMasterCompanion.Core
{
	public sealed class DatabaseConnection
	{
		private static DatabaseConnection instance = null;

		private DatabaseConnection(SQLiteConnection connection) { }

		public static DatabaseConnection GetInstance(SQLiteConnection connection)
		{
			if (instance != null)
			{
				throw new InvalidOperationException("Singleton already created - use getinstance()");
			}
			instance = new DatabaseConnection(connection);
			return instance;
		}

		public static DatabaseConnection GetInstance()
		{
			if (instance == null)
				throw new InvalidOperationException("Singleton not created - use GetInstance(arg1, arg2)");
			return instance;
		}

		public static DatabaseConnection Instance
		{
			get
			{
				return instance;
			}
		}
	}
}
