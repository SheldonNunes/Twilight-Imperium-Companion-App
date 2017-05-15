using System;
using System.Collections.Generic;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;

namespace TwilightImperiumMasterCompanion.Core
{
	public class HexMainMenuViewModel : BaseViewModel
	{
		private MvxBundle presentationBundle;

		public ICommand CloseMenu
		{
			get { return new MvxCommand(() => Close(this)); }
		}

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

		public ICommand NavigateToUnitView
		{
			get
			{
				return new MvxCommand(() =>
		  		{
			  		ShowViewModel<UnitTabBarViewModel>(presentationBundle: presentationBundle);
			  		Close(this);
		  		});
			}
		}

		public ICommand NavigateToRaceView
		{
			get
			{
				return new MvxCommand(() =>
		  		{
			  		ShowViewModel<RaceTabViewModel>(presentationBundle: presentationBundle);
			  		Close(this);
		  		});
			}
		}


		public HexMainMenuViewModel()
		{
			this.presentationBundle = new MvxBundle(new Dictionary<string, string>() { { "AnimateNavigation", "true" } });
			menuItems = new List<string>()
			{
				"Rules", "Race", "Units", "Planets", "Research", "Galaxy"
			};



		}

		public void Init(NavigationParameters navigationParameters)
		{

			SelectedMenu = navigationParameters.CurrentMenu;
		}
	}
}
