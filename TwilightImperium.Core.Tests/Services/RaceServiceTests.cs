using System.Collections.Generic;
using MvvmCross.Platform;
using MvvmCross.Test.Core;
using NUnit.Framework;
using SQLite.Net;
using TwilightImperiumMasterCompanion.Core;
using TwilightImperiumMasterCompanion.Core.DataAccess;
using TwilightImperiumMasterCompanion.Core.DataAccess.Interfaces;
using TwilightImperiumMasterCompanion.Core.Enum;
using TwilightImperiumMasterCompanion.Core.Services.Interfaces;

namespace TwilightImperium.Core.Tests.Services
{
    [TestFixture]
    public class RaceServiceTests : MvxIoCSupportingTest
    {
        private IRaceService raceService;
        private ISessionService sessionService;
        private SQLiteConnection databaseConnection;

        [SetUp]
        public void Init()
        {
            base.ClearAll();

            Ioc.RegisterSingleton<ISQLite>(new CoreSqliteService());
            Ioc.RegisterType<IRaceService, RaceService>();
            Ioc.RegisterType<ISessionService, SessionService>();
            Ioc.RegisterType<IRaceDataAccess, RaceDataAccess>();
            Ioc.RegisterType<ISessionDataAccess, SessionDataAccess>();
            databaseConnection = Mvx.Resolve<ISQLite>().GetConnection();
            databaseConnection.BeginTransaction();
            raceService = Mvx.Resolve<IRaceService>();
            sessionService = Mvx.Resolve<ISessionService>();
        }

        [TearDown]
        public void TearDown()
        {
            databaseConnection.Rollback();
        }

        [Test]
        public void GetRaces_WhenExpansionsSetToFalse_ReturnsDefaultSetOfRaces()
        {
            //Act
            var races = raceService.GetRaces();
            //Assert
            Assert.AreEqual(10, races.Count);
        }

        [Test]
        public void GetRaces_WhenShatteredEmpireExpansionTrueAndOtherToToFalse_ReturnsCorrectSetOfRaces()
        {
            //Arrange
            sessionService.SaveExpansion(Expansion.ShatteredEmpire, true);
            //Act
            var races = raceService.GetRaces();
            //Assert
            Assert.AreEqual(14, races.Count);
        }

        [Test]
        public void GetRaces_WhenShardsOfTheThroneExpansionTrueAndOtherToToFalse_ReturnsCorrectSetOfRaces()
        {
            //Arrange
            sessionService.SaveExpansion(Expansion.ShardsOfTheThrone, true);
            //Act
            var races = raceService.GetRaces();
            //Assert
            Assert.AreEqual(13, races.Count);
        }

        [Test]
        public void GetRaces_WhenAllExpansionsTrue_ReturnsCorrectSetOfRaces()
        {
            //Arrange
            sessionService.SaveExpansion(Expansion.ShatteredEmpire, true);
            sessionService.SaveExpansion(Expansion.ShardsOfTheThrone, true);
            //Act
            var races = raceService.GetRaces();
            //Assert
            Assert.AreEqual(17, races.Count);
        }

		[Test]
		public void GetRace_ForExistingRace_ReturnsRace()
		{
			//Arrange
			var race = raceService.GetRace("Barony of Letnev");
			//Assert
            Assert.IsNotNull(race);
		}

		[Test]
		public void GetRace_ForNonExistingRace_ReturnsNull()
		{
			//Act
			var race = raceService.GetRace("This is not a race");
			//Assert
            Assert.IsNull(race);
		}

        [Test]
        public void GetRaceStartingPlanets_ForBaronyofLetnev_ReturnsCorrectSetOfPlanets()
		{
            //Arrange
            var race = raceService.GetRace("Barony of Letnev");
			//Act
			var planets = raceService.GetStartingPlanets(race);
            //Assert
            var result = planets.FindAll(x => x.Name == "Wren Terra" || x.Name == "Arc Prime");
            Assert.AreEqual(2, result.Count);
		}

        [Test]
        public void GetRaceStartingPlanets_ForEmiratesOfHacan_ReturnsCorrectSetOfPlanets()
		{
			//Arrange
			var race = raceService.GetRace("Emirates of Hacan");
			//Act
			var planets = raceService.GetStartingPlanets(race);
			//Assert
            var result = planets.FindAll(x => x.Name == "Arretze" || x.Name == "Hercant" || x.Name == "Kamdorn");
			Assert.AreEqual(3, result.Count);
		}

        [Test]
        public void GetRaceStartingPlanets_ForFederationOfSol_ReturnsCorrectSetOfPlanets()
		{
			//Arrange
			var race = raceService.GetRace("Federation of Sol");
			//Act
			var planets = raceService.GetStartingPlanets(race);
			//Assert
			var result = planets.FindAll(x => x.Name == "Jord");
			Assert.AreEqual(1, result.Count);
		}

		[Test]
		public void GetRaceStartingPlanets_ForL1z1xMindnet_ReturnsCorrectSetOfPlanets()
		{
			//Arrange
			var race = raceService.GetRace("L1z1x Mindnet");
			//Act
			var planets = raceService.GetStartingPlanets(race);
			//Assert
			var result = planets.FindAll(x => x.Name == "[0.0.0]");
			Assert.AreEqual(1, result.Count);
		}

		[Test]
		public void GetRaceStartingPlanets_ForMentakCoalition_ReturnsCorrectSetOfPlanets()
		{
			//Arrange
			var race = raceService.GetRace("Mentak Coalition");
			//Act
			var planets = raceService.GetStartingPlanets(race);
			//Assert
			var result = planets.FindAll(x => x.Name == "Moll Primus");
			Assert.AreEqual(1, result.Count);
		}

		[Test]
		public void GetRaceStartingPlanets_ForNaaluCollective_ReturnsCorrectSetOfPlanets()
		{
			//Arrange
			var race = raceService.GetRace("Naalu Collective");
			//Act
			var planets = raceService.GetStartingPlanets(race);
			//Assert
            var result = planets.FindAll(x => x.Name == "Maaluuk" || x.Name == "Druaa");
			Assert.AreEqual(2, result.Count);
		}

		[Test]
		public void GetRaceStartingPlanets_ForSardakkNorr_ReturnsCorrectSetOfPlanets()
		{
			//Arrange
			var race = raceService.GetRace("Sardakk N’orr");
			//Act
			var planets = raceService.GetStartingPlanets(race);
			//Assert
			var result = planets.FindAll(x => x.Name == "Tren’lak" || x.Name == "Quinarra");
			Assert.AreEqual(2, result.Count);
		}

        [Test]
        public void GetRaceStartingPlanets_ForUniversitiesOfJolNar_ReturnsCorrectSetOfPlanets()
		{
			//Arrange
			var race = raceService.GetRace("Universities of Jol-Nar");
			//Act
			var planets = raceService.GetStartingPlanets(race);
			//Assert
			var result = planets.FindAll(x => x.Name == "Jol" || x.Name == "Nar");
			Assert.AreEqual(2, result.Count);
		}

		[Test]
		public void GetRaceStartingPlanets_ForXxchaKingdom_ReturnsCorrectSetOfPlanets()
		{
			//Arrange
			var race = raceService.GetRace("Xxcha Kingdom");
			//Act
			var planets = raceService.GetStartingPlanets(race);
			//Assert
			var result = planets.FindAll(x => x.Name == "Archon Ren" || x.Name == "Archon Tau");
			Assert.AreEqual(2, result.Count);
		}

		[Test]
		public void GetRaceStartingPlanets_ForYssarilTribes_ReturnsCorrectSetOfPlanets()
		{
			//Arrange
			var race = raceService.GetRace("Yssaril Tribes");
			//Act
			var planets = raceService.GetStartingPlanets(race);
			//Assert
			var result = planets.FindAll(x => x.Name == "Retillion" || x.Name == "Shalloq");
			Assert.AreEqual(2, result.Count);
		}

        [Test]
        public void GetRaceStartingPlanets_ForClanOfSaar_ReturnsCorrectSetOfPlanets()
		{
			//Arrange
			var race = raceService.GetRace("Clan of Saar");
			//Act
			var planets = raceService.GetStartingPlanets(race);
			//Assert
			var result = planets.FindAll(x => x.Name == "Lisis II" || x.Name == "Ragh");
			Assert.AreEqual(2, result.Count);
		}

        [Test]
        public void GetRaceStartingPlanets_ForEmbersOfMuaat_ReturnsCorrectSetOfPlanets()
		{
			//Arrange
			var race = raceService.GetRace("Embers of Muaat");
			//Act
			var planets = raceService.GetStartingPlanets(race);
			//Assert
			var result = planets.FindAll(x => x.Name == "Muaat");
			Assert.AreEqual(1, result.Count);
		}

		[Test]
		public void GetRaceStartingPlanets_ForWinnu_ReturnsCorrectSetOfPlanets()
		{
			//Arrange
			var race = raceService.GetRace("Winnu");
			//Act
			var planets = raceService.GetStartingPlanets(race);
			//Assert
			var result = planets.FindAll(x => x.Name == "Winnu");
			Assert.AreEqual(1, result.Count);
		}

		[Test]
		public void GetRaceStartingPlanets_ForYinBrotherhood_ReturnsCorrectSetOfPlanets()
		{
			//Arrange
			var race = raceService.GetRace("Yin Brotherhood");
			//Act
			var planets = raceService.GetStartingPlanets(race);
			//Assert
			var result = planets.FindAll(x => x.Name == "Darien");
			Assert.AreEqual(1, result.Count);
		}

		[Test]
		public void GetRaceStartingPlanets_ForArborec_ReturnsCorrectSetOfPlanets()
		{
			//Arrange
			var race = raceService.GetRace("Arborec");
			//Act
			var planets = raceService.GetStartingPlanets(race);
			//Assert
			var result = planets.FindAll(x => x.Name == "Nestphar");
			Assert.AreEqual(1, result.Count);
		}

        [Test]
        public void GetRaceStartingPlanets_ForGhostsOfCreuss_ReturnsCorrectSetOfPlanets()
		{
			//Arrange
			var race = raceService.GetRace("Ghosts of Creuss");
			//Act
			var planets = raceService.GetStartingPlanets(race);
			//Assert
			var result = planets.FindAll(x => x.Name == "Creuss");
			Assert.AreEqual(1, result.Count);
		}

		[Test]
		public void GetRaceStartingPlanets_ForNekroVirus_ReturnsCorrectSetOfPlanets()
		{
			//Arrange
			var race = raceService.GetRace("Nekro Virus");
			//Act
			var planets = raceService.GetStartingPlanets(race);
			//Assert
			var result = planets.FindAll(x => x.Name == "Mordai II");
			Assert.AreEqual(1, result.Count);
		}
	}
}

