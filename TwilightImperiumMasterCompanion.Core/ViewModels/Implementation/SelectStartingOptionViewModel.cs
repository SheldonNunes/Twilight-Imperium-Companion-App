using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using TwilightImperiumMasterCompanion.Core.Resources;

namespace TwilightImperiumMasterCompanion.Core
{
	public class SelectStartingOptionViewModel : BaseViewModel
	{
		public ICommand NavigateToRaceSelectionView
		{
			get { return new MvxCommand(
				() => ShowViewModel<ConfirmRaceViewModel, ExpansionsNavigationParameter>(
					new ExpansionsNavigationParameter()
					{
						ShatteredEmpiresExpansionEnabled = ShatteredEmpiresExpansionEnabled,
						ShardsofTheThroneExpansionEnabled = ShardsOfTheThroneExpansionEnabled
					}
					)); 
				}
		}

		public bool ShatteredEmpiresExpansionEnabled
		{
			get;
			set;
		}

		public bool ShardsOfTheThroneExpansionEnabled
		{
			get;
			set;
		}

		public string Title
		{
			get { return UIStrings.TwilightImperiumCompanion; }
		}

		public SelectStartingOptionViewModel() : base()
		{

		}
	}
}
