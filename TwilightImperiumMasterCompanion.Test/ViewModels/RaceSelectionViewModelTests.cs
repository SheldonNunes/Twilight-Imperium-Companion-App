using System;
using TwilightImperiumMasterCompanion.Core;
using Xunit;

namespace TwilightImperiumMasterCompanion.Test
{
	public class RaceSelectionViewModelTests
	{
		[Fact]
		public void LoadFromBaceRaces_LoadsCorrectly()
		{
			//Arrange
			IRaceRepository repository = new RaceRepository();
			var races = repository.GetRaces();

			//Act
			var raceSelectionViewModel = new RaceSelectionViewModel(repository);

			//Assert
			Assert.Equal(races, raceSelectionViewModel.Races);
		}

	}
}
