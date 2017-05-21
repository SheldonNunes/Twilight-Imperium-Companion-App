using System;
using System.Collections.Generic;
using MvvmCross.Core.ViewModels;
using TwilightImperiumMasterCompanion.Core.Services.Interfaces;

namespace TwilightImperiumMasterCompanion.Core
{
	public class RaceSetupViewModel : MvxViewModel, IRaceSetupViewModel
	{
        private IEnumerable<Planet> _startingPlanets;
        public IEnumerable<Planet> StartingPlanets
		{
			get { return _startingPlanets; }
			set
			{
				_startingPlanets = value;
				RaisePropertyChanged(() => StartingPlanets);
			}
		}

        public RaceSetupViewModel(IRaceService raceService, ISessionService sessionService)
		{
            var selectedRace = sessionService.GetSelectedRace();
            var startingPlanets = raceService.GetStartingPlanets(selectedRace);
            StartingPlanets = startingPlanets;
		}
	}
}
