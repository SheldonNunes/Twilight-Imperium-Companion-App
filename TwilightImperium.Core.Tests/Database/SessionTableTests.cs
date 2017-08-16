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
    public class SessionTableTests : MvxIoCSupportingTest
    {
        private SQLiteConnection databaseConnection;
        private List<SQLiteConnection.ColumnInfo> sessionTableInfo;

        [SetUp]
        public void init()
        {
            base.ClearAll();
            Ioc.RegisterSingleton<ISQLite>(new TestSqliteService());
            databaseConnection = Mvx.Resolve<ISQLite>().GetConnection();
            sessionTableInfo = databaseConnection.GetTableInfo("Session");
        }

        [Test]
        public void SessionTable_Has_SessionIDColumn()
        {
			//Act
			var result = sessionTableInfo.Find(x => x.Name == "SessionID");
			//Assert
			Assert.IsNotNull(result);
        }

		[Test]
		public void SessionTable_Has_RaceIDColumn()
		{
			//Act
			var result = sessionTableInfo.Find(x => x.Name == "RaceID");
			//Assert
			Assert.IsNotNull(result);
		}

		[Test]
		public void SessionTable_Has_ShatteredEmpireExpansionEnabledColumn()
		{
			//Act
			var result = sessionTableInfo.Find(x => x.Name == "ShatteredEmpireExpansionEnabled");
			//Assert
			Assert.IsNotNull(result);
		}

        [Test]
        public void SessionTable_Has_ShardsOfTheThroneExpansionEnabledColumn()
		{
			//Act
			var result = sessionTableInfo.Find(x => x.Name == "ShardsOfTheThroneExpansionEnabled");
			//Assert
			Assert.IsNotNull(result);
		}

		[Test]
		public void SessionTable_InitiallyHasOneEntry()
		{
			//Act
            var result = databaseConnection.Query<Session>("SELECT * FROM Session");
			//Assert
            Assert.AreEqual(1, result.Count);
		}

		[Test]
		public void SessionTable_Has_OnlyFourColumns()
		{
			//Act
            var result = sessionTableInfo;
			//Assert
			Assert.AreEqual(4, result.Count);
		}
    }

}
