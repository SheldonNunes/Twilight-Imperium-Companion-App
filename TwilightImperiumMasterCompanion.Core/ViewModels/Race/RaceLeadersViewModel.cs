using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using TwilightImperiumMasterCompanion.Core.Resources;
using TwilightImperiumMasterCompanion.Core.ViewModels.Race;

namespace TwilightImperiumMasterCompanion.Core
{
    public class RaceLeadersViewModel : RaceViewModel, IRaceLeadersViewModel
	{
		public static string Title
		{
			get { return UIStrings.Leaders; }
		}

        public RaceLeadersViewModel(IMvxNavigationService navigationService) : base(navigationService)
		{
		}
	}
}
