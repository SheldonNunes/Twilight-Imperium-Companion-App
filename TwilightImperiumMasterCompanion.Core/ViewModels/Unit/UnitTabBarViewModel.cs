using System.Windows.Input;
using MvvmCross.Core.ViewModels;

namespace TwilightImperiumMasterCompanion.Core
{
	public class UnitTabBarViewModel : BaseViewModel
	{
		private const int UNIT_TAB = 1;
		public readonly IUnitReferenceViewModel UnitReferenceViewModel;
		public readonly IPurchaseUnitViewModel PurchaseUnitViewModel;

		public ICommand ShowHexMainMenu
		{
			get { return new MvxCommand(() => ShowViewModel<HexMainMenuViewModel>(new NavigationParameters() { Index = UNIT_TAB })); }
		}


		public UnitTabBarViewModel(
			IUnitReferenceViewModel unitReferenceViewModel,
			IPurchaseUnitViewModel purchaseUnitViewModel)
		{
			this.PurchaseUnitViewModel = purchaseUnitViewModel;
			this.UnitReferenceViewModel = unitReferenceViewModel;
		}


	}
}
