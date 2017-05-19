using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using TwilightImperiumMasterCompanion.Core.Enum;
using TwilightImperiumMasterCompanion.Core.Resources;
using TwilightImperiumMasterCompanion.Core.Services.Interfaces;

namespace TwilightImperiumMasterCompanion.Core
{
	public class SelectStartingOptionViewModel : BaseViewModel
	{
        private readonly ISessionService playerService;

        public ICommand NavigateToRaceSelectionView
		{
			get
			{
                return new MvxCommand(
                    () =>
                    {
                        SaveExpansionSelection();
                        ShowViewModel<RaceSelectionViewModel>();
                    });
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

		public SelectStartingOptionViewModel(ISessionService playerService) : base()
		{
            this.playerService = playerService;

		}

        private void SaveExpansionSelection(){
            playerService.SaveExpansion(Expansion.ShatteredEmpire, ShatteredEmpiresExpansionEnabled);
            playerService.SaveExpansion(Expansion.ShardsOfTheThrone, ShardsOfTheThroneExpansionEnabled);
        }
	}
}
