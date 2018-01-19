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
	public class LeaderAbilityTranslationTableTests : MvxIoCSupportingTest
	{
		private SQLiteConnection databaseConnection;
		private List<SQLiteConnection.ColumnInfo> leaderAbilityTranslationTableInfo;

		[SetUp]
		public void Init()
		{
			base.ClearAll();
			Ioc.RegisterSingleton<ISQLite>(new TestSqliteService());
			databaseConnection = Mvx.Resolve<ISQLite>().GetConnection();

            leaderAbilityTranslationTableInfo = databaseConnection.GetTableInfo("LeaderAbilityTranslation");
		}

		[Test]
		public void LeaderAbilityTranslation_Has_IDColumn()
		{
			//Act
			var result = leaderAbilityTranslationTableInfo.Find(x => x.Name == "ID");
			//Assert
			Assert.IsNotNull(result);
		}

		[Test]
		public void LeaderAbilityTranslation_Has_LeaderIDColumn()
		{
			//Act
			var result = leaderAbilityTranslationTableInfo.Find(x => x.Name == "LeaderID");
			//Assert
			Assert.IsNotNull(result);
		}

		[Test]
		public void LeaderAbilityTranslation_Has_LanguageColumn()
		{
			//Act
			var result = leaderAbilityTranslationTableInfo.Find(x => x.Name == "Language");
			//Assert
			Assert.IsNotNull(result);
		}

		[Test]
		public void LeaderAbilityTranslation_Has_DescriptionColumn()
		{
			//Act
			var result = leaderAbilityTranslationTableInfo.Find(x => x.Name == "Description");
			//Assert
			Assert.IsNotNull(result);
		}


		[Test]
		public void LeaderAbilityTranslation_Has_OnlyFourColumns()
		{
			//Act
			var result = leaderAbilityTranslationTableInfo;
			//Assert
			Assert.AreEqual(4, result.Count);
		}
	}
}
