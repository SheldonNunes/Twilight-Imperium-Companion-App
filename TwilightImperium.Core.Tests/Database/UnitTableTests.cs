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
	public class UnitTableTests : MvxIoCSupportingTest
	{
		private SQLiteConnection databaseConnection;
		private List<SQLiteConnection.ColumnInfo> unitTableInfo;

		[SetUp]
		public void init()
		{
			base.ClearAll();
			Ioc.RegisterSingleton<ISQLite>(new CoreSqliteService());
			databaseConnection = Mvx.Resolve<ISQLite>().GetConnection();
			unitTableInfo = databaseConnection.GetTableInfo("Unit");
		}

		[Test]
		public void UnitTable_Has_UnitIDColumn()
		{
			//Act
            var result = unitTableInfo.Find(x => x.Name == "UnitID");
			//Assert
			Assert.IsNotNull(result);
		}

		[Test]
		public void UnitTable_Has_NameColumn()
		{
			//Act
			var result = unitTableInfo.Find(x => x.Name == "Name");
			//Assert
			Assert.IsNotNull(result);
		}

		[Test]
		public void UnitTable_Has_MovementColumn()
		{
			//Act
			var result = unitTableInfo.Find(x => x.Name == "Movement");
			//Assert
			Assert.IsNotNull(result);
		}

		[Test]
		public void UnitTable_Has_CostColumn()
		{
			//Act
			var result = unitTableInfo.Find(x => x.Name == "Cost");
			//Assert
			Assert.IsNotNull(result);
		}

		[Test]
		public void UnitTable_Has_BattleColumn()
		{
			//Act
			var result = unitTableInfo.Find(x => x.Name == "Battle");
			//Assert
			Assert.IsNotNull(result);
		}

		[Test]
		public void UnitTable_Has_CapacityColumn()
		{
			//Act
			var result = unitTableInfo.Find(x => x.Name == "Capacity");
			//Assert
			Assert.IsNotNull(result);
		}

		[Test]
		public void UnitTable_Has_ExpansionColumn()
		{
			//Act
			var result = unitTableInfo.Find(x => x.Name == "Expansion");
			//Assert
			Assert.IsNotNull(result);
		}

		[Test]
		public void UnitTable_Has_OnlySevenColumns()
		{
			//Act
            var result = unitTableInfo;
			//Assert
			Assert.AreEqual(7, result.Count);
		}
	}
}
