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
    public class RaceServiceLeadersTests : MvxIoCSupportingTest
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
        public void EachRaceOnlyHasThreeLeadersEach()
        {
            //Arrange
            var races = raceService.GetRaces();

            foreach (var race in races)
            {
                var leaders = raceService.GetLeaders(race);
                Assert.AreEqual(3, leaders.Count);
            }
        }

		[Test]
		public void GetRaceLeaders_ForBaronyofLetnev_HasAdmiralCalledUnlenn()
		{
			//Arrange
			var race = raceService.GetRace("Barony of Letnev");
			//Act
			var leaders = raceService.GetLeaders(race);
			//Assert
            var result = leaders.FindAll(x => x.LeaderType == "Admiral" && x.Name == "Unlenn");
			Assert.AreEqual(1, result.Count);
		}

		[Test]
		public void GetRaceLeaders_ForBaronyofLetnev_HasGeneralCalledFarran()
		{
			//Arrange
			var race = raceService.GetRace("Barony of Letnev");
			//Act
			var leaders = raceService.GetLeaders(race);
			//Assert
            var result = leaders.FindAll(x => x.LeaderType == "General" && x.Name == "Farran");
			Assert.AreEqual(1, result.Count);
		}

		[Test]
		public void GetRaceLeaders_ForBaronyofLetnev_HasDiplomatCalledCiel()
		{
			//Arrange
			var race = raceService.GetRace("Barony of Letnev");
			//Act
			var leaders = raceService.GetLeaders(race);
			//Assert
            var result = leaders.FindAll(x => x.LeaderType == "Diplomat" && x.Name == "Ciel");
			Assert.AreEqual(1, result.Count);
		}

		[Test]
		public void GetRaceLeaders_ForEmiratesOfHacan_HasAdmiralCalledUnlenn()
		{
			//Arrange
			var race = raceService.GetRace("Emirates of Hacan");
			//Act
			var leaders = raceService.GetLeaders(race);
			//Assert
			var result = leaders.FindAll(x => x.LeaderType == "Admiral" && x.Name == "Unlenn");
			Assert.AreEqual(1, result.Count);
		}

		[Test]
		public void GetRaceLeaders_ForEmiratesOfHacan_HasGeneralCalledFarran()
		{
			//Arrange
			var race = raceService.GetRace("Emirates of Hacan");
			//Act
			var leaders = raceService.GetLeaders(race);
			//Assert
			var result = leaders.FindAll(x => x.LeaderType == "General" && x.Name == "Farran");
			Assert.AreEqual(1, result.Count);
		}

		[Test]
		public void GetRaceLeaders_ForEmiratesOfHacan_HasDiplomatCalledCiel()
		{
			//Arrange
			var race = raceService.GetRace("Emirates of Hacan");
			//Act
			var leaders = raceService.GetLeaders(race);
			//Assert
			var result = leaders.FindAll(x => x.LeaderType == "Diplomat" && x.Name == "Ciel");
			Assert.AreEqual(1, result.Count);
		}


//		[Test]
//		public void GetRaceLeaders_ForEmiratesOfHacan_ReturnsCorrectSetOfRepresentatives()
//		{
//			//Arrange
//			var race = raceService.GetRace("Emirates of Hacan");
//			//Act
//			var leaders = raceService.GetLeaders(race);
//			//Assert
//			var result = leaders.FindAll(x => x.Title == "Arretze" || x.Title == "Hercant" || x.Title == "Kamdorn");
//			Assert.AreEqual(3, result.Count);
//		}

//		[Test]
//		public void GetRaceLeaders_ForFederationOfSol_ReturnsCorrectSetOfRepresentatives()
//		{
//			//Arrange
//			var race = raceService.GetRace("Federation of Sol");
//			//Act
//			var leaders = raceService.GetLeaders(race);
//			//Assert
//			var result = leaders.FindAll(x => x.Title == "Jord");
//			Assert.AreEqual(1, result.Count);
//		}

//		[Test]
//		public void GetRaceLeaders_ForL1z1xMindnet_ReturnsCorrectSetOfRepresentatives()
//		{
//			//Arrange
//			var race = raceService.GetRace("L1z1x Mindnet");
//			//Act
//			var leaders = raceService.GetLeaders(race);
//			//Assert
//			var result = leaders.FindAll(x => x.Title == "[0.0.0]");
//			Assert.AreEqual(1, result.Count);
//		}

//		[Test]
//		public void GetRaceLeaders_ForMentakCoalition_ReturnsCorrectSetOfRepresentatives()
//		{
//			//Arrange
//			var race = raceService.GetRace("Mentak Coalition");
//			//Act
//			var leaders = raceService.GetLeaders(race);
//			//Assert
//			var result = leaders.FindAll(x => x.Title == "Moll Primus");
//			Assert.AreEqual(1, result.Count);
//		}

//		[Test]
//		public void GetRaceLeaders_ForNaaluCollective_ReturnsCorrectSetOfRepresentatives()
//		{
//			//Arrange
//			var race = raceService.GetRace("Naalu Collective");
//			//Act
//			var leaders = raceService.GetLeaders(race);
//			//Assert
//			var result = leaders.FindAll(x => x.Title == "Maaluuk" || x.Title == "Druaa");
//			Assert.AreEqual(2, result.Count);
//		}

//		[Test]
//		public void GetRaceLeaders_ForSardakkNorr_ReturnsCorrectSetOfRepresentatives()
//		{
//			//Arrange
//			var race = raceService.GetRace("Sardakk N’orr");
//			//Act
//			var leaders = raceService.GetLeaders(race);
//			//Assert
//			var result = leaders.FindAll(x => x.Title == "Tren’lak" || x.Title == "Quinarra");
//			Assert.AreEqual(2, result.Count);
//		}

//		[Test]
//		public void GetRaceLeaders_ForUniversitiesOfJolNar_ReturnsCorrectSetOfRepresentatives()
//		{
//			//Arrange
//			var race = raceService.GetRace("Universities of Jol-Nar");
//			//Act
//			var leaders = raceService.GetLeaders(race);
//			//Assert
//			var result = leaders.FindAll(x => x.Title == "Jol" || x.Title == "Nar");
//			Assert.AreEqual(2, result.Count);
//		}

//		[Test]
//		public void GetRaceLeaders_ForXxchaKingdom_ReturnsCorrectSetOfRepresentatives()
//		{
//			//Arrange
//			var race = raceService.GetRace("Xxcha Kingdom");
//			//Act
//			var leaders = raceService.GetLeaders(race);
//			//Assert
//			var result = leaders.FindAll(x => x.Title == "Archon Ren" || x.Title == "Archon Tau");
//			Assert.AreEqual(2, result.Count);
//		}

//		[Test]
//		public void GetRaceLeaders_ForYssarilTribes_ReturnsCorrectSetOfRepresentatives()
//		{
//			//Arrange
//			var race = raceService.GetRace("Yssaril Tribes");
//			//Act
//			var leaders = raceService.GetLeaders(race);
//			//Assert
//			var result = leaders.FindAll(x => x.Title == "Retillion" || x.Title == "Shalloq");
//			Assert.AreEqual(2, result.Count);
//		}

//		[Test]
//		public void GetRaceLeaders_ForClanOfSaar_ReturnsCorrectSetOfRepresentatives()
//		{
//			//Arrange
//			var race = raceService.GetRace("Clan of Saar");
//			//Act
//			var leaders = raceService.GetLeaders(race);
//			//Assert
//			var result = leaders.FindAll(x => x.Title == "Lisis II" || x.Title == "Ragh");
//			Assert.AreEqual(2, result.Count);
//		}

//		[Test]
//		public void GetRaceLeaders_ForEmbersOfMuaat_ReturnsCorrectSetOfRepresentatives()
//		{
//			//Arrange
//			var race = raceService.GetRace("Embers of Muaat");
//			//Act
//			var leaders = raceService.GetLeaders(race);
//			//Assert
//			var result = leaders.FindAll(x => x.Title == "Muaat");
//			Assert.AreEqual(1, result.Count);
//		}

//		[Test]
//		public void GetRaceLeaders_ForWinnu_ReturnsCorrectSetOfRepresentatives()
//		{
//			//Arrange
//			var race = raceService.GetRace("Winnu");
//			//Act
//			var leaders = raceService.GetLeaders(race);
//			//Assert
//			var result = leaders.FindAll(x => x.Title == "Winnu");
//			Assert.AreEqual(1, result.Count);
//		}

//		[Test]
//		public void GetRaceLeaders_ForYinBrotherhood_ReturnsCorrectSetOfRepresentatives()
//		{
//			//Arrange
//			var race = raceService.GetRace("Yin Brotherhood");
//			//Act
//			var leaders = raceService.GetLeaders(race);
//			//Assert
//			var result = leaders.FindAll(x => x.Title == "Darien");
//			Assert.AreEqual(1, result.Count);
//		}

//		[Test]
//		public void GetRaceLeaders_ForArborec_ReturnsCorrectSetOfRepresentatives()
//		{
//			//Arrange
//			var race = raceService.GetRace("Arborec");
//			//Act
//			var leaders = raceService.GetLeaders(race);
//			//Assert
//			var result = leaders.FindAll(x => x.Title == "Nestphar");
//			Assert.AreEqual(1, result.Count);
//		}

//		[Test]
//		public void GetRaceLeaders_ForGhostsOfCreuss_ReturnsCorrectSetOfRepresentatives()
//		{
//			//Arrange
//			var race = raceService.GetRace("Ghosts of Creuss");
//			//Act
//			var leaders = raceService.GetLeaders(race);
//			//Assert
//			var result = leaders.FindAll(x => x.Title == "Creuss");
//			Assert.AreEqual(1, result.Count);
//		}

//		[Test]
//		public void GetRaceLeaders_ForNekroVirus_ReturnsCorrectSetOfRepresentatives()
//		{
//			//Arrange
//			var race = raceService.GetRace("Nekro Virus");
//			//Act
//			var leaders = raceService.GetLeaders(race);
//			//Assert
//			var result = leaders.FindAll(x => x.Title == "Mordai II");
//			Assert.AreEqual(1, result.Count);
//		}   
    }
}