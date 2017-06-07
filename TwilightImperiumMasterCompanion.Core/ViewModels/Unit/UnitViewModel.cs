using System;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;

namespace TwilightImperiumMasterCompanion.Core.ViewModels.Unit
{
    public class UnitViewModel : MvxViewModel
    {
		private IMvxAsyncCommand showHexMainMenu;
		public IMvxAsyncCommand ShowHexMainMenu
		{
			get
			{
                showHexMainMenu = showHexMainMenu ?? new MvxAsyncCommand(() => navigationService.Navigate<HexMainMenuViewModel, MenuNavigationParameters>(new MenuNavigationParameters() { CurrentMenu = MenuPageType.Ship }));
				return showHexMainMenu;
			}
		}

		private readonly IMvxNavigationService navigationService;
		public UnitViewModel(IMvxNavigationService navigationService)
		{
			this.navigationService = navigationService;
		}
    }
}
