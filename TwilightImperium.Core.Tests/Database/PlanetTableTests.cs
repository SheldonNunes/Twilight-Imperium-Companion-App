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
	public class PlanetTableTests : MvxIoCSupportingTest
	{
		private SQLiteConnection databaseConnection;
        private List<SQLiteConnection.ColumnInfo> planetTableInfo;

		[SetUp]
		public void Init()
		{
			base.ClearAll();
			Ioc.RegisterSingleton<ISQLite>(new TestSqliteService());
			databaseConnection = Mvx.Resolve<ISQLite>().GetConnection();

			planetTableInfo = databaseConnection.GetTableInfo("Planet");
		}

		[Test]
		public void PlanetTable_Has_IDColumn()
		{
			//Act
			var result = planetTableInfo.Find(x => x.Name == "ID");
			//Assert
			Assert.IsNotNull(result);
		}

		[Test]
		public void PlanetTable_Has_NameColumn()
		{
			//Act
			var result = planetTableInfo.Find(x => x.Name == "Name");
			//Assert
			Assert.IsNotNull(result);
		}

		[Test]
		public void PlanetTable_Has_OnlyFiveColumns()
		{
			//Act
			var result = planetTableInfo;
			//Assert
			Assert.AreEqual(5, result.Count);
		}
	}
}
