using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using TwilightImperiumMasterCompanion.Core.Resources;
using TwilightImperiumMasterCompanion.Core.ViewModels.Race;

namespace TwilightImperiumMasterCompanion.Core
{
    public class RaceOverviewViewModel : RaceViewModel, IRaceOverviewViewModel
	{
		public static string Title
		{
			get { return UIStrings.Overview; }
		}

        public RaceOverviewViewModel(IMvxNavigationService navigationService) : base(navigationService)
		{
		}
	}
}
