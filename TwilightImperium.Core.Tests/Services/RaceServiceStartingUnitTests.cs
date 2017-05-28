using System.Linq;
using MvvmCross.Platform;
using MvvmCross.Test.Core;
using NUnit.Framework;
using SQLite.Net;
using TwilightImperiumMasterCompanion.Core;
using TwilightImperiumMasterCompanion.Core.DataAccess;
using TwilightImperiumMasterCompanion.Core.DataAccess.Interfaces;
using TwilightImperiumMasterCompanion.Core.Services.Interfaces;

namespace TwilightImperium.Core.Tests.Services
{
    [TestFixture]
	public class RaceServiceStartingUnitTests : MvxIoCSupportingTest
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
		public void GetRaceStartingUnits_ForBaronyofLetnev_ReturnsNumberOfUnits()
		{
			//Arrange
			var race = raceService.GetRace("Barony of Letnev");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var result = startingUnits.Sum(x => x.Quantity);
			Assert.AreEqual(7, result);
		}

		[Test]
		public void GetRaceStartingUnits_ForBaronyofLetnev_HasOneSpaceDock()
		{
			//Arrange
			var race = raceService.GetRace("Barony of Letnev");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
            var unit = startingUnits.Find(x => x.Name == "Space Dock");
            Assert.AreEqual(1,unit.Quantity);
		}

		[Test]
		public void GetRaceStartingUnits_ForBaronyofLetnev_HasOneDreadnought()
		{
			//Arrange
			var race = raceService.GetRace("Barony of Letnev");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "Dreadnought");
			Assert.AreEqual(1, unit.Quantity);
		}

		[Test]
		public void GetRaceStartingUnits_ForBaronyofLetnev_HasOneDestroyer()
		{
			//Arrange
			var race = raceService.GetRace("Barony of Letnev");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "Destroyer");
			Assert.AreEqual(1, unit.Quantity);
		}

		[Test]
		public void GetRaceStartingUnits_ForBaronyofLetnev_HasOneCarrier()
		{
			//Arrange
			var race = raceService.GetRace("Barony of Letnev");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "Carrier");
			Assert.AreEqual(1, unit.Quantity);
		}

		[Test]
		public void GetRaceStartingUnits_ForBaronyofLetnev_HasThreeGF()
		{
			//Arrange
			var race = raceService.GetRace("Barony of Letnev");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "Ground Force");
			Assert.AreEqual(3, unit.Quantity);
		}

		[Test]
		public void GetRaceStartingUnits_ForEmiratesOfHacan_ReturnsCorrectSetOfUnits()
		{
			//Arrange
			var race = raceService.GetRace("Emirates of Hacan");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var result = startingUnits.Sum(x => x.Quantity);
			Assert.AreEqual(10, result);
		}

		[Test]
		public void GetRaceStartingUnits_ForEmiratesOfHacan_HasFourGF()
		{
			//Arrange
			var race = raceService.GetRace("Emirates of Hacan");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "Ground Force");
			Assert.AreEqual(4, unit.Quantity);
		}

		[Test]
		public void GetRaceStartingUnits_ForEmiratesOfHacan_HasTwoCarriers()
		{
			//Arrange
			var race = raceService.GetRace("Emirates of Hacan");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "Carrier");
			Assert.AreEqual(2, unit.Quantity);
		}

		[Test]
		public void GetRaceStartingUnits_ForEmiratesOfHacan_HasOneCruiser()
		{
			//Arrange
			var race = raceService.GetRace("Emirates of Hacan");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "Cruiser");
			Assert.AreEqual(1, unit.Quantity);
		}

		[Test]
		public void GetRaceStartingUnits_ForEmiratesOfHacan_HasTwoFighters()
		{
			//Arrange
			var race = raceService.GetRace("Emirates of Hacan");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "Fighter");
			Assert.AreEqual(2, unit.Quantity);
		}

		[Test]
		public void GetRaceStartingUnits_ForEmiratesOfHacan_HasOneSpaceDock()
		{
			//Arrange
			var race = raceService.GetRace("Emirates of Hacan");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "Space Dock");
			Assert.AreEqual(1, unit.Quantity);
		}

		[Test]
		public void GetRaceStartingUnits_ForFederationOfSol_ReturnsCorrectSetOfUnits()
		{
			//Arrange
			var race = raceService.GetRace("Federation of Sol");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var result = startingUnits.Sum(x => x.Quantity);
			Assert.AreEqual(9, result);
		}

        [Test]
        public void GetRaceStartingUnits_ForFederationOfSol_HasOneSpaceDock()
		{
			//Arrange
			var race = raceService.GetRace("Federation of Sol");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "Space Dock");
			Assert.AreEqual(1, unit.Quantity);
		}

		[Test]
		public void GetRaceStartingUnits_ForFederationOfSol_HasFiveGF()
		{
			//Arrange
			var race = raceService.GetRace("Federation of Sol");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "Ground Force");
			Assert.AreEqual(5, unit.Quantity);
		}

		[Test]
		public void GetRaceStartingUnits_ForFederationOfSol_HasTwoCarriers()
		{
			//Arrange
			var race = raceService.GetRace("Federation of Sol");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "Carrier");
			Assert.AreEqual(2, unit.Quantity);
		}

        [Test]
        public void GetRaceStartingUnits_ForFederationOfSol_HasOneDestroyer()
        {
            //Arrange
            var race = raceService.GetRace("Federation of Sol");
            //Act
            var startingUnits = raceService.GetStartingUnits(race);
            var unit = startingUnits.Find(x => x.Name == "Destroyer");
            Assert.AreEqual(1, unit.Quantity);
        }

		[Test]
		public void GetRaceStartingUnits_ForL1z1xMindnet_ReturnsCorrectSetOfUnits()
		{
			//Arrange
			var race = raceService.GetRace("L1z1x Mindnet");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var result = startingUnits.Sum(x => x.Quantity);
			Assert.AreEqual(12, result);
		}

		[Test]
		public void GetRaceStartingUnits_ForL1z1xMindnet_HasOneSpaceDock()
		{
			//Arrange
			var race = raceService.GetRace("L1z1x Mindnet");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "Space Dock");
			Assert.AreEqual(1, unit.Quantity);
		}

		[Test]
		public void GetRaceStartingUnits_ForL1z1xMindnet_HasOneCarrier()
		{
			//Arrange
			var race = raceService.GetRace("L1z1x Mindnet");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "Carrier");
			Assert.AreEqual(1, unit.Quantity);
		}

		[Test]
		public void GetRaceStartingUnits_ForL1z1xMindnet_HasFiveGF()
		{
			//Arrange
			var race = raceService.GetRace("L1z1x Mindnet");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "Ground Force");
			Assert.AreEqual(5, unit.Quantity);
		}

		[Test]
		public void GetRaceStartingUnits_ForL1z1xMindnet_HasOneDreadnought()
		{
			//Arrange
			var race = raceService.GetRace("L1z1x Mindnet");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "Dreadnought");
			Assert.AreEqual(1, unit.Quantity);
		}

		[Test]
		public void GetRaceStartingUnits_ForL1z1xMindnet_HasThreeFighters()
		{
			//Arrange
			var race = raceService.GetRace("L1z1x Mindnet");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "Fighter");
			Assert.AreEqual(3, unit.Quantity);
		}

		[Test]
		public void GetRaceStartingUnits_ForL1z1xMindnet_HasOnePDS()
		{
			//Arrange
			var race = raceService.GetRace("L1z1x Mindnet");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "PDS");
			Assert.AreEqual(1, unit.Quantity);
		}

		[Test]
		public void GetRaceStartingUnits_ForMentakCoalition_ReturnsCorrectSetOfUnits()
		{
			//Arrange
			var race = raceService.GetRace("Mentak Coalition");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var result = startingUnits.Sum(x => x.Quantity);
			Assert.AreEqual(10, result);
		}

		[Test]
		public void GetRaceStartingUnits_ForMentakCoalition_HasOneCarrier()
		{
			//Arrange
			var race = raceService.GetRace("Mentak Coalition");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "Carrier");
			Assert.AreEqual(1, unit.Quantity);
		}

        [Test]
        public void GetRaceStartingUnits_ForMentakCoalition_HasThreeCruisers()
        {
            //Arrange
            var race = raceService.GetRace("Mentak Coalition");
            //Act
            var startingUnits = raceService.GetStartingUnits(race);
            var unit = startingUnits.Find(x => x.Name == "Cruiser");
            Assert.AreEqual(3, unit.Quantity);
        }

		[Test]
		public void GetRaceStartingUnits_ForMentakCoalition_HasOneSpaceDock()
		{
			//Arrange
			var race = raceService.GetRace("Mentak Coalition");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "Space Dock");
			Assert.AreEqual(1, unit.Quantity);
		}

		[Test]
		public void GetRaceStartingUnits_ForMentakCoalition_HasOnePDS()
		{
			//Arrange
			var race = raceService.GetRace("Mentak Coalition");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "PDS");
			Assert.AreEqual(1, unit.Quantity);
		}

		[Test]
		public void GetRaceStartingUnits_ForMentakCoalition_HasFourGF()
		{
			//Arrange
			var race = raceService.GetRace("Mentak Coalition");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "Ground Force");
			Assert.AreEqual(4, unit.Quantity);
		}

		[Test]
		public void GetRaceStartingUnits_ForNaaluCollective_ReturnsCorrectSetOfUnits()
		{
			//Arrange
			var race = raceService.GetRace("Naalu Collective");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var result = startingUnits.Sum(x => x.Quantity);
			Assert.AreEqual(13, result);
		}

		[Test]
		public void GetRaceStartingUnits_ForNaaluCollective_HasOneSpaceDock()
		{
			//Arrange
			var race = raceService.GetRace("Naalu Collective");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "Space Dock");
			Assert.AreEqual(1, unit.Quantity);
		}

		[Test]
		public void GetRaceStartingUnits_ForNaaluCollective_HasFourGF()
		{
			//Arrange
			var race = raceService.GetRace("Naalu Collective");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "Ground Force");
			Assert.AreEqual(4, unit.Quantity);
		}

		[Test]
		public void GetRaceStartingUnits_ForNaaluCollective_HasOnePDS()
		{
			//Arrange
			var race = raceService.GetRace("Naalu Collective");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "PDS");
			Assert.AreEqual(1, unit.Quantity);
		}

		[Test]
		public void GetRaceStartingUnits_ForNaaluCollective_HasOneCarrier()
		{
			//Arrange
			var race = raceService.GetRace("Naalu Collective");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "Carrier");
			Assert.AreEqual(1, unit.Quantity);
        }

		[Test]
		public void GetRaceStartingUnits_ForNaaluCollective_HasOneCruiser()
		{
			//Arrange
			var race = raceService.GetRace("Naalu Collective");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "Cruiser");
			Assert.AreEqual(1, unit.Quantity);
		}

		[Test]
		public void GetRaceStartingUnits_ForNaaluCollective_HasOneDestroyer()
		{
			//Arrange
			var race = raceService.GetRace("Naalu Collective");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "Destroyer");
			Assert.AreEqual(1, unit.Quantity);
		}

		[Test]
		public void GetRaceStartingUnits_ForNaaluCollective_HasFourFighters()
		{
			//Arrange
			var race = raceService.GetRace("Naalu Collective");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "Fighter");
			Assert.AreEqual(4, unit.Quantity);
		}

		[Test]
		public void GetRaceStartingUnits_ForSardakkNorr_ReturnsCorrectSetOfUnits()
		{
			//Arrange
			var race = raceService.GetRace("Sardakk N’orr");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var result = startingUnits.Sum(x => x.Quantity);
			Assert.AreEqual(9, result);
		}

		[Test]
		public void GetRaceStartingUnits_ForSardakkNorr_HasFiveGF()
		{
			//Arrange
			var race = raceService.GetRace("Sardakk N’orr");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "Ground Force");
			Assert.AreEqual(5, unit.Quantity);
		}

		[Test]
		public void GetRaceStartingUnits_ForSardakkNorr_HasOneCarrier()
		{
			//Arrange
			var race = raceService.GetRace("Sardakk N’orr");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "Carrier");
			Assert.AreEqual(1, unit.Quantity);
		}

		[Test]
		public void GetRaceStartingUnits_ForSardakkNorr_HasOneCruiser()
		{
			//Arrange
			var race = raceService.GetRace("Sardakk N’orr");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "Cruiser");
			Assert.AreEqual(1, unit.Quantity);
		}

		[Test]
		public void GetRaceStartingUnits_ForSardakkNorr_HasOnePDS()
		{
			//Arrange
			var race = raceService.GetRace("Sardakk N’orr");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "PDS");
			Assert.AreEqual(1, unit.Quantity);
		}

		[Test]
		public void GetRaceStartingUnits_ForSardakkNorr_HasOneSpaceDock()
		{
			//Arrange
			var race = raceService.GetRace("Sardakk N’orr");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "Space Dock");
			Assert.AreEqual(1, unit.Quantity);
		}


		[Test]
		public void GetRaceStartingUnits_ForUniversitiesOfJolNar_ReturnsCorrectSetOfUnits()
		{
			//Arrange
			var race = raceService.GetRace("Universities of Jol-Nar");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var result = startingUnits.Sum(x => x.Quantity);
			Assert.AreEqual(9, result);
		}

		[Test]
		public void GetRaceStartingUnits_ForUniversitiesOfJolNar_HasTwoGroundForces()
		{
			//Arrange
			var race = raceService.GetRace("Universities of Jol-Nar");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "Ground Force");
			Assert.AreEqual(2, unit.Quantity);
		}

		[Test]
		public void GetRaceStartingUnits_ForUniversitiesOfJolNar_HasTwoCariers()
		{
			//Arrange
			var race = raceService.GetRace("Universities of Jol-Nar");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "Carrier");
			Assert.AreEqual(2, unit.Quantity);
		}

		[Test]
		public void GetRaceStartingUnits_ForUniversitiesOfJolNar_HasOneFighter()
		{
			//Arrange
			var race = raceService.GetRace("Universities of Jol-Nar");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "Fighter");
			Assert.AreEqual(1, unit.Quantity);
		}

		[Test]
		public void GetRaceStartingUnits_ForUniversitiesOfJolNar_HasTwoPDS()
		{
			//Arrange
			var race = raceService.GetRace("Universities of Jol-Nar");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "PDS");
			Assert.AreEqual(2, unit.Quantity);
		}

		[Test]
		public void GetRaceStartingUnits_ForUniversitiesOfJolNar_HasOneDreadnought()
		{
			//Arrange
			var race = raceService.GetRace("Universities of Jol-Nar");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "Dreadnought");
			Assert.AreEqual(1, unit.Quantity);
		}

		[Test]
		public void GetRaceStartingUnits_ForUniversitiesOfJolNar_HasOneSpaceDock()
		{
			//Arrange
			var race = raceService.GetRace("Universities of Jol-Nar");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "Space Dock");
			Assert.AreEqual(1, unit.Quantity);
		}

		[Test]
		public void GetRaceStartingUnits_ForXxchaKingdom_ReturnsCorrectSetOfUnits()
		{
			//Arrange
			var race = raceService.GetRace("Xxcha Kingdom");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var result = startingUnits.Sum(x => x.Quantity);
			Assert.AreEqual(10, result);
		}

		[Test]
		public void GetRaceStartingUnits_ForXxchaKingdom_HasOneSpaceDock()
		{
			//Arrange
			var race = raceService.GetRace("Xxcha Kingdom");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "Space Dock");
			Assert.AreEqual(1, unit.Quantity);
		}

		[Test]
		public void GetRaceStartingUnits_ForXxchaKingdom_HasThreeFighters()
		{
			//Arrange
			var race = raceService.GetRace("Xxcha Kingdom");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "Fighter");
			Assert.AreEqual(3, unit.Quantity);
		}

		[Test]
		public void GetRaceStartingUnits_ForXxchaKingdom_HasOnePDS()
		{
			//Arrange
			var race = raceService.GetRace("Xxcha Kingdom");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "PDS");
			Assert.AreEqual(1, unit.Quantity);
		}

		[Test]
		public void GetRaceStartingUnits_ForXxchaKingdom_HasOneCarrier()
		{
			//Arrange
			var race = raceService.GetRace("Xxcha Kingdom");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "Carrier");
			Assert.AreEqual(1, unit.Quantity);
		}

		[Test]
		public void GetRaceStartingUnits_ForXxchaKingdom_HasTwoGroundForces()
		{
			//Arrange
			var race = raceService.GetRace("Xxcha Kingdom");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "Ground Force");
			Assert.AreEqual(2, unit.Quantity);
		}

		[Test]
		public void GetRaceStartingUnits_ForXxchaKingdom_HasTwoCruisers()
		{
			//Arrange
			var race = raceService.GetRace("Xxcha Kingdom");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "Cruiser");
			Assert.AreEqual(2, unit.Quantity);
		}

		[Test]
		public void GetRaceStartingUnits_ForYssarilTribes_ReturnsCorrectSetOfUnits()
		{
			//Arrange
			var race = raceService.GetRace("Yssaril Tribes");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var result = startingUnits.Sum(x => x.Quantity);
			Assert.AreEqual(12, result);
		}

		[Test]
		public void GetRaceStartingUnits_ForYssarilTribes_HasOneSpaceDock()
		{
			//Arrange
			var race = raceService.GetRace("Yssaril Tribes");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "Space Dock");
			Assert.AreEqual(1, unit.Quantity);
		}

		[Test]
		public void GetRaceStartingUnits_ForYssarilTribes_HasFiveGF()
		{
			//Arrange
			var race = raceService.GetRace("Yssaril Tribes");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "Ground Force");
			Assert.AreEqual(5, unit.Quantity);
		}

		[Test]
		public void GetRaceStartingUnits_ForYssarilTribes_HasOnePDS()
		{
			//Arrange
			var race = raceService.GetRace("Yssaril Tribes");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "PDS");
			Assert.AreEqual(1, unit.Quantity);
		}

		[Test]
		public void GetRaceStartingUnits_ForYssarilTribes_HasTwoCarriers()
		{
			//Arrange
			var race = raceService.GetRace("Yssaril Tribes");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "Carrier");
			Assert.AreEqual(2, unit.Quantity);
		}

		[Test]
		public void GetRaceStartingUnits_ForYssarilTribes_HasOneCruiser()
		{
			//Arrange
			var race = raceService.GetRace("Yssaril Tribes");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "Cruiser");
			Assert.AreEqual(1, unit.Quantity);
		}

		[Test]
		public void GetRaceStartingUnits_ForYssarilTribes_HasTwoFighters()
		{
			//Arrange
			var race = raceService.GetRace("Yssaril Tribes");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "Fighter");
			Assert.AreEqual(2, unit.Quantity);
		}

		[Test]
		public void GetRaceStartingUnits_ForClanOfSaar_ReturnsCorrectSetOfUnits()
		{
			//Arrange
			var race = raceService.GetRace("Clan of Saar");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var result = startingUnits.Sum(x => x.Quantity);
			Assert.AreEqual(10, result);
		}

		[Test]
		public void GetRaceStartingUnits_ForClanOfSaar_HasFourGF()
		{
			//Arrange
			var race = raceService.GetRace("Clan of Saar");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "Ground Force");
			Assert.AreEqual(4, unit.Quantity);
		}

		[Test]
		public void GetRaceStartingUnits_ForClanOfSaar_HasTwoCarriers()
		{
			//Arrange
			var race = raceService.GetRace("Clan of Saar");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "Carrier");
			Assert.AreEqual(2, unit.Quantity);
		}

		[Test]
		public void GetRaceStartingUnits_ForClanOfSaar_HasTwoFighters()
		{
			//Arrange
			var race = raceService.GetRace("Clan of Saar");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "Fighter");
			Assert.AreEqual(2, unit.Quantity);
		}

		[Test]
		public void GetRaceStartingUnits_ForClanOfSaar_HasOneCruiser()
		{
			//Arrange
			var race = raceService.GetRace("Clan of Saar");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "Cruiser");
			Assert.AreEqual(1, unit.Quantity);
		}

		[Test]
		public void GetRaceStartingUnits_ForClanOfSaar_HasOneSpaceDock()
		{
			//Arrange
			var race = raceService.GetRace("Clan of Saar");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "Space Dock");
			Assert.AreEqual(1, unit.Quantity);
		}

		[Test]
		public void GetRaceStartingUnits_ForEmbersOfMuaat_ReturnsCorrectSetOfUnits()
		{
			//Arrange
			var race = raceService.GetRace("Embers of Muaat");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var result = startingUnits.Sum(x => x.Quantity);
			Assert.AreEqual(8, result);
		}

		[Test]
		public void GetRaceStartingUnits_ForEmbersOfMuaat_HasFourGF()
		{
			//Arrange
			var race = raceService.GetRace("Embers of Muaat");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "Ground Force");
			Assert.AreEqual(4, unit.Quantity);
		}

		[Test]
		public void GetRaceStartingUnits_ForEmbersOfMuaat_HasTwoFighters()
		{
			//Arrange
			var race = raceService.GetRace("Embers of Muaat");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "Fighter");
			Assert.AreEqual(2, unit.Quantity);
		}

		[Test]
		public void GetRaceStartingUnits_ForEmbersOfMuaat_HasOneWarSun()
		{
			//Arrange
			var race = raceService.GetRace("Embers of Muaat");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "War Sun");
			Assert.AreEqual(1, unit.Quantity);
		}

		[Test]
		public void GetRaceStartingUnits_ForEmbersOfMuaat_HasOneSpaceDock()
		{
			//Arrange
			var race = raceService.GetRace("Embers of Muaat");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "Space Dock");
			Assert.AreEqual(1, unit.Quantity);
		}

		[Test]
		public void GetRaceStartingUnits_ForWinnu_ReturnsCorrectSetOfUnits()
		{
			//Arrange
			var race = raceService.GetRace("Winnu");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var result = startingUnits.Sum(x => x.Quantity);
			Assert.AreEqual(9, result);
		}

		[Test]
		public void GetRaceStartingUnits_ForWinnu_HasThreeGF()
		{
			//Arrange
			var race = raceService.GetRace("Winnu");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "Ground Force");
			Assert.AreEqual(3, unit.Quantity);
		}

		[Test]
		public void GetRaceStartingUnits_ForWinnu_HasOneCarrier()
		{
			//Arrange
			var race = raceService.GetRace("Winnu");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "Carrier");
			Assert.AreEqual(1, unit.Quantity);
		}

		[Test]
		public void GetRaceStartingUnits_ForWinnu_HasOneCruiser()
		{
			//Arrange
			var race = raceService.GetRace("Winnu");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "Cruiser");
			Assert.AreEqual(1, unit.Quantity);
		}

		[Test]
		public void GetRaceStartingUnits_ForWinnu_HasTwoFighters()
		{
			//Arrange
			var race = raceService.GetRace("Winnu");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "Fighter");
			Assert.AreEqual(2, unit.Quantity);
		}

		[Test]
		public void GetRaceStartingUnits_ForWinnu_HasOnePDS()
		{
			//Arrange
			var race = raceService.GetRace("Winnu");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "PDS");
			Assert.AreEqual(1, unit.Quantity);
		}

		[Test]
		public void GetRaceStartingUnits_ForWinnu_HasOneSpaceDock()
		{
			//Arrange
			var race = raceService.GetRace("Winnu");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "Space Dock");
			Assert.AreEqual(1, unit.Quantity);
		}

		[Test]
		public void GetRaceStartingUnits_ForYinBrotherhood_ReturnsCorrectSetOfUnits()
		{
			//Arrange
			var race = raceService.GetRace("Yin Brotherhood");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var result = startingUnits.Sum(x => x.Quantity);
			Assert.AreEqual(12, result);
		}

		[Test]
		public void GetRaceStartingUnits_ForYinBrotherhood_HasFourGF()
		{
			//Arrange
			var race = raceService.GetRace("Yin Brotherhood");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "Ground Force");
			Assert.AreEqual(4, unit.Quantity);
		}

		[Test]
		public void GetRaceStartingUnits_ForYinBrotherhood_HasTwoCarriers()
		{
			//Arrange
			var race = raceService.GetRace("Yin Brotherhood");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "Carrier");
			Assert.AreEqual(2, unit.Quantity);
		}

		[Test]
		public void GetRaceStartingUnits_ForYinBrotherhood_HasOneDestroyer()
		{
			//Arrange
			var race = raceService.GetRace("Yin Brotherhood");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "Destroyer");
			Assert.AreEqual(1, unit.Quantity);
		}

		[Test]
		public void GetRaceStartingUnits_ForYinBrotherhood_HasFourFighters()
		{
			//Arrange
			var race = raceService.GetRace("Yin Brotherhood");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "Fighter");
			Assert.AreEqual(4, unit.Quantity);
		}

		[Test]
		public void GetRaceStartingUnits_ForYinBrotherhood_HasOneSpaceDock()
		{
			//Arrange
			var race = raceService.GetRace("Yin Brotherhood");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "Space Dock");
			Assert.AreEqual(1, unit.Quantity);
		}

		[Test]
		public void GetRaceStartingUnits_ForArborec_ReturnsCorrectSetOfUnits()
		{
			//Arrange
			var race = raceService.GetRace("Arborec");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var result = startingUnits.Sum(x => x.Quantity);
			Assert.AreEqual(10, result);
		}

		[Test]
		public void GetRaceStartingUnits_ForArborec_HasFourGF()
		{
			//Arrange
			var race = raceService.GetRace("Arborec");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "Ground Force");
			Assert.AreEqual(4, unit.Quantity);
		}

		[Test]
		public void GetRaceStartingUnits_ForArborec_HasOneCruiser()
		{
			//Arrange
			var race = raceService.GetRace("Arborec");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "Cruiser");
			Assert.AreEqual(1, unit.Quantity);
		}

		[Test]
		public void GetRaceStartingUnits_ForArborec_HasOneCarrier()
		{
			//Arrange
			var race = raceService.GetRace("Arborec");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "Carrier");
			Assert.AreEqual(1, unit.Quantity);
		}

		[Test]
		public void GetRaceStartingUnits_ForArborec_HasTwoFighters()
		{
			//Arrange
			var race = raceService.GetRace("Arborec");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "Fighter");
			Assert.AreEqual(2, unit.Quantity);
		}

		[Test]
		public void GetRaceStartingUnits_ForArborec_HasOnePDS()
		{
			//Arrange
			var race = raceService.GetRace("Arborec");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "PDS");
			Assert.AreEqual(1, unit.Quantity);
		}

		[Test]
		public void GetRaceStartingUnits_ForArborec_HasOneSpaceDock()
		{
			//Arrange
			var race = raceService.GetRace("Arborec");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "Space Dock");
			Assert.AreEqual(1, unit.Quantity);
		}

		[Test]
		public void GetRaceStartingUnits_ForGhostsOfCreuss_ReturnsCorrectSetOfUnits()
		{
			//Arrange
			var race = raceService.GetRace("Ghosts of Creuss");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var result = startingUnits.Sum(x => x.Quantity);
			Assert.AreEqual(10, result);
		}

		[Test]
		public void GetRaceStartingUnits_ForGhostsOfCreuss_HasFourGF()
		{
			//Arrange
			var race = raceService.GetRace("Ghosts of Creuss");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "Ground Force");
			Assert.AreEqual(4, unit.Quantity);
		}

		[Test]
		public void GetRaceStartingUnits_ForGhostsOfCreuss_HasTwoDestroyers()
		{
			//Arrange
			var race = raceService.GetRace("Ghosts of Creuss");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "Destroyer");
			Assert.AreEqual(2, unit.Quantity);
		}

		[Test]
		public void GetRaceStartingUnits_ForGhostsOfCreuss_HasOneCarrier()
		{
			//Arrange
			var race = raceService.GetRace("Ghosts of Creuss");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "Carrier");
			Assert.AreEqual(1, unit.Quantity);
		}

		[Test]
		public void GetRaceStartingUnits_ForGhostsOfCreuss_HasTwoFighters()
		{
			//Arrange
			var race = raceService.GetRace("Ghosts of Creuss");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "Fighter");
			Assert.AreEqual(2, unit.Quantity);
		}

		[Test]
		public void GetRaceStartingUnits_ForGhostsOfCreuss_HasOneSpaceDock()
		{
			//Arrange
			var race = raceService.GetRace("Ghosts of Creuss");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "Space Dock");
			Assert.AreEqual(1, unit.Quantity);
		}

		[Test]
		public void GetRaceStartingUnits_ForNekroVirus_ReturnsCorrectSetOfUnits()
		{
			//Arrange
			var race = raceService.GetRace("Nekro Virus");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var result = startingUnits.Sum(x => x.Quantity);
			Assert.AreEqual(7, result);
		}

		[Test]
		public void GetRaceStartingUnits_ForNekroVirus_HasTwoGF()
		{
			//Arrange
			var race = raceService.GetRace("Nekro Virus");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "Ground Force");
			Assert.AreEqual(2, unit.Quantity);
		}

		[Test]
		public void GetRaceStartingUnits_ForNekroVirus_HasOneMech()
		{
			//Arrange
			var race = raceService.GetRace("Nekro Virus");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "Mechanized Unit");
			Assert.AreEqual(1, unit.Quantity);
		}

		[Test]
		public void GetRaceStartingUnits_ForNekroVirus_HasOneCarrier()
		{
			//Arrange
			var race = raceService.GetRace("Nekro Virus");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "Carrier");
			Assert.AreEqual(1, unit.Quantity);
		}

		[Test]
		public void GetRaceStartingUnits_ForNekroVirus_HasTwoCruisers()
		{
			//Arrange
			var race = raceService.GetRace("Nekro Virus");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "Cruiser");
			Assert.AreEqual(2, unit.Quantity);
		}

		[Test]
		public void GetRaceStartingUnits_ForNekroVirus_HasOneSpaceDock()
		{
			//Arrange
			var race = raceService.GetRace("Nekro Virus");
			//Act
			var startingUnits = raceService.GetStartingUnits(race);
			var unit = startingUnits.Find(x => x.Name == "Space Dock");
			Assert.AreEqual(1, unit.Quantity);
		}
    }
}
