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
    public class PlanetServiceTests : MvxIoCSupportingTest
    {
        private SQLiteConnection databaseConnection;
        private IPlanetService planetService;
        private ISessionService sessionService;

        [SetUp]
		public void Init()
		{
			base.ClearAll();
			var sqLite = new TestSqliteService();
			Ioc.RegisterSingleton<ISQLite>(sqLite);
			Ioc.RegisterType<ISessionService, SessionService>();
			Ioc.RegisterType<ISessionDataAccess, SessionDataAccess>();
            Ioc.RegisterType<IPlanetDataAccess, PlanetDataAccess>();
            Ioc.RegisterType<IPlanetService, PlanetService>();
            Ioc.RegisterType<IRaceDataAccess, RaceDataAccess>();
            Ioc.RegisterType<IScriptRepository, ScriptRepository>();

			databaseConnection = Mvx.Resolve<ISQLite>().GetConnection();

			var plat = new SQLite.Net.Platform.Generic.SQLitePlatformGeneric();
			databaseConnection.BeginTransaction();
            planetService = Mvx.Resolve<IPlanetService>();
            sessionService = Mvx.Resolve<ISessionService>();
		}

		[TearDown]
		public void TearDown()
		{
			databaseConnection.Rollback();
		}

		[Test]
		public void GetPlanets_WhenNoExpansions_ReturnsCorrectNumberOfPlanets()
		{
			//Assert
            var result = planetService.GetPlanets();
			Assert.AreEqual(52, result.Count);
		}

		[Test]
		public void GetPlanets_WhenShatteredEmpiresExpansionEnabled_ReturnsCorrectNumberOfPlanets()
		{
			//Arrange
			sessionService.SaveExpansion(Expansion.ShatteredEmpire, true);
			//Act
			var result = planetService.GetPlanets();
			//Assert
			Assert.AreEqual(80, result.Count);
		}

        [Test]
        public void GetPlanets_WhenShardsOfTheThroneExpansionEnabled_ReturnsCorrectNumberOfPlanets()
		{
			//Arrange
            sessionService.SaveExpansion(Expansion.ShardsOfTheThrone, true);
			//Act
			var result = planetService.GetPlanets();
			//Assert
			Assert.AreEqual(63, result.Count);
		}

		[Test]
		public void GetPlanets_WhenAllExpansionsEnabled_ReturnsCorrectNumberOfPlanets()
		{
			//Arrange
			sessionService.SaveExpansion(Expansion.ShatteredEmpire, true);
            sessionService.SaveExpansion(Expansion.ShardsOfTheThrone, true);
			//Act
			var result = planetService.GetPlanets();
			//Assert
			Assert.AreEqual(91, result.Count);
		}
    }
}
