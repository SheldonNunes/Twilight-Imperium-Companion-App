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
	public class RaceStartingPlanetsTableTests : MvxIoCSupportingTest
	{
		private SQLiteConnection databaseConnection;
        private List<SQLiteConnection.ColumnInfo> raceStartingPlanetsTableInfo;

		[SetUp]
		public void Init()
		{
			base.ClearAll();
			Ioc.RegisterSingleton<ISQLite>(new CoreSqliteService());
			databaseConnection = Mvx.Resolve<ISQLite>().GetConnection();

			raceStartingPlanetsTableInfo = databaseConnection.GetTableInfo("RaceStartingPlanets");
		}

		[Test]
		public void RaceStartingPlanets_Has_IDColumn()
		{
			//Act
			var result = raceStartingPlanetsTableInfo.Find(x => x.Name == "ID");
			//Assert
			Assert.IsNotNull(result);
		}

		[Test]
		public void RaceStartingPlanets_Has_RaceIDColumn()
		{
			//Act
			var result = raceStartingPlanetsTableInfo.Find(x => x.Name == "RaceID");
			//Assert
			Assert.IsNotNull(result);
		}

		[Test]
		public void RaceStartingPlanets_Has_PlanetIDColumn()
		{
			//Act
			var result = raceStartingPlanetsTableInfo.Find(x => x.Name == "PlanetID");
			//Assert
			Assert.IsNotNull(result);
		}

		[Test]
		public void RaceStartingPlanets_Has_OnlyThreeColumns()
		{
			//Act
			var result = raceStartingPlanetsTableInfo;
			//Assert
			Assert.AreEqual(3, result.Count);
		}
	}
}
