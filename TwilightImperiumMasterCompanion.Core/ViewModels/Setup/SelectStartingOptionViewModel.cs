using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using TwilightImperiumMasterCompanion.Core.Enum;
using TwilightImperiumMasterCompanion.Core.Resources;
using TwilightImperiumMasterCompanion.Core.Services.Interfaces;

namespace TwilightImperiumMasterCompanion.Core
{
    public class SelectStartingOptionViewModel : MvxViewModel
	{
        private readonly ISessionService playerService;

        private IMvxAsyncCommand navigateToRaceSelectionView;
		public IMvxAsyncCommand NavigateToRaceSelectionView
		{
			get
			{
                navigateToRaceSelectionView = navigateToRaceSelectionView ?? new MvxAsyncCommand(() => 
                {
                    return Task.Run(() => {
                        SaveExpansionSelection();
                        navigationService.Navigate<RaceSelectionViewModel>(); 
                    });


                });
				return navigateToRaceSelectionView;
			}
		}

		public bool ShatteredEmpiresExpansionEnabled
		{
            get;
            set;
		}

		public bool ShardsOfTheThroneExpansionEnabled
		{
            get;
            set;
		}

		public string Title
		{
			get { return UIStrings.TwilightImperiumCompanion; }
		}

        private readonly IMvxNavigationService navigationService;

        public SelectStartingOptionViewModel(IMvxNavigationService navigationService, ISessionService playerService) : base()
		{
            this.navigationService = navigationService;
            this.playerService = playerService;

		}

        private void SaveExpansionSelection(){
            playerService.SaveExpansion(Expansion.ShatteredEmpire, ShatteredEmpiresExpansionEnabled);
            playerService.SaveExpansion(Expansion.ShardsOfTheThrone, ShardsOfTheThroneExpansionEnabled);
        }
	}
}
