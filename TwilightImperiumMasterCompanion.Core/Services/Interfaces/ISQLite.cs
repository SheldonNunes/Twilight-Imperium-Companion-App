using System;
using SQLite.Net;

namespace TwilightImperiumMasterCompanion.Core
{
	public interface ISQLite
	{
		SQLiteConnection GetConnection();
	}
}
