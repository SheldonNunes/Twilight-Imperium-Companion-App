using System.Windows.Input;
using MvvmCross.Core.ViewModels;

namespace TwilightImperiumMasterCompanion.Core
{
	public class RaceSelectionViewModel : BaseViewModel<ExpansionsNavigationParameter>
	{
		public IRaceRepository RaceRepository
		{
			get;
			private set;
		}

		public ICommand NavigateToRaceView
		{
			get { return new MvxCommand(() => ShowViewModel<UnitTabBarViewModel>()); }
		}

		protected override void RealInit(ExpansionsNavigationParameter parameter)
		{
			RaceRepository = new RaceRepository();
			if (parameter.ShardsofTheThroneExpansionEnabled)
			{
				RaceRepository = new ShardsOfTheThroneRaceRepository(RaceRepository);
			}

			if (parameter.ShatteredEmpiresExpansionEnabled)
			{
				RaceRepository = new ShatteredEmpiresRaceRepository(RaceRepository);
			}
		}
	}
}
