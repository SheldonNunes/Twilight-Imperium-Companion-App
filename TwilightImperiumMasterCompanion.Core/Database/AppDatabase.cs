using SQLite;

namespace TwilightImperiumMasterCompanion.Core
{
	public class AppDatabase
	{
		public AppDatabase(string databasePath)
		{
			var db = new SQLiteConnection(databasePath);
			//db.CreateTable<
		}
	}
}
