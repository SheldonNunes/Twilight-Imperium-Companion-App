using System;
using Xunit;
using TwilightImperiumMasterCompanion;

namespace TwilightImperiumMasterCompanionTests
{
	public class PlanetTests
	{
		public static readonly string PLANET_NAME = "Mecatol Rex";
		public static readonly string PLANET_DESCRIPTION = "Mecatol Rex is a pretty cool planet";
		public static readonly int RESOURCE_VALUE = 3;
		public static readonly int INFLUENCE_VALUE = 6;


		[Fact]
		public void PlanetHasExpectedValuesOnCreation(){
			//Arrange
			Planet planet = new Planet(PLANET_NAME, PLANET_DESCRIPTION, RESOURCE_VALUE, INFLUENCE_VALUE);
			//Assert
			Assert.NotNull (planet);
			Assert.Equal (PLANET_NAME, planet.PlanetName);
		}
	}
}

