using System;
using System.Linq;
using MvvmCross.Platform;
using MvvmCross.Test.Core;
using NUnit.Framework;
using SQLite.Net;
using TwilightImperiumMasterCompanion.Core;
using TwilightImperiumMasterCompanion.Core.DataAccess;
using TwilightImperiumMasterCompanion.Core.DataAccess.Interfaces;
using TwilightImperiumMasterCompanion.Core.DataAccess.Scripts;
using TwilightImperiumMasterCompanion.Core.Enum;
using TwilightImperiumMasterCompanion.Core.Model;
using TwilightImperiumMasterCompanion.Core.Services.Interfaces;

namespace TwilightImperium.Core.Tests.Services
{
    [TestFixture]
    public class SessionServiceTests : MvxIoCSupportingTest
    {
        private ISessionService sessionService;
        private SQLiteConnection databaseConnection;

        [SetUp]
        public void Init()
        {
            base.ClearAll();
            var sqLite = new TestSqliteService();
            Ioc.RegisterSingleton<ISQLite>(sqLite);
            Ioc.RegisterType<ISessionService, SessionService>();
            Ioc.RegisterType<ISessionDataAccess, SessionDataAccess>();
            Ioc.RegisterType<IRaceDataAccess, RaceDataAccess>();
			Ioc.RegisterType<IScriptRepository, ScriptRepository>();

			databaseConnection = Mvx.Resolve<ISQLite>().GetConnection();

            var plat = new SQLite.Net.Platform.Generic.SQLitePlatformGeneric();
            databaseConnection.BeginTransaction();
			sessionService = Mvx.Resolve<ISessionService>();
        }

		[TearDown]
		public void TearDown()
		{
            databaseConnection.Rollback();
		}

		[Test]
		public void SetShatteredEmpireExpansion_ToFalse_SetsSessionsDatabaseEntryToFalse()
		{
			//Act
            sessionService.SaveExpansion(Expansion.ShatteredEmpire, false);

			var session = databaseConnection.Query<Session>("SELECT * FROM Session");
			//Assert
            Assert.IsNotNull(session.Find(x => x.ShatteredEmpireExpansionEnabled == false));
		}

        [Test]
        public void SetShardsOfTheThroneExpansion_ToTrue_SetsSessionsDatabaseEntryToTrue()
		{
			//Act
            sessionService.SaveExpansion(Expansion.ShardsOfTheThrone, true);

			var session = databaseConnection.Query<Session>("SELECT * FROM Session");
			//Assert
            Assert.IsNotNull(session.Find(x => x.ShardsOfTheThroneExpansionEnabled == true));
		}

		[Test]
		public void SetShardsOfTheThroneExpansion_ToFalse_SetsSessionsDatabaseEntryToFalse()
		{
			//Act
            sessionService.SaveExpansion(Expansion.ShardsOfTheThrone, false);

			var session = databaseConnection.Query<Session>("SELECT * FROM Session");
			//Assert
            Assert.IsNotNull(session.Find(x => x.ShardsOfTheThroneExpansionEnabled == false));
		}

		[Test]
		public void SetSelectedRace_SetsSelectedRaceInDatabase()
		{
            //Act
            var race = new Race() {RaceID = 3};
			sessionService.SetSelectedRace(race);

			var session = databaseConnection.Query<Session>("SELECT * FROM Session");
			//Assert
            Assert.IsNotNull(session.Find(x => x.RaceID == race.RaceID));
		}


		[Test]
		public void GetSelectedRace_WhenSelectedRaceNotSet_ThrowsException()
		{
			Assert.Throws<InvalidOperationException>(() => sessionService.GetSelectedRace());
		}

		[Test]
		public void GetSelectedRace_WhenSelectedSet_ReturnsSelectedRace()
		{
			//Arrange
            //Federation of Sol
			var race = new Race() { RaceID = 3 };
			sessionService.SetSelectedRace(race);

            //Act
            var result = sessionService.GetSelectedRace();
            //Assert
            Assert.AreEqual(race.RaceID, result.RaceID);
		}

		[Test]
		public void SavePlanet_SavesPlanetInSessionTable()
		{
            //Arrange
            var planet = new Planet() { PlanetId = 1 };
            sessionService.SavePlanet(planet, false);

			//Act
			var result = sessionService.GetSessionPlanets();
			//Assert
			Assert.AreEqual(1, result.First().PlanetId);
		}

		[Test]
		public void SavePlanets_SavesPlanetsInSessionTable()
		{
			//Arrange
			var planet = new Planet() { PlanetId = 1 };
			sessionService.SavePlanet(planet, false);

			var planetTwo = new Planet() { PlanetId = 2 };
			sessionService.SavePlanet(planetTwo, false);

			var planetThree = new Planet() { PlanetId = 3 };
			sessionService.SavePlanet(planetThree, false);

			//Act
			var result = sessionService.GetSessionPlanets();
			//Assert
            Assert.AreEqual(3, result.Count);
		}
    }
}
