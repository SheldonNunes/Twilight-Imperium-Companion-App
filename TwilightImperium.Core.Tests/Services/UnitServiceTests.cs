using System;
using MvvmCross.Platform;
using MvvmCross.Test.Core;
using NUnit.Framework;
using SQLite.Net;
using TwilightImperiumMasterCompanion.Core;
using TwilightImperiumMasterCompanion.Core.DataAccess;
using TwilightImperiumMasterCompanion.Core.DataAccess.Interfaces;
using TwilightImperiumMasterCompanion.Core.DataAccess.Scripts;
using TwilightImperiumMasterCompanion.Core.Enum;
using TwilightImperiumMasterCompanion.Core.Services;
using TwilightImperiumMasterCompanion.Core.Services.Interfaces;

namespace TwilightImperium.Core.Tests.Services
{
	[TestFixture]
	public class UnitServiceTests : MvxIoCSupportingTest
	{
        private IUnitService unitService;
		private SQLiteConnection databaseConnection;
        private ISessionService sessionService;

        [SetUp]
		public void Init()
		{
			base.ClearAll();
			var sqLite = new TestSqliteService();

			Ioc.RegisterSingleton<ISQLite>(sqLite);
			Ioc.RegisterType<ISessionService, SessionService>();
			Ioc.RegisterType<ISessionDataAccess, SessionDataAccess>();
            Ioc.RegisterType<IUnitDataAccess, UnitDataAccess>();
            Ioc.RegisterType<IRaceDataAccess, RaceDataAccess>();
            Ioc.RegisterType<IUnitService, UnitService>();
			Ioc.RegisterType<IScriptRepository, ScriptRepository>();

			databaseConnection = Mvx.Resolve<ISQLite>().GetConnection();

			var plat = new SQLite.Net.Platform.Generic.SQLitePlatformGeneric();
			databaseConnection.BeginTransaction();
            unitService = Mvx.Resolve<IUnitService>();
			sessionService = Mvx.Resolve<ISessionService>();

		}

		[TearDown]
		public void TearDown()
		{
			databaseConnection.Rollback();
		}

		[Test]
		public void GetUnits_WhenNoExpansions_CorrectNumberOfShips()
		{
			//Assert
            var result = unitService.GetUnits();
            Assert.AreEqual(9, result.Count);
		}

		[Test]
		public void GetUnits_WhenAllExpansions_CorrectNumberOfShips()
		{
			//Assert
            sessionService.SaveExpansion(Expansion.ShatteredEmpire, true);
            sessionService.SaveExpansion(Expansion.ShardsOfTheThrone, true);

			var result = unitService.GetUnits();
			Assert.AreEqual(10, result.Count);
		}
    }
}
