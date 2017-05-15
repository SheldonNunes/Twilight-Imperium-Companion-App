using System.Windows.Input;
using MvvmCross.Core.ViewModels;

namespace TwilightImperiumMasterCompanion.Core
{
	public class RaceTabViewModel : BaseViewModel
	{
		public readonly IRaceOverviewViewModel RaceOverviewViewModel;
		public readonly IRaceLeadersViewModel RaceLeadersViewModel;
		public readonly IRaceSetupViewModel RaceSetupViewModel;

		public ICommand ShowHexMainMenu
		{
			get { return new MvxCommand(() => ShowViewModel<HexMainMenuViewModel>(new NavigationParameters() { CurrentMenu = MenuPageType.Race })); }
		}


		public RaceTabViewModel(
			IRaceOverviewViewModel raceOverviewViewModel,
			IRaceLeadersViewModel raceLeadersViewModel,
			IRaceSetupViewModel raceSetupViewModel)
		{
			RaceOverviewViewModel = raceOverviewViewModel;
			RaceLeadersViewModel = raceLeadersViewModel;
			RaceSetupViewModel = raceSetupViewModel;
		}
	}
}
