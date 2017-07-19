using System.Collections.Generic;
using System.Threading.Tasks;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using TwilightImperiumMasterCompanion.Core.ViewModels;
using TwilightImperiumMasterCompanion.Core.ViewModels.Rules;

namespace TwilightImperiumMasterCompanion.Core
{
    public class HexMainMenuViewModel : MvxViewModel<MenuNavigationParameters>
	{
		private MenuPageType selectedMenu;
		public MenuPageType SelectedMenu
		{
			get { return selectedMenu; }
			set
			{
				selectedMenu = value;
				RaisePropertyChanged(() => SelectedMenu);
			}
		}

		private List<string> menuItems;
		public List<string> MenuItems
		{
			get { return menuItems; }
			set
			{
				menuItems = value;
				RaisePropertyChanged(() => MenuItems);
			}
		}

		private MvxCommand closeMenu;
		public MvxCommand CloseMenu
		{
			get
			{
				closeMenu = closeMenu ?? new MvxCommand(() =>navigationService.Close(this));
				return closeMenu;
			}
		}

        private MvxCommand navigateToUnitView;
		public MvxCommand NavigateToUnitView
		{
			get
			{
                navigateToUnitView = navigateToUnitView ?? new MvxCommand(() =>
                {
                    navigationService.Navigate<UnitTabBarViewModel>();
                    navigationService.Close(this);
                });
				return navigateToUnitView;
			}
		}

		private MvxCommand navigateToRaceView;
		public MvxCommand NavigateToRaceView
		{
			get
			{
				navigateToRaceView = navigateToRaceView ?? new MvxCommand(() =>
				{
                    navigationService.Navigate<RaceTabViewModel>();
					navigationService.Close(this);
				});
				return navigateToRaceView;
			}
		}

		private MvxCommand navigateToRulesView;
		public MvxCommand NavigateToRulesView
		{
			get
			{
				navigateToRulesView = navigateToRulesView ?? new MvxCommand(() =>
				{
					navigationService.Navigate<RulesTableViewModel>();
					navigationService.Close(this);
				});
				return navigateToRulesView;
			}
		}

		private MvxCommand navigateToPlanetsView;
		public MvxCommand NavigateToPlanetsView
		{
			get
			{
				navigateToPlanetsView = navigateToPlanetsView ?? new MvxCommand(() =>
				{
					navigationService.Navigate<PlanetViewModel>();
					navigationService.Close(this);
				});
				return navigateToPlanetsView;
			}
		}

		//private MvxBundle presentationBundle;
        private readonly IMvxNavigationService navigationService;

		public HexMainMenuViewModel(IMvxNavigationService navigationService)
		{
            this.navigationService = navigationService;
			//this.presentationBundle = new MvxBundle(new Dictionary<string, string>() { { "AnimateNavigation", "true" } });
			menuItems = new List<string>()
			{
				"Rules",
                "Race",
                "Units",
                "Planets",
                "Research",
                "Galaxy"
			};
		}

        public override Task Initialize(MenuNavigationParameters parameter)
        {
            return Task.Run(() =>
            {
                SelectedMenu = parameter.CurrentMenu;
            });
        }
	}
}
