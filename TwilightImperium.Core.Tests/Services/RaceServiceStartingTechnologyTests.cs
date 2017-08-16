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
	public class RaceServiceStartingTechnologyTests : MvxIoCSupportingTest
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
		public void GetRaceStartingTechnology_ForBaronyofLetnev_ReturnsCorrectNumberOfTechnology()
		{
			//Arrange
			var race = raceService.GetRace("Barony of Letnev");
			//Act
			var startingTechnology = raceService.GetStartingTechnology(race);
			Assert.AreEqual(2, startingTechnology.Count);
		}

		[Test]
		public void GetRaceStartingTechnology_ForBaronyofLetnev_HasHylarVTechnology()
		{
			//Arrange
			var race = raceService.GetRace("Barony of Letnev");
			//Act
			var startingTechnology = raceService.GetStartingTechnology(race);
			Assert.NotNull(startingTechnology.Find(x => x.Name == "Hylar V Assault Laser"));
		}

		[Test]
		public void GetRaceStartingTechnology_ForBaronyofLetnev_HasAntimassDeflectors()
		{
			//Arrange
			var race = raceService.GetRace("Barony of Letnev");
			//Act
			var startingTechnology = raceService.GetStartingTechnology(race);
			Assert.NotNull(startingTechnology.Find(x => x.Name == "Antimass Deflectors"));
		}

		[Test]
		public void GetRaceStartingTechnology_ForEmiratesOfHacan_ReturnsCorrectNumberOfTechnology()
		{
			//Arrange
			var race = raceService.GetRace("Emirates of Hacan");
			//Act
			var startingTechnology = raceService.GetStartingTechnology(race);
			Assert.AreEqual(2, startingTechnology.Count);
		}

		[Test]
		public void GetRaceStartingTechnology_ForEmiratesOfHacan_HasEnviroCompensator()
		{
			//Arrange
			var race = raceService.GetRace("Emirates of Hacan");
			//Act
			var startingTechnology = raceService.GetStartingTechnology(race);
			Assert.NotNull(startingTechnology.Find(x => x.Name == "Enviro Compensator"));
		}

		[Test]
		public void GetRaceStartingTechnology_ForEmiratesOfHacan_HasSarweenTools()
		{
			//Arrange
			var race = raceService.GetRace("Emirates of Hacan");
			//Act
			var startingTechnology = raceService.GetStartingTechnology(race);
			Assert.NotNull(startingTechnology.Find(x => x.Name == "Sarween Tools"));
		}

		[Test]
		public void GetRaceStartingTechnology_ForFederationOfSol_ReturnsCorrectNumberOfTechnology()
		{
			//Arrange
			var race = raceService.GetRace("Federation of Sol");
			//Act
			var startingTechnology = raceService.GetStartingTechnology(race);
			Assert.AreEqual(2, startingTechnology.Count);
		}

		[Test]
		public void GetRaceStartingTechnology_ForFederationOfSol_HasAntimassDeflectors()
		{
			//Arrange
			var race = raceService.GetRace("Federation of Sol");
			//Act
			var startingTechnology = raceService.GetStartingTechnology(race);
			Assert.NotNull(startingTechnology.Find(x => x.Name == "Antimass Deflectors"));
		}

		[Test]
		public void GetRaceStartingTechnology_ForFederationOfSol_HasCybernetics()
		{
			//Arrange
			var race = raceService.GetRace("Federation of Sol");
			//Act
			var startingTechnology = raceService.GetStartingTechnology(race);
			Assert.NotNull(startingTechnology.Find(x => x.Name == "Cybernetics"));
		}

		[Test]
		public void GetRaceStartingTechnology_ForForL1z1xMindnet_ReturnsCorrectNumberOfTechnology()
		{
			//Arrange
			var race = raceService.GetRace("L1z1x Mindnet");
			//Act
			var startingTechnology = raceService.GetStartingTechnology(race);
			Assert.AreEqual(4, startingTechnology.Count);
		}

		[Test]
		public void GetRaceStartingTechnology_ForForL1z1xMindnet_HasEnviroCompensator()
		{
			//Arrange
			var race = raceService.GetRace("L1z1x Mindnet");
			//Act
			var startingTechnology = raceService.GetStartingTechnology(race);
			Assert.NotNull(startingTechnology.Find(x => x.Name == "Enviro Compensator"));
		}

		[Test]
		public void GetRaceStartingTechnology_ForForL1z1xMindnet_HasStasisCapsules()
		{
			//Arrange
			var race = raceService.GetRace("L1z1x Mindnet");
			//Act
			var startingTechnology = raceService.GetStartingTechnology(race);
			Assert.NotNull(startingTechnology.Find(x => x.Name == "Stasis Capsules"));
		}

		[Test]
		public void GetRaceStartingTechnology_ForForL1z1xMindnet_HasCybernetics()
		{
			//Arrange
			var race = raceService.GetRace("L1z1x Mindnet");
			//Act
			var startingTechnology = raceService.GetStartingTechnology(race);
			Assert.NotNull(startingTechnology.Find(x => x.Name == "Cybernetics"));
		}

		[Test]
		public void GetRaceStartingTechnology_ForForL1z1xMindnet_HasHylerV()
		{
			//Arrange
			var race = raceService.GetRace("L1z1x Mindnet");
			//Act
			var startingTechnology = raceService.GetStartingTechnology(race);
			Assert.NotNull(startingTechnology.Find(x => x.Name == "Hylar V Assault Laser"));
		}

		[Test]
		public void GetRaceStartingTechnology_ForMentakCoalition_ReturnsCorrectNumberOfTechnology()
		{
			//Arrange
			var race = raceService.GetRace("Mentak Coalition");
			//Act
			var startingTechnology = raceService.GetStartingTechnology(race);
			Assert.AreEqual(2, startingTechnology.Count);
		}

		[Test]
		public void GetRaceStartingTechnology_ForMentakCoalition_HasHylerV()
		{
			//Arrange
			var race = raceService.GetRace("Mentak Coalition");
			//Act
			var startingTechnology = raceService.GetStartingTechnology(race);
			Assert.NotNull(startingTechnology.Find(x => x.Name == "Hylar V Assault Laser"));
		}

		[Test]
		public void GetRaceStartingTechnology_ForMentakCoalition_HasEnviroCompensator()
		{
			//Arrange
			var race = raceService.GetRace("Mentak Coalition");
			//Act
			var startingTechnology = raceService.GetStartingTechnology(race);
			Assert.NotNull(startingTechnology.Find(x => x.Name == "Enviro Compensator"));
		}

		[Test]
		public void GetRaceStartingTechnology_ForNaaluCollective_ReturnsCorrectNumberOfTechnology()
		{
			//Arrange
			var race = raceService.GetRace("Naalu Collective");
			//Act
			var startingTechnology = raceService.GetStartingTechnology(race);
			Assert.AreEqual(2, startingTechnology.Count);
		}

		[Test]
		public void GetRaceStartingTechnology_ForNaaluCollective_HasAntimassDeflectors()
		{
			//Arrange
			var race = raceService.GetRace("Naalu Collective");
			//Act
			var startingTechnology = raceService.GetStartingTechnology(race);
			Assert.NotNull(startingTechnology.Find(x => x.Name == "Antimass Deflectors"));
		}

		[Test]
		public void GetRaceStartingTechnology_ForNaaluCollective_HasEnviroCompensator()
		{
			//Arrange
			var race = raceService.GetRace("Naalu Collective");
			//Act
			var startingTechnology = raceService.GetStartingTechnology(race);
			Assert.NotNull(startingTechnology.Find(x => x.Name == "Enviro Compensator"));
		}

		[Test]
		public void GetRaceStartingTechnology_ForSardakkNorr_ReturnsCorrectNumberOfTechnology()
		{
			//Arrange
			var race = raceService.GetRace("Sardakk N’orr");
			//Act
			var startingTechnology = raceService.GetStartingTechnology(race);
			Assert.AreEqual(2, startingTechnology.Count);
		}

		[Test]
		public void GetRaceStartingTechnology_ForSardakkNorr_HasHylerV()
		{
			//Arrange
			var race = raceService.GetRace("Sardakk N’orr");
			//Act
			var startingTechnology = raceService.GetStartingTechnology(race);
			Assert.NotNull(startingTechnology.Find(x => x.Name == "Hylar V Assault Laser"));
		}

		[Test]
		public void GetRaceStartingTechnology_ForSardakkNorr_HasDeepSpaceCannon()
		{
			//Arrange
			var race = raceService.GetRace("Sardakk N’orr");
			//Act
			var startingTechnology = raceService.GetStartingTechnology(race);
			Assert.NotNull(startingTechnology.Find(x => x.Name == "Deep Space Cannon"));
		}

		[Test]
		public void GetRaceStartingTechnology_ForUniversitiesOfJolNar_ReturnsCorrectNumberOfTechnology()
		{
			//Arrange
			var race = raceService.GetRace("Universities of Jol-Nar");
			//Act
			var startingTechnology = raceService.GetStartingTechnology(race);
			Assert.AreEqual(4, startingTechnology.Count);
		}

		[Test]
		public void GetRaceStartingTechnology_ForUniversitiesOfJolNar_HasHylerV()
		{
			//Arrange
			var race = raceService.GetRace("Universities of Jol-Nar");
			//Act
			var startingTechnology = raceService.GetStartingTechnology(race);
			Assert.NotNull(startingTechnology.Find(x => x.Name == "Hylar V Assault Laser"));
		}

		[Test]
		public void GetRaceStartingTechnology_ForUniversitiesOfJolNar_HasAntimassDeflectors()
		{
			//Arrange
			var race = raceService.GetRace("Universities of Jol-Nar");
			//Act
			var startingTechnology = raceService.GetStartingTechnology(race);
			Assert.NotNull(startingTechnology.Find(x => x.Name == "Antimass Deflectors"));
		}

		[Test]
		public void GetRaceStartingTechnology_ForUniversitiesOfJolNar_HasEnviroCompensator()
		{
			//Arrange
			var race = raceService.GetRace("Universities of Jol-Nar");
			//Act
			var startingTechnology = raceService.GetStartingTechnology(race);
			Assert.NotNull(startingTechnology.Find(x => x.Name == "Enviro Compensator"));
		}

		[Test]
		public void GetRaceStartingTechnology_ForUniversitiesOfJolNar_HasSarweenTools()
		{
			//Arrange
			var race = raceService.GetRace("Universities of Jol-Nar");
			//Act
			var startingTechnology = raceService.GetStartingTechnology(race);
			Assert.NotNull(startingTechnology.Find(x => x.Name == "Sarween Tools"));
		}

		[Test]
		public void GetRaceStartingTechnology_ForXxchaKingdom_ReturnsCorrectNumberOfTechnology()
		{
			//Arrange
			var race = raceService.GetRace("Xxcha Kingdom");
			//Act
			var startingTechnology = raceService.GetStartingTechnology(race);
			Assert.AreEqual(2, startingTechnology.Count);
		}

		[Test]
		public void GetRaceStartingTechnology_ForXxchaKingdom_HasAntimassDeflectors()
		{
			//Arrange
			var race = raceService.GetRace("Xxcha Kingdom");
			//Act
			var startingTechnology = raceService.GetStartingTechnology(race);
			Assert.NotNull(startingTechnology.Find(x => x.Name == "Antimass Deflectors"));
		}

		[Test]
		public void GetRaceStartingTechnology_ForXxchaKingdom_HasEnviroCompensator()
		{
			//Arrange
			var race = raceService.GetRace("Xxcha Kingdom");
			//Act
			var startingTechnology = raceService.GetStartingTechnology(race);
			Assert.NotNull(startingTechnology.Find(x => x.Name == "Enviro Compensator"));
		}

		[Test]
		public void GetRaceStartingTechnology_ForYssarilTribes_ReturnsCorrectNumberOfTechnology()
		{
			//Arrange
			var race = raceService.GetRace("Yssaril Tribes");
			//Act
			var startingTechnology = raceService.GetStartingTechnology(race);
			Assert.AreEqual(2, startingTechnology.Count);
		}

		[Test]
		public void GetRaceStartingTechnology_ForYssarilTribes_HasAntimassDeflectors()
		{
			//Arrange
			var race = raceService.GetRace("Yssaril Tribes");
			//Act
			var startingTechnology = raceService.GetStartingTechnology(race);
			Assert.NotNull(startingTechnology.Find(x => x.Name == "Antimass Deflectors"));
		}

		[Test]
		public void GetRaceStartingTechnology_ForYssarilTribes_HasXRDTransporter()
		{
			//Arrange
			var race = raceService.GetRace("Yssaril Tribes");
			//Act
			var startingTechnology = raceService.GetStartingTechnology(race);
			Assert.NotNull(startingTechnology.Find(x => x.Name == "XRD Transporter"));
		}

		[Test]
		public void GetRaceStartingTechnology_ForClanOfSaar_ReturnsCorrectNumberOfTechnology()
		{
			//Arrange
			var race = raceService.GetRace("Clan of Saar");
			//Act
			var startingTechnology = raceService.GetStartingTechnology(race);
			Assert.AreEqual(2, startingTechnology.Count);
		}

		[Test]
		public void GetRaceStartingTechnology_ForClanOfSaar_HasAntimassDeflectors()
		{
			//Arrange
			var race = raceService.GetRace("Clan of Saar");
			//Act
			var startingTechnology = raceService.GetStartingTechnology(race);
			Assert.NotNull(startingTechnology.Find(x => x.Name == "Antimass Deflectors"));
		}

		[Test]
		public void GetRaceStartingTechnology_ForClanOfSaar_HasXRDTransporter()
		{
			//Arrange
			var race = raceService.GetRace("Clan of Saar");
			//Act
			var startingTechnology = raceService.GetStartingTechnology(race);
			Assert.NotNull(startingTechnology.Find(x => x.Name == "XRD Transporter"));
		}

		[Test]
		public void GetRaceStartingTechnology_ForEmbersOfMuaat_ReturnsCorrectNumberOfTechnology()
		{
			//Arrange
			var race = raceService.GetRace("Embers of Muaat");
			//Act
			var startingTechnology = raceService.GetStartingTechnology(race);
			Assert.AreEqual(3, startingTechnology.Count);
		}

		[Test]
		public void GetRaceStartingTechnology_ForEmbersOfMuaat_HasEnviroCompensator()
		{
			//Arrange
			var race = raceService.GetRace("Embers of Muaat");
			//Act
			var startingTechnology = raceService.GetStartingTechnology(race);
			Assert.NotNull(startingTechnology.Find(x => x.Name == "Enviro Compensator"));
		}

		[Test]
		public void GetRaceStartingTechnology_ForEmbersOfMuaat_HasSarweenToold()
		{
			//Arrange
			var race = raceService.GetRace("Embers of Muaat");
			//Act
			var startingTechnology = raceService.GetStartingTechnology(race);
			Assert.NotNull(startingTechnology.Find(x => x.Name == "Sarween Tools"));
		}

		[Test]
		public void GetRaceStartingTechnology_ForEmbersOfMuaat_HasWarSun()
		{
			//Arrange
			var race = raceService.GetRace("Embers of Muaat");
			//Act
			var startingTechnology = raceService.GetStartingTechnology(race);
			Assert.NotNull(startingTechnology.Find(x => x.Name == "War Sun"));
		}

		[Test]
		public void GetRaceStartingTechnology_ForWinnu_ReturnsCorrectNumberOfTechnology()
		{
			//Arrange
			var race = raceService.GetRace("Winnu");
			//Act
			var startingTechnology = raceService.GetStartingTechnology(race);
			Assert.AreEqual(3, startingTechnology.Count);
		}

		[Test]
		public void GetRaceStartingTechnology_ForWinnu_HasEnviroCompensator()
		{
			//Arrange
			var race = raceService.GetRace("Winnu");
			//Act
			var startingTechnology = raceService.GetStartingTechnology(race);
			Assert.NotNull(startingTechnology.Find(x => x.Name == "Enviro Compensator"));
		}

		[Test]
		public void GetRaceStartingTechnology_ForWinnu_HasStasisCapsules()
		{
			//Arrange
			var race = raceService.GetRace("Winnu");
			//Act
			var startingTechnology = raceService.GetStartingTechnology(race);
			Assert.NotNull(startingTechnology.Find(x => x.Name == "Stasis Capsules"));
		}

		[Test]
		public void GetRaceStartingTechnology_ForWinnu_HasAntimassDeflectors()
		{
			//Arrange
			var race = raceService.GetRace("Winnu");
			//Act
			var startingTechnology = raceService.GetStartingTechnology(race);
			Assert.NotNull(startingTechnology.Find(x => x.Name == "Antimass Deflectors"));
		}

		[Test]
		public void GetRaceStartingTechnology_ForYinBrotherhood_ReturnsCorrectNumberOfTechnology()
		{
			//Arrange
			var race = raceService.GetRace("Yin Brotherhood");
			//Act
			var startingTechnology = raceService.GetStartingTechnology(race);
			Assert.AreEqual(2, startingTechnology.Count);
		}

		[Test]
		public void GetRaceStartingTechnology_ForYinBrotherhood_HasHylarV()
		{
			//Arrange
			var race = raceService.GetRace("Yin Brotherhood");
			//Act
			var startingTechnology = raceService.GetStartingTechnology(race);
			Assert.NotNull(startingTechnology.Find(x => x.Name == "Hylar V Assault Laser"));
		}

		[Test]
		public void GetRaceStartingTechnology_ForYinBrotherhood_HasAutomatedDefenseTurrets()
		{
			//Arrange
			var race = raceService.GetRace("Yin Brotherhood");
			//Act
			var startingTechnology = raceService.GetStartingTechnology(race);
			Assert.NotNull(startingTechnology.Find(x => x.Name == "Automated Defense Turrets"));
		}

		[Test]
		public void GetRaceStartingTechnology_ForArborec_ReturnsCorrectNumberOfTechnology()
		{
			//Arrange
			var race = raceService.GetRace("Arborec");
			//Act
			var startingTechnology = raceService.GetStartingTechnology(race);
			Assert.AreEqual(2, startingTechnology.Count);
		}

		[Test]
		public void GetRaceStartingTechnology_ForArborec_HasAntimassDeflectors()
		{
			//Arrange
			var race = raceService.GetRace("Arborec");
			//Act
			var startingTechnology = raceService.GetStartingTechnology(race);
			Assert.NotNull(startingTechnology.Find(x => x.Name == "Antimass Deflectors"));
		}

		[Test]
		public void GetRaceStartingTechnology_ForArborec_HasStasisCapsules()
		{
			//Arrange
			var race = raceService.GetRace("Arborec");
			//Act
			var startingTechnology = raceService.GetStartingTechnology(race);
			Assert.NotNull(startingTechnology.Find(x => x.Name == "Stasis Capsules"));
		}

		[Test]
		public void GetRaceStartingTechnology_ForGhostsOfCreuss_ReturnsCorrectNumberOfTechnology()
		{
			//Arrange
			var race = raceService.GetRace("Ghosts of Creuss");
			//Act
			var startingTechnology = raceService.GetStartingTechnology(race);
			Assert.AreEqual(2, startingTechnology.Count);
		}

		[Test]
		public void GetRaceStartingTechnology_ForGhostsOfCreuss_HasAntimassDeflectors()
		{
			//Arrange
			var race = raceService.GetRace("Ghosts of Creuss");
			//Act
			var startingTechnology = raceService.GetStartingTechnology(race);
			Assert.NotNull(startingTechnology.Find(x => x.Name == "Antimass Deflectors"));
		}

		[Test]
		public void GetRaceStartingTechnology_ForGhostsOfCreuss_HasXRDTransporter()
		{
			//Arrange
			var race = raceService.GetRace("Ghosts of Creuss");
			//Act
			var startingTechnology = raceService.GetStartingTechnology(race);
			Assert.NotNull(startingTechnology.Find(x => x.Name == "XRD Transporter"));
		}

		[Test]
		public void GetRaceStartingTechnology_ForNekroVirus_ReturnsCorrectNumberOfTechnology()
		{
			//Arrange
			var race = raceService.GetRace("Nekro Virus");
			//Act
			var startingTechnology = raceService.GetStartingTechnology(race);
			Assert.AreEqual(3, startingTechnology.Count);
		}

		[Test]
		public void GetRaceStartingTechnology_ForNekroVirus_HasGenSynthesis()
		{
			//Arrange
			var race = raceService.GetRace("Nekro Virus");
			//Act
			var startingTechnology = raceService.GetStartingTechnology(race);
			Assert.NotNull(startingTechnology.Find(x => x.Name == "Gen Synthesis"));
		}

		[Test]
		public void GetRaceStartingTechnology_ForNekroVirus_HasHylarV()
		{
			//Arrange
			var race = raceService.GetRace("Nekro Virus");
			//Act
			var startingTechnology = raceService.GetStartingTechnology(race);
			Assert.NotNull(startingTechnology.Find(x => x.Name == "Hylar V Assault Laser"));
		}

		[Test]
		public void GetRaceStartingTechnology_ForNekroVirus_HasDacxiveAnimators()
		{
			//Arrange
			var race = raceService.GetRace("Nekro Virus");
			//Act
			var startingTechnology = raceService.GetStartingTechnology(race);
			Assert.NotNull(startingTechnology.Find(x => x.Name == "Dacxive Animators"));
		}
    }
}
