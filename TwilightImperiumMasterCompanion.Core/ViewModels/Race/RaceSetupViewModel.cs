using System.Collections.Generic;
using MvvmCross.Core.ViewModels;
using TwilightImperiumMasterCompanion.Core.Dto;
using TwilightImperiumMasterCompanion.Core.Model;
using TwilightImperiumMasterCompanion.Core.Services.Interfaces;

namespace TwilightImperiumMasterCompanion.Core
{
    public class RaceSetupViewModel : MvxViewModel, IRaceSetupViewModel
	{
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

        public RaceSetupViewModel(IRaceService raceService, ISessionService sessionService)
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
