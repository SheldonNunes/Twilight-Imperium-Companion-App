using System.Collections.Generic;
using System.Windows.Input;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using TwilightImperiumMasterCompanion.Core.Dto;
using TwilightImperiumMasterCompanion.Core.Model;
using TwilightImperiumMasterCompanion.Core.Resources;
using TwilightImperiumMasterCompanion.Core.Services.Interfaces;
using TwilightImperiumMasterCompanion.Core.ViewModels.Race;

namespace TwilightImperiumMasterCompanion.Core
{
    public class RaceSetupViewModel : RaceViewModel, IRaceSetupViewModel
	{
		public static string Title
		{
			get { return UIStrings.Setup; }
		}

        private IEnumerable<StartingPlanetDto> _startingPlanets;
        public IEnumerable<StartingPlanetDto> StartingPlanets
		{
			get { return _startingPlanets; }
			set
			{
				_startingPlanets = value;
				RaisePropertyChanged(() => StartingPlanets);
			}
		}

		private IEnumerable<StartingUnitDto> _startingUnits;
		public IEnumerable<StartingUnitDto> StartingUnits
		{
            get { return _startingUnits; }
			set
			{
                _startingUnits = value;
                RaisePropertyChanged(() => StartingUnits);
			}
		}

		private IEnumerable<Technology> _startingTechnology;
		public IEnumerable<Technology> StartingTechnology
		{
			get { return _startingTechnology; }
			set
			{
				_startingTechnology = value;
				RaisePropertyChanged(() => StartingTechnology);
			}
		}

        public RaceSetupViewModel(IMvxNavigationService navigationService, IRaceService raceService, ISessionService sessionService)
        :base(navigationService)
		{
            var selectedRace = sessionService.GetSelectedRace();

            var startingPlanets = raceService.GetStartingPlanets(selectedRace);
            StartingPlanets = startingPlanets;

            var startingTechnology = raceService.GetStartingTechnology(selectedRace);
            StartingTechnology = startingTechnology;

            var startingUnits = raceService.GetStartingUnits(selectedRace);
            StartingUnits = startingUnits;
		}
	}
}
