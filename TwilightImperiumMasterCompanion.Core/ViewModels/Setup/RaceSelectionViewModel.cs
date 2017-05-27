using System.Collections.Generic;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using TwilightImperiumMasterCompanion.Core.Resources;

namespace TwilightImperiumMasterCompanion.Core
{
    public class RaceSelectionViewModel : BaseViewModel
	{
		public string Title
		{
			get { return UIStrings.RaceSelection; }
		}


		private IEnumerable<Race> _races;
		public IEnumerable<Race> Races
		{
			get { return _races; }
			set
			{
				_races = value;
				RaisePropertyChanged(() => Races);
			}
		}

		public ICommand RaceSelected
		{
			get
			{
				return new MvxCommand<Race>((race) =>
				{
					ShowViewModel<ConfirmRaceViewModel, SelectedRaceNavigationParameter>(new SelectedRaceNavigationParameter() { SelectedRace = race });
				});
			}
		}

		private readonly IRaceService raceService;
		private readonly IRaceAbilityService raceAbilityService;

		public RaceSelectionViewModel(IRaceService raceService, IRaceAbilityService raceAbilityService)
		{
			this.raceService = raceService;
			this.raceAbilityService = raceAbilityService;

			Races = raceService.GetRaces();
		}
	}
}
