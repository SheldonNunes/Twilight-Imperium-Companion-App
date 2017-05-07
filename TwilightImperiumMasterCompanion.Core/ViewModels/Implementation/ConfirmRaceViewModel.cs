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

		public ICommand NavigateToRaceSelection
		{
			get { return new MvxCommand(() => ShowViewModel<RaceSelectionViewModel, ExpansionsNavigationParameter>(parameter)); }
		}

		public ICommand NavigateToRaceView
		{
			get { return new MvxCommand(() => ShowViewModel<UnitTabBarViewModel>()); }
		}

		public ConfirmRaceViewModel(IMvxMessenger messenger)
		{
			this.messenger = messenger;
			messageSubscriberToken = messenger.Subscribe<RaceSelectedMessage>(RaceSelected);
		}

		protected override void RealInit(ExpansionsNavigationParameter parameter)
		{
			this.parameter = parameter;
		}

		private void RaceSelected(RaceSelectedMessage message)
		{
			this.SelectedRace = message.SelectedRace;
		}


	}
}
