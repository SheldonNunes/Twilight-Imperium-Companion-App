using System.Collections.Generic;
using System.Linq;
using SQLite;

namespace TwilightImperiumMasterCompanion.Core
{
	public class AppDatabase
	{
		static object locker = new object();

		public SQLiteConnection database;

		public string path;

		public AppDatabase(SQLiteConnection conn)
		{
			database = conn;
		}

		public IEnumerable<Race> GetItems()
		{
			lock (locker)
			{
				var mappings = database.TableMappings;
				return (from i in database.Table<Race>() select i).ToList();
			}
		}
		public AppDatabase(string databasePath)
		{
			var db = new SQLiteConnection(databasePath);
			//db.CreateTable<
		}
	}
}
