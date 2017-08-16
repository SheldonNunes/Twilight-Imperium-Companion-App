using MvvmCross.Platform;
using MvvmCross.Test.Core;
using NUnit.Framework;
using SQLite.Net;
using TwilightImperiumMasterCompanion.Core;
using TwilightImperiumMasterCompanion.Core.DataAccess;
using TwilightImperiumMasterCompanion.Core.DataAccess.Interfaces;
using TwilightImperiumMasterCompanion.Core.DataAccess.Scripts;
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

            Ioc.RegisterSingleton<ISQLite>(new TestSqliteService());
            Ioc.RegisterType<IRaceService, RaceService>();
			Ioc.RegisterType<IRaceDataAccess, RaceDataAccess>();
			Ioc.RegisterType<ISessionService, SessionService>();
            Ioc.RegisterType<ISessionDataAccess, SessionDataAccess>();
			Ioc.RegisterType<IScriptRepository, ScriptRepository>();



			databaseConnection = Mvx.Resolve<ISQLite>().GetConnection();
            databaseConnection.BeginTransaction();
			sessionService = Mvx.Resolve<ISessionService>();

			raceService = Mvx.Resolve<IRaceService>();
        }

        [TearDown]
        public void TearDown()
        {
            databaseConnection.Rollback();
        }

		[Test]
		public void GetRaceLeaders_ForBaronyofLetnev_HasAdmiral()
		{
			//Arrange
			var race = raceService.GetRace("Barony of Letnev");
			//Act
			var leaders = raceService.GetLeaders(race);
			//Assert
            var result = leaders.FindAll(x => x.LeaderType == "Admiral");
			Assert.AreEqual(1, result.Count);
		}

		[Test]
		public void GetRaceLeaders_ForBaronyofLetnev_HasGeneral()
		{
			//Arrange
			var race = raceService.GetRace("Barony of Letnev");
			//Act
			var leaders = raceService.GetLeaders(race);
			//Assert
            var result = leaders.FindAll(x => x.LeaderType == "General");
			Assert.AreEqual(1, result.Count);
		}

		[Test]
		public void GetRaceLeaders_ForBaronyofLetnev_HasDiplomat()
		{
			//Arrange
			var race = raceService.GetRace("Barony of Letnev");
			//Act
			var leaders = raceService.GetLeaders(race);
			//Assert
            var result = leaders.FindAll(x => x.LeaderType == "Diplomat");
			Assert.AreEqual(1, result.Count);
		}

		[Test]
		public void GetRaceLeaders_ForEmiratesOfHacan_HasScientist()
		{
			//Arrange
			var race = raceService.GetRace("Emirates of Hacan");
			//Act
			var leaders = raceService.GetLeaders(race);
			//Assert
			var result = leaders.FindAll(x => x.LeaderType == "Scientist");
			Assert.AreEqual(1, result.Count);
		}

		[Test]
		public void GetRaceLeaders_ForEmiratesOfHacan_HasGeneral()
		{
			//Arrange
			var race = raceService.GetRace("Emirates of Hacan");
			//Act
			var leaders = raceService.GetLeaders(race);
			//Assert
			var result = leaders.FindAll(x => x.LeaderType == "General");
			Assert.AreEqual(1, result.Count);
		}

		[Test]
		public void GetRaceLeaders_ForEmiratesOfHacan_HasDiplomat()
		{
			//Arrange
			var race = raceService.GetRace("Emirates of Hacan");
			//Act
			var leaders = raceService.GetLeaders(race);
			//Assert
			var result = leaders.FindAll(x => x.LeaderType == "Diplomat");
			Assert.AreEqual(1, result.Count);
		}

		[Test]
		public void GetRaceLeaders_ForFederationOfSol_HasDiplomat()
		{
			//Arrange
			var race = raceService.GetRace("Federation of Sol");
			//Act
			var leaders = raceService.GetLeaders(race);
			//Assert
			var result = leaders.FindAll(x => x.LeaderType == "Diplomat");
			Assert.AreEqual(1, result.Count);
		}

		[Test]
		public void GetRaceLeaders_ForFederationOfSol_HasAdmiral()
		{
			//Arrange
			var race = raceService.GetRace("Federation of Sol");
			//Act
			var leaders = raceService.GetLeaders(race);
			//Assert
			var result = leaders.FindAll(x => x.LeaderType == "Admiral");
			Assert.AreEqual(1, result.Count);
		}

		[Test]
		public void GetRaceLeaders_ForFederationOfSol_HasAgent()
		{
			//Arrange
			var race = raceService.GetRace("Federation of Sol");
			//Act
			var leaders = raceService.GetLeaders(race);
			//Assert
			var result = leaders.FindAll(x => x.LeaderType == "Agent");
			Assert.AreEqual(1, result.Count);
		}

		[Test]
		public void GetRaceLeaders_ForL1z1xMindnet_HasAgent()
		{
			//Arrange
			var race = raceService.GetRace("L1z1x Mindnet");
			//Act
			var leaders = raceService.GetLeaders(race);
			//Assert
			var result = leaders.FindAll(x => x.LeaderType == "Agent");
			Assert.AreEqual(1, result.Count);
		}

		[Test]
		public void GetRaceLeaders_ForL1z1xMindnet_HasScientist()
		{
			//Arrange
			var race = raceService.GetRace("L1z1x Mindnet");
			//Act
			var leaders = raceService.GetLeaders(race);
			//Assert
			var result = leaders.FindAll(x => x.LeaderType == "Scientist");
			Assert.AreEqual(1, result.Count);
		}

		[Test]
		public void GetRaceLeaders_ForL1z1xMindnet_HasDiplomat()
		{
			//Arrange
			var race = raceService.GetRace("L1z1x Mindnet");
			//Act
			var leaders = raceService.GetLeaders(race);
			//Assert
			var result = leaders.FindAll(x => x.LeaderType == "Diplomat");
			Assert.AreEqual(1, result.Count);
		}

		[Test]
		public void GetRaceLeaders_ForMentakCoalition_HasDiplomat()
		{
			//Arrange
			var race = raceService.GetRace("Mentak Coalition");
			//Act
			var leaders = raceService.GetLeaders(race);
			//Assert
			var result = leaders.FindAll(x => x.LeaderType == "Diplomat");
			Assert.AreEqual(1, result.Count);
		}

        [Test]
        public void GetRaceLeaders_ForMentakCoalition_HasAgent()
        {
            //Arrange
            var race = raceService.GetRace("Mentak Coalition");
            //Act
            var leaders = raceService.GetLeaders(race);
            //Assert
            var result = leaders.FindAll(x => x.LeaderType == "Agent");
            Assert.AreEqual(1, result.Count);
        }

		[Test]
		public void GetRaceLeaders_ForMentakCoalition_HasAdmiral()
		{
			//Arrange
			var race = raceService.GetRace("Mentak Coalition");
			//Act
			var leaders = raceService.GetLeaders(race);
			//Assert
			var result = leaders.FindAll(x => x.LeaderType == "Admiral");
			Assert.AreEqual(1, result.Count);
		}

		[Test]
		public void GetRaceLeaders_ForNaaluCollective_HasAdmiral()
		{
			//Arrange
			var race = raceService.GetRace("Naalu Collective");
			//Act
			var leaders = raceService.GetLeaders(race);
			//Assert
			var result = leaders.FindAll(x => x.LeaderType == "Admiral");
			Assert.AreEqual(1, result.Count);
		}

		[Test]
		public void GetRaceLeaders_ForNaaluCollective_HasAgent()
		{
			//Arrange
			var race = raceService.GetRace("Naalu Collective");
			//Act
			var leaders = raceService.GetLeaders(race);
			//Assert
			var result = leaders.FindAll(x => x.LeaderType == "Agent");
			Assert.AreEqual(1, result.Count);
		}

		[Test]
		public void GetRaceLeaders_ForNaaluCollective_HasDiplomat()
		{
			//Arrange
			var race = raceService.GetRace("Naalu Collective");
			//Act
			var leaders = raceService.GetLeaders(race);
			//Assert
			var result = leaders.FindAll(x => x.LeaderType == "Diplomat");
			Assert.AreEqual(1, result.Count);
		}

		[Test]
		public void GetRaceLeaders_ForSardakkNorr_HasAdmiral()
		{
			//Arrange
			var race = raceService.GetRace("Sardakk N’orr");
			//Act
			var leaders = raceService.GetLeaders(race);
			//Assert
			var result = leaders.FindAll(x => x.LeaderType == "Admiral");
			Assert.AreEqual(1, result.Count);
		}

		[Test]
		public void GetRaceLeaders_ForSardakkNorr_HasGeneral()
		{
			//Arrange
			var race = raceService.GetRace("Sardakk N’orr");
			//Act
			var leaders = raceService.GetLeaders(race);
			//Assert
			var result = leaders.FindAll(x => x.LeaderType == "General");
			Assert.AreEqual(1, result.Count);
		}

		[Test]
		public void GetRaceLeaders_ForUniversitiesOfJolNar_HasScientist()
		{
			//Arrange
			var race = raceService.GetRace("Universities of Jol-Nar");
			//Act
			var leaders = raceService.GetLeaders(race);
			//Assert
			var result = leaders.FindAll(x => x.LeaderType == "Scientist");
			Assert.AreEqual(1, result.Count);
		}

		[Test]
		public void GetRaceLeaders_ForUniversitiesOfJolNar_HasAdmiral()
		{
			//Arrange
			var race = raceService.GetRace("Universities of Jol-Nar");
			//Act
			var leaders = raceService.GetLeaders(race);
			//Assert
			var result = leaders.FindAll(x => x.LeaderType == "Admiral");
			Assert.AreEqual(1, result.Count);
		}

		[Test]
		public void GetRaceLeaders_ForXxchaKingdom_HasAdmiral()
		{
			//Arrange
			var race = raceService.GetRace("Xxcha Kingdom");
			//Act
			var leaders = raceService.GetLeaders(race);
			//Assert
			var result = leaders.FindAll(x => x.LeaderType == "Admiral");
			Assert.AreEqual(1, result.Count);
		}

		[Test]
		public void GetRaceLeaders_ForXxchaKingdom_HasDiplomat()
		{
			//Arrange
			var race = raceService.GetRace("Xxcha Kingdom");
			//Act
			var leaders = raceService.GetLeaders(race);
			//Assert
			var result = leaders.FindAll(x => x.LeaderType == "Diplomat");
			Assert.AreEqual(1, result.Count);
		}

		[Test]
		public void GetRaceLeaders_ForYssarilTribes_HasAgent()
		{
			//Arrange
			var race = raceService.GetRace("Yssaril Tribes");
			//Act
			var leaders = raceService.GetLeaders(race);
			//Assert
			var result = leaders.FindAll(x => x.LeaderType == "Agent");
			Assert.AreEqual(1, result.Count);
		}

		[Test]
		public void GetRaceLeaders_ForYssarilTribes_HasAdmiral()
		{
			//Arrange
			var race = raceService.GetRace("Yssaril Tribes");
			//Act
			var leaders = raceService.GetLeaders(race);
			//Assert
			var result = leaders.FindAll(x => x.LeaderType == "Admiral");
			Assert.AreEqual(1, result.Count);
		}

		[Test]
		public void GetRaceLeaders_ForClanOfSaar_HasAdmiral()
		{
			//Arrange
			var race = raceService.GetRace("Clan of Saar");
			//Act
			var leaders = raceService.GetLeaders(race);
			//Assert
			var result = leaders.FindAll(x => x.LeaderType == "Admiral");
			Assert.AreEqual(1, result.Count);
		}

		[Test]
		public void GetRaceLeaders_ForClanOfSaar_HasAgent()
		{
			//Arrange
			var race = raceService.GetRace("Clan of Saar");
			//Act
			var leaders = raceService.GetLeaders(race);
			//Assert
			var result = leaders.FindAll(x => x.LeaderType == "Agent");
			Assert.AreEqual(1, result.Count);
		}

		[Test]
		public void GetRaceLeaders_ForClanOfSaar_HasGeneral()
		{
			//Arrange
			var race = raceService.GetRace("Clan of Saar");
			//Act
			var leaders = raceService.GetLeaders(race);
			//Assert
			var result = leaders.FindAll(x => x.LeaderType == "General");
			Assert.AreEqual(1, result.Count);
		}

		[Test]
		public void GetRaceLeaders_ForEmbersOfMuaat_HasGeneral()
		{
			//Arrange
			var race = raceService.GetRace("Embers of Muaat");
			//Act
			var leaders = raceService.GetLeaders(race);
			//Assert
			var result = leaders.FindAll(x => x.LeaderType == "General");
			Assert.AreEqual(1, result.Count);
		}

		[Test]
		public void GetRaceLeaders_ForEmbersOfMuaat_HasScientist()
		{
			//Arrange
			var race = raceService.GetRace("Embers of Muaat");
			//Act
			var leaders = raceService.GetLeaders(race);
			//Assert
			var result = leaders.FindAll(x => x.LeaderType == "Scientist");
			Assert.AreEqual(1, result.Count);
		}

		[Test]
		public void GetRaceLeaders_ForEmbersOfMuaat_HasDiplomat()
		{
			//Arrange
			var race = raceService.GetRace("Embers of Muaat");
			//Act
			var leaders = raceService.GetLeaders(race);
			//Assert
			var result = leaders.FindAll(x => x.LeaderType == "Diplomat");
			Assert.AreEqual(1, result.Count);
		}

		[Test]
		public void GetRaceLeaders_ForWinnu_HasAgent()
		{
			//Arrange
			var race = raceService.GetRace("Winnu");
			//Act
			var leaders = raceService.GetLeaders(race);
			//Assert
			var result = leaders.FindAll(x => x.LeaderType == "Agent");
			Assert.AreEqual(1, result.Count);
		}

		[Test]
		public void GetRaceLeaders_ForWinnu_HasAdmiral()
		{
			//Arrange
			var race = raceService.GetRace("Winnu");
			//Act
			var leaders = raceService.GetLeaders(race);
			//Assert
			var result = leaders.FindAll(x => x.LeaderType == "Admiral");
			Assert.AreEqual(1, result.Count);
		}

		[Test]
		public void GetRaceLeaders_ForWinnu_HasScientist()
		{
			//Arrange
			var race = raceService.GetRace("Winnu");
			//Act
			var leaders = raceService.GetLeaders(race);
			//Assert
			var result = leaders.FindAll(x => x.LeaderType == "Scientist");
			Assert.AreEqual(1, result.Count);
		}

		[Test]
		public void GetRaceLeaders_ForYinBrotherhood_HasAgent()
		{
			//Arrange
			var race = raceService.GetRace("Yin Brotherhood");
			//Act
			var leaders = raceService.GetLeaders(race);
			//Assert
			var result = leaders.FindAll(x => x.LeaderType == "Agent");
			Assert.AreEqual(1, result.Count);
		}

		[Test]
		public void GetRaceLeaders_ForYinBrotherhood_HasAdmiral()
		{
			//Arrange
			var race = raceService.GetRace("Yin Brotherhood");
			//Act
			var leaders = raceService.GetLeaders(race);
			//Assert
			var result = leaders.FindAll(x => x.LeaderType == "Admiral");
			Assert.AreEqual(1, result.Count);
		}

		[Test]
		public void GetRaceLeaders_ForYinBrotherhood_HasDiplomat()
		{
			//Arrange
			var race = raceService.GetRace("Yin Brotherhood");
			//Act
			var leaders = raceService.GetLeaders(race);
			//Assert
			var result = leaders.FindAll(x => x.LeaderType == "Diplomat");
			Assert.AreEqual(1, result.Count);
		}

		[Test]
		public void GetRaceLeaders_ForArborec_HasDiplomat()
		{
			//Arrange
			var race = raceService.GetRace("Arborec");
			//Act
			var leaders = raceService.GetLeaders(race);
			//Assert
			var result = leaders.FindAll(x => x.LeaderType == "Diplomat");
			Assert.AreEqual(1, result.Count);
		}

		[Test]
		public void GetRaceLeaders_ForArborec_HasAdmiral()
		{
			//Arrange
			var race = raceService.GetRace("Arborec");
			//Act
			var leaders = raceService.GetLeaders(race);
			//Assert
			var result = leaders.FindAll(x => x.LeaderType == "Admiral");
			Assert.AreEqual(1, result.Count);
		}

		[Test]
		public void GetRaceLeaders_ForArborec_HasGeneral()
		{
			//Arrange
			var race = raceService.GetRace("Arborec");
			//Act
			var leaders = raceService.GetLeaders(race);
			//Assert
			var result = leaders.FindAll(x => x.LeaderType == "General");
			Assert.AreEqual(1, result.Count);
		}

		[Test]
		public void GetRaceLeaders_ForGhostsOfCreuss_HasDiplomat()
		{
			//Arrange
			var race = raceService.GetRace("Ghosts of Creuss");
			//Act
			var leaders = raceService.GetLeaders(race);
			//Assert
			var result = leaders.FindAll(x => x.LeaderType == "Diplomat");
			Assert.AreEqual(1, result.Count);
		}

		[Test]
		public void GetRaceLeaders_ForGhostsOfCreuss_HasAdmiral()
		{
			//Arrange
			var race = raceService.GetRace("Ghosts of Creuss");
			//Act
			var leaders = raceService.GetLeaders(race);
			//Assert
			var result = leaders.FindAll(x => x.LeaderType == "Admiral");
			Assert.AreEqual(1, result.Count);
		}

		[Test]
		public void GetRaceLeaders_ForGhostsOfCreuss_HasScientist()
		{
			//Arrange
			var race = raceService.GetRace("Ghosts of Creuss");
			//Act
			var leaders = raceService.GetLeaders(race);
			//Assert
			var result = leaders.FindAll(x => x.LeaderType == "Scientist");
			Assert.AreEqual(1, result.Count);
		}

		[Test]
		public void GetRaceLeaders_ForNekroVirus_HasAgent()
		{
			//Arrange
			var race = raceService.GetRace("Nekro Virus");
			//Act
			var leaders = raceService.GetLeaders(race);
			//Assert
			var result = leaders.FindAll(x => x.LeaderType == "Agent");
			Assert.AreEqual(1, result.Count);
		}

		[Test]
		public void GetRaceLeaders_ForNekroVirus_HasAdmiral()
		{
			//Arrange
			var race = raceService.GetRace("Nekro Virus");
			//Act
			var leaders = raceService.GetLeaders(race);
			//Assert
			var result = leaders.FindAll(x => x.LeaderType == "Admiral");
			Assert.AreEqual(1, result.Count);
		}

		[Test]
		public void GetRaceLeaders_ForNekroVirus_HasGeneral()
		{
			//Arrange
			var race = raceService.GetRace("Nekro Virus");
			//Act
			var leaders = raceService.GetLeaders(race);
			//Assert
			var result = leaders.FindAll(x => x.LeaderType == "General");
			Assert.AreEqual(1, result.Count);
		}
	}
}