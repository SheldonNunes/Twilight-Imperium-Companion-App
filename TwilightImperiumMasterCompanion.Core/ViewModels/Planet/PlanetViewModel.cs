using System.Collections.Generic;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using TwilightImperiumMasterCompanion.Core.Resources;
using TwilightImperiumMasterCompanion.Core.Services.Interfaces;

namespace TwilightImperiumMasterCompanion.Core.ViewModels
{
    public class PlanetViewModel : MvxViewModel
    {
		public static string Title
		{
            get { return UIStrings.Planets; }
		}

		private IMvxAsyncCommand showHexMainMenu;
		public IMvxAsyncCommand ShowHexMainMenu
		{
			get
			{
                showHexMainMenu = showHexMainMenu ?? new MvxAsyncCommand(() => navigationService.Navigate<HexMainMenuViewModel, MenuNavigationParameters>(new MenuNavigationParameters() { CurrentMenu = MenuPageType.Planet }));
				return showHexMainMenu;
			}
		}

		private IMvxAsyncCommand navigateToAddPlanetView;
		public IMvxAsyncCommand NavigateToAddPlanetView
		{
			get
			{
				navigateToAddPlanetView = navigateToAddPlanetView ?? new MvxAsyncCommand(() => navigationService.Navigate<AddPlanetViewModel>());
				return navigateToAddPlanetView;
			}
		}

		private List<Planet> _playerPlanets;
		public List<Planet> PlayerPlanets
		{
			get { return _playerPlanets; }
			set
			{
				_playerPlanets = value;
				RaisePropertyChanged(() => PlayerPlanets);
			}
		}

		private readonly IMvxNavigationService navigationService;
        public PlanetViewModel(IMvxNavigationService navigationService, ISessionService sessionService)
		{
			this.navigationService = navigationService;

            PlayerPlanets = sessionService.GetSessionPlanets();
        }
    }
}
