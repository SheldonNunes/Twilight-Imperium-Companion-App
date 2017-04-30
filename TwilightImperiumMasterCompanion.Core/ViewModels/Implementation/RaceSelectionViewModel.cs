using System.Windows.Input;
using MvvmCross.Core.ViewModels;

namespace TwilightImperiumMasterCompanion.Core
{
	public class RaceSelectionViewModel : BaseViewModel
	{

		public ICommand NavigateToRaceView
		{
			get { return new MvxCommand(() => ShowViewModel<UnitTabBarViewModel>()); }
		}
	}
}
