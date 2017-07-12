using System.Collections.Generic;
using MvvmCross.Platform;
using MvvmCross.Test.Core;
using NUnit.Framework;
using SQLite.Net;
using TwilightImperium.Core.Tests.Services;
using TwilightImperiumMasterCompanion.Core;
namespace TwilightImperium.Core.Tests.Database
{
	[TestFixture]
	public class RaceLeaderTableTests : MvxIoCSupportingTest
	{
		private SQLiteConnection databaseConnection;
		private List<SQLiteConnection.ColumnInfo> raceLeaderColumnInfo;

		[SetUp]
		public void Init()
		{
			base.ClearAll();
			Ioc.RegisterSingleton<ISQLite>(new CoreSqliteService());
			databaseConnection = Mvx.Resolve<ISQLite>().GetConnection();

            raceLeaderColumnInfo = databaseConnection.GetTableInfo("RaceLeader");
		}

		[Test]
		public void RaceLeader_Has_RaceLeaderIDColumn()
		{
			//Act
			var result = raceLeaderColumnInfo.Find(x => x.Name == "RaceLeaderID");
			//Assert
			Assert.IsNotNull(result);
		}

		[Test]
		public void RaceLeader_Has_RaceIDColumn()
		{
			//Act
			var result = raceLeaderColumnInfo.Find(x => x.Name == "RaceID");
			//Assert
			Assert.IsNotNull(result);
		}

		[Test]
		public void RaceLeader_Has_LeaderIDColumn()
		{
			//Act
			var result = raceLeaderColumnInfo.Find(x => x.Name == "LeaderID");
			//Assert
			Assert.IsNotNull(result);
		}

		[Test]
		public void RaceLeader_Has_OnlyThreeColumns()
		{
			//Act
			var result = raceLeaderColumnInfo;
			//Assert
			Assert.AreEqual(3, result.Count);
		}
	}
}
