namespace TwilightImperiumMasterCompanion.Core
{
	public class RaceTabViewModel : BaseViewModel
	{
		public readonly IRaceOverviewViewModel RaceOverviewViewModel;
		public readonly IRaceLeadersViewModel RaceLeadersViewModel;
		public readonly IRaceSetupViewModel RaceSetupViewModel;


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
