using System.Windows.Input;
using MvvmCross.Core.ViewModels;

namespace TwilightImperiumMasterCompanion.Core
{
	public class SelectStartingOptionViewModel : BaseViewModel
	{
		public ICommand NavigateToRaceSelectionView
		{
			get { return new MvxCommand(() => ShowViewModel<RaceSelectionViewModel>()); }
		}
	}
}
