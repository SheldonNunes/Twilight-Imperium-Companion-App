using System;
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
	public class RaceTableTests : MvxIoCSupportingTest
	{
		private SQLiteConnection databaseConnection;
        private List<SQLiteConnection.ColumnInfo> raceTableInfo;

		[SetUp]
		public void Init()
		{
			base.ClearAll();
            Ioc.RegisterSingleton<ISQLite>(new CoreSqliteService());
			databaseConnection = Mvx.Resolve<ISQLite>().GetConnection();

            raceTableInfo = databaseConnection.GetTableInfo("Race");
		}

		[Test]
		public void RaceTable_Has_IDColumn()
		{
			//Act
			var result = raceTableInfo.Find(x => x.Name == "ID");
			//Assert
			Assert.IsNotNull(result);
		}

		[Test]
		public void RaceTable_Has_Race_NameColumn()
		{
			//Act
            var result = raceTableInfo.Find(x => x.Name == "Name");
            //Assert
            Assert.IsNotNull(result);
		}

		[Test]
		public void RaceTable_Has_ExpansionColumn()
		{
			//Act
			var result = raceTableInfo.Find(x => x.Name == "Expansion");
			//Assert
			Assert.IsNotNull(result);
		}

		[Test]
		public void RaceTable_Has_OnlyThreeColumns()
		{
			//Act
			var result = raceTableInfo;
			//Assert
            Assert.AreEqual(3, result.Count);
		}
	}
}
