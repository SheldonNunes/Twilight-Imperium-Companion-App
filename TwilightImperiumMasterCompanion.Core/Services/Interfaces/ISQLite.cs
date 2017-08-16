using System;
using SQLite.Net;

namespace TwilightImperiumMasterCompanion.Core.Services.Interfaces
{
	public interface ISQLite
	{
		SQLiteConnection GetConnection();
	}
}
