using System.Windows.Input;
using MvvmCross.Core.ViewModels;

namespace TwilightImperiumMasterCompanion.Core
{
    public class UnitTabBarViewModel : MvxViewModel
	{
		private ICommand _showInitialViewModelsCommand;
		public ICommand ShowInitialViewModelsCommand
		{
			get
			{
				return _showInitialViewModelsCommand ?? (_showInitialViewModelsCommand = new MvxCommand(ShowInitialViewModels));
			}
		}

		void ShowInitialViewModels()
		{
            ShowViewModel<UnitReferenceViewModel>();
            ShowViewModel<UnitPurchaseViewModel>();
		}

	}
}
