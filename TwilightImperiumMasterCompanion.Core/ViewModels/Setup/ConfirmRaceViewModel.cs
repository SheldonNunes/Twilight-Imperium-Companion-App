using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using TwilightImperiumMasterCompanion.Core.Services.Interfaces;

namespace TwilightImperiumMasterCompanion.Core
{
    public class ConfirmRaceViewModel : MvxViewModel<SelectedRaceNavigationParameter>
	{
		public string Title
		{
			get { return String.Empty; }
		}

		private Race selectedRace;
		public Race SelectedRace
		{
			get { return selectedRace; }
			set
			{
				selectedRace = value;
				RaisePropertyChanged(() => SelectedRace);
			}
		}

		private List<RaceAbility> raceAbilities;
		public List<RaceAbility> RaceAbilities
		{
			get { return raceAbilities; }
			set
			{
				raceAbilities = value;
				RaisePropertyChanged(() => RaceAbilities);
			}
		}

		private IMvxAsyncCommand _navigateToRaceView;
		public IMvxAsyncCommand NavigateToRaceView
		{
			get
			{
                _navigateToRaceView = _navigateToRaceView ?? new MvxAsyncCommand(() =>
                {
                    return Task.Run(() =>
                    {
                        sessionService.SetSelectedRace(SelectedRace);
                        navigationService.Navigate<RaceTabViewModel>();
                    });
                });
				return _navigateToRaceView;
			}
		}

		private readonly IRaceAbilityService raceAbilityService;
        private readonly ISessionService sessionService;
        private readonly IMvxNavigationService navigationService;

        public ConfirmRaceViewModel(IMvxNavigationService navigationService, IRaceAbilityService raceAbilityService, ISessionService sessionService)
		{
            this.navigationService = navigationService;
            this.sessionService = sessionService;
            this.raceAbilityService = raceAbilityService;
		}

        public override Task Initialize(SelectedRaceNavigationParameter parameter)
        {
            return Task.Run(() =>
            {
                SelectedRace = parameter.SelectedRace;
                RaceAbilities = raceAbilityService.GetRaceAbility(parameter.SelectedRace);
            });
        }
	}
}
