using System.Collections.Generic;
using MvvmCross.Platform;
using MvvmCross.Test.Core;
using NUnit.Framework;
using SQLite.Net;
using TwilightImperium.Core.Tests.Services;
using TwilightImperiumMasterCompanion.Core;
using TwilightImperiumMasterCompanion.Core.Model;

namespace TwilightImperium.Core.Tests.Database
{
	[TestFixture]
	public class LeaderTableTests : MvxIoCSupportingTest
	{
		private SQLiteConnection databaseConnection;
		private List<SQLiteConnection.ColumnInfo> raceLeaderTableInfo;

		[SetUp]
		public void Init()
		{
			base.ClearAll();
			Ioc.RegisterSingleton<ISQLite>(new CoreSqliteService());
			databaseConnection = Mvx.Resolve<ISQLite>().GetConnection();

			raceLeaderTableInfo = databaseConnection.GetTableInfo("Leader");
		}

		[Test]
		public void RaceLeader_Has_LeaderIDColumn()
		{
			//Act
			var result = raceLeaderTableInfo.Find(x => x.Name == "LeaderID");
			//Assert
			Assert.IsNotNull(result);
		}

		[Test]
		public void RaceLeader_Has_LeaderTypeColumn()
		{
			//Act
			var result = raceLeaderTableInfo.Find(x => x.Name == "LeaderType");
			//Assert
			Assert.IsNotNull(result);
		}

		[Test]
		public void RaceLeader_Has_OnlyTwoColumns()
		{
			//Act
            var result = raceLeaderTableInfo;
			//Assert
			Assert.AreEqual(2, result.Count);
		}

		//[Test]
		//public void RaceLeader_Has_CorrectScientistDescription()
		//{
		//	//Act
		//	var result = databaseConnection.Query<Leader>("SELECT * FROM Leader WHERE Name = 'Scientist'");
  //          var expected = ""
		//	//Assert
		//	Assert.AreEqual(4, result.Count);
		//}
	}
}
