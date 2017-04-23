using System;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;

namespace TwilightImperiumMasterCompanion.Core
{
	public class HexMainMenuViewModel : BaseViewModel
	{

		public ICommand CloseMenu
		{
			get { return new MvxCommand(() => Close(this)); }
		}

		private int selectedMenu;
		public int SelectedMenu
		{
			get { return selectedMenu; }
			set
			{
				selectedMenu = value;
				RaisePropertyChanged(() => SelectedMenu);
			}
		}

		public ICommand NavigateToUnitView
		{
			get
			{
				return new MvxCommand(() =>
		  		{
			  		ShowViewModel<UnitTabBarViewModel>();
			  		Close(this);
		  		});
			}
		}


		public HexMainMenuViewModel()
		{

		}

		public void Init(NavigationParameters navigationParameters)
		{
			SelectedMenu = navigationParameters.Index;

		}
	}
}
