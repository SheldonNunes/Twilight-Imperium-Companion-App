using System;
using System.Windows.Input;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;

namespace TwilightImperiumMasterCompanion.Core.ViewModels.Race
{
    public class RaceViewModel : MvxViewModel
    {
        private IMvxAsyncCommand showHexMainMenu;
		public IMvxAsyncCommand ShowHexMainMenu
		{
			get
			{
                showHexMainMenu = showHexMainMenu ?? new MvxAsyncCommand(() => navigationService.Navigate<HexMainMenuViewModel, NavigationParameters>(new NavigationParameters() { CurrentMenu = MenuPageType.Race }));
				return showHexMainMenu;
			}
		}

        private readonly IMvxNavigationService navigationService;
        public RaceViewModel(IMvxNavigationService navigationService)
        {
            this.navigationService = navigationService;
        }
    }
}
