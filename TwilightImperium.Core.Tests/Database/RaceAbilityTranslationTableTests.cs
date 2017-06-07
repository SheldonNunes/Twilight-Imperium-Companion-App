using System.Collections.Generic;
using MvvmCross.Platform;
using MvvmCross.Test.Core;
using NUnit.Framework;
using SQLite.Net;
using TwilightImperium.Core.Tests.Services;
using TwilightImperiumMasterCompanion.Core;
namespace TwilightImperium.Core.Tests.Database
{
	[TestFixture]
	public class RaceAbilityTranslationTableTests : MvxIoCSupportingTest
	{
		private SQLiteConnection databaseConnection;
		private List<SQLiteConnection.ColumnInfo> raceLeaderColumnInfo;

		[SetUp]
		public void Init()
		{
			base.ClearAll();
			Ioc.RegisterSingleton<ISQLite>(new CoreSqliteService());
			databaseConnection = Mvx.Resolve<ISQLite>().GetConnection();

			raceLeaderColumnInfo = databaseConnection.GetTableInfo("RaceAbilityTranslation");
		}

		[Test]
		public void RaceAbilityTranslation_Has_IDColumn()
		{
			//Act
			var result = raceLeaderColumnInfo.Find(x => x.Name == "ID");
			//Assert
			Assert.IsNotNull(result);
		}

		[Test]
		public void RaceAbilityTranslation_Has_RaceIDColumn()
		{
			//Act
			var result = raceLeaderColumnInfo.Find(x => x.Name == "RaceID");
			//Assert
			Assert.IsNotNull(result);
		}

		[Test]
		public void RaceAbilityTranslation_Has_LanguageColumn()
		{
			//Act
			var result = raceLeaderColumnInfo.Find(x => x.Name == "Language");
			//Assert
			Assert.IsNotNull(result);
		}

		[Test]
		public void RaceAbilityTranslation_Has_DescriptionColumn()
		{
			//Act
			var result = raceLeaderColumnInfo.Find(x => x.Name == "Description");
			//Assert
			Assert.IsNotNull(result);
		}


		[Test]
		public void RaceAbilityTranslation_Has_OnlyFourColumns()
		{
			//Act
			var result = raceLeaderColumnInfo;
			//Assert
			Assert.AreEqual(4, result.Count);
		}
	}
}
