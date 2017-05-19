//using System;
//using MvvmCross.Platform;
//using MvvmCross.Test.Core;
//using NUnit.Framework;
//using SQLite.Net;
//using TwilightImperiumMasterCompanion.Core;
//using TwilightImperiumMasterCompanion.Core.DataAccess;
//using TwilightImperiumMasterCompanion.Core.DataAccess.Interfaces;
//using TwilightImperiumMasterCompanion.Core.Enum;
//using TwilightImperiumMasterCompanion.Core.Model;
//using TwilightImperiumMasterCompanion.Core.Services.Interfaces;

//namespace TwilightImperium.Core.Tests.Services
//{
//	[TestFixture]
//	public class RaceDataAccessTests : MvxIoCSupportingTest
//	{
//		private IRaceService raceService;
//		private ISessionService sessionService;
//		private SQLiteConnection databaseConnection;

//		[SetUp]
//		public void Init()
//		{
//			base.ClearAll();

//			Ioc.RegisterSingleton<ISQLite>(new CoreSqliteService());
//			Ioc.RegisterType<IRaceService, RaceService>();
//			Ioc.RegisterType<ISessionService, SessionService>();
//			Ioc.RegisterType<IRaceDataAccess, RaceDataAccess>();
//			Ioc.RegisterType<ISessionDataAccess, SessionDataAccess>();
//			databaseConnection = Mvx.Resolve<ISQLite>().GetConnection();
//			databaseConnection.BeginTransaction();
//			raceService = Mvx.Resolve<IRaceService>();
//			sessionService = Mvx.Resolve<ISessionService>();
//		}

//		[TearDown]
//		public void TearDown()
//		{
//			databaseConnection.Rollback();
//		}

//		[Test]
//		public void GetRaces_WhenExpansionsSetToFalse_ReturnsDefaultSetOfRaces()
//		{
//			//Act
//			var races = databaseConnection.Query<Race>("SELECT * FROM Race");
//			//Assert
//			Assert.AreEqual(10, races.Count);
//		}

//		[Test]
//		public void GetRaces_WhenShatteredEmpireExpansionTrueAndOtherToToFalse_ReturnsCorrectSetOfRaces()
//		{
//			//Arrange
//			sessionService.SaveExpansion(Expansion.ShatteredEmpire, true);
//			//Act
//			var races = databaseConnection.Query<Race>("SELECT * FROM Race");
//			//Assert
//			Assert.AreEqual(10, races.Count);
//		}

//		[Test]
//		public void GetRaces_WhenShardsOfTheThroneExpansionTrueAndOtherToToFalse_ReturnsCorrectSetOfRaces()
//		{
//			//Arrange
//			sessionService.SaveExpansion(Expansion.ShardsOfTheThrone, true);
//			//Act
//			var races = databaseConnection.Query<Race>("SELECT * FROM Race");
//			//Assert
//			Assert.AreEqual(10, races.Count);
//		}

//		[Test]
//		public void GetRaces_WhenAllExpansionsTrue_ReturnsCorrectSetOfRaces()
//		{
//			//Arrange
//			sessionService.SaveExpansion(Expansion.ShatteredEmpire, true);
//			sessionService.SaveExpansion(Expansion.ShardsOfTheThrone, true);
//			//Act
//			var races = databaseConnection.Query<Race>("SELECT * FROM Race");
//			//Assert
//			Assert.AreEqual(17, races.Count);
//		}
//	}
//}
