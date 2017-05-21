using System;
using System.Collections.Generic;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;
using TwilightImperiumMasterCompanion.Core.Services.Interfaces;

namespace TwilightImperiumMasterCompanion.Core
{
	public class ConfirmRaceViewModel : BaseViewModel<SelectedRaceNavigationParameter>
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

		public ICommand NavigateToRaceView
		{
            get { return new MvxCommand(() => 
            { 
                sessionService.SetSelectedRace(SelectedRace);
                ShowViewModel<RaceTabViewModel>(); 
            }); }
		}

		private readonly IMvxMessenger messenger;
		private readonly IRaceAbilityService raceAbilityService;
        private readonly ISessionService sessionService;

        public ConfirmRaceViewModel(IMvxMessenger messenger, IRaceAbilityService raceAbilityService, ISessionService sessionService)
		{
            this.sessionService = sessionService;
            this.raceAbilityService = raceAbilityService;
			this.messenger = messenger;
		}

		protected override void RealInit(SelectedRaceNavigationParameter parameter)
		{
			SelectedRace = parameter.SelectedRace;
			RaceAbilities = raceAbilityService.GetRaceAbility(parameter.SelectedRace);
		}
	}
}
