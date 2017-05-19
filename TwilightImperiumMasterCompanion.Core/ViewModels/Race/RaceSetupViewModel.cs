using System;
using System.Collections.Generic;
using MvvmCross.Core.ViewModels;

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

		public RaceSetupViewModel()
		{
            StartingPlanets = new List<Planet>(){
                new Planet(), new Planet(), new Planet()
            };
		}
	}
}
