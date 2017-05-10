using System.Collections.Generic;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;

namespace TwilightImperiumMasterCompanion.Core
{
	public class ConfirmRaceViewModel : BaseViewModel<ExpansionsNavigationParameter>
	{
		private readonly IMvxMessenger messenger;
		private MvxSubscriptionToken messageSubscriberToken;
		private ExpansionsNavigationParameter parameter;

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

		public ICommand NavigateToRaceSelection
		{
			get { return new MvxCommand(() => ShowViewModel<RaceSelectionViewModel, ExpansionsNavigationParameter>(parameter)); }
		}

		public ICommand NavigateToRaceView
		{
			get { return new MvxCommand(() => ShowViewModel<UnitTabBarViewModel>()); }
		}

		readonly IRaceAbilityService raceAbilityService;

		public ConfirmRaceViewModel(IMvxMessenger messenger, IRaceAbilityService raceAbilityService)
		{
			this.raceAbilityService = raceAbilityService;
			this.messenger = messenger;
			messageSubscriberToken = messenger.Subscribe<RaceSelectedMessage>(RaceSelected);
		}

		protected override void RealInit(ExpansionsNavigationParameter parameter)
		{
			this.parameter = parameter;
			BaseService.ShatteredEmpiresExpansionEnabled = parameter.ShatteredEmpiresExpansionEnabled;
			BaseService.ShardsOfTheThroneExpansionEnabled = parameter.ShardsofTheThroneExpansionEnabled;
		}

		private void RaceSelected(RaceSelectedMessage message)
		{
			this.SelectedRace = message.SelectedRace;
			this.RaceAbilities = raceAbilityService.GetRaceAbility(message.SelectedRace);
		}


	}
}
