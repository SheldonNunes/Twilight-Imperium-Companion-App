using MvvmCross.Platform;
using MvvmCross.Test.Core;
using NUnit.Framework;
using SQLite.Net;
using TwilightImperiumMasterCompanion.Core;
using TwilightImperiumMasterCompanion.Core.DataAccess;
using TwilightImperiumMasterCompanion.Core.DataAccess.Interfaces;
using TwilightImperiumMasterCompanion.Core.DataAccess.Scripts;
using TwilightImperiumMasterCompanion.Core.Services.Interfaces;

namespace TwilightImperium.Core.Tests.Services
{
    [TestFixture]
	public class RaceServiceStartingPlanetTests : MvxIoCSupportingTest
	{
		private IRaceService raceService;
		private ISessionService sessionService;
		private SQLiteConnection databaseConnection;

		[SetUp]
		public void Init()
		{
			base.ClearAll();

			Ioc.RegisterSingleton<ISQLite>(new TestSqliteService());
			Ioc.RegisterType<IRaceService, RaceService>();
			Ioc.RegisterType<ISessionService, SessionService>();
			Ioc.RegisterType<IRaceDataAccess, RaceDataAccess>();
			Ioc.RegisterType<ISessionDataAccess, SessionDataAccess>();
			Ioc.RegisterType<IScriptRepository, ScriptRepository>();

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
        public void GetRaceStartingPlanets_ForBaronyofLetnev_ReturnsCorrectSetOfPlanets()
        {
            //Arrange
            var race = raceService.GetRace("Barony of Letnev");
            //Act
            var planets = raceService.GetStartingPlanets(race);
            //Assert
            var result = planets.FindAll(x => x.Title == "Wren Terra" || x.Title == "Arc Prime");
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
            var result = planets.FindAll(x => x.Title == "Arretze" || x.Title == "Hercant" || x.Title == "Kamdorn");
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
            var result = planets.FindAll(x => x.Title == "Jord");
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
            var result = planets.FindAll(x => x.Title == "[0.0.0]");
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
            var result = planets.FindAll(x => x.Title == "Moll Primus");
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
            var result = planets.FindAll(x => x.Title == "Maaluuk" || x.Title == "Druaa");
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
            var result = planets.FindAll(x => x.Title == "Tren’lak" || x.Title == "Quinarra");
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
            var result = planets.FindAll(x => x.Title == "Jol" || x.Title == "Nar");
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
            var result = planets.FindAll(x => x.Title == "Archon Ren" || x.Title == "Archon Tau");
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
            var result = planets.FindAll(x => x.Title == "Retillion" || x.Title == "Shalloq");
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
            var result = planets.FindAll(x => x.Title == "Lisis II" || x.Title == "Ragh");
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
            var result = planets.FindAll(x => x.Title == "Muaat");
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
            var result = planets.FindAll(x => x.Title == "Winnu");
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
            var result = planets.FindAll(x => x.Title == "Darien");
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
            var result = planets.FindAll(x => x.Title == "Nestphar");
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
            var result = planets.FindAll(x => x.Title == "Creuss");
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
            var result = planets.FindAll(x => x.Title == "Mordai II");
            Assert.AreEqual(1, result.Count);
        }
    }
}
