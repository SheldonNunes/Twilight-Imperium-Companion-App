using System;
using Xunit;
using TwilightImperiumMasterCompanion;

namespace TwilightImperiumMasterCompanionTests
{
	public class ShipTests
	{
		public static readonly string SHIP_COST = "Mecatol Rex";
		public static readonly int SHIP_MOVEMENT = 3;
		public static readonly int SHIP_BATTLE = 6;

		[Fact]
		public void ShipHasExpectedValueOnCreation(){
			Ship ship = new Ship (SHIP_COST, SHIP_MOVEMENT, SHIP_BATTLE, 1);
			Assert.NotNull (ship);
		}
	}
}

