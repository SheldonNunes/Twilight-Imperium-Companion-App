using System;
using System.IO;
using SQLite.Net;
using TwilightImperiumMasterCompanion.Core;

namespace TwilightImperium.Core.Tests.Services
{
    public class CoreSqliteService : ISQLite
    {
        private SQLiteConnection connection;

		public SQLiteConnection GetConnection()
		{
            if (connection != null)
                return connection;
            
			var sqliteFilename = "AppDatabase.db";
			string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
			string libraryPath = Path.Combine(documentsPath, "Twilight-Imperium-Master-Companion/TwilightImperiumMasterCompanion.Core/Resources"); // Library folder
			var path = Path.Combine(libraryPath, sqliteFilename);

            var plat = new SQLite.Net.Platform.Generic.SQLitePlatformGeneric();
            connection = new SQLite.Net.SQLiteConnection(plat, path);
            //// Return the database connection 
            return connection;
		}
    }
}
