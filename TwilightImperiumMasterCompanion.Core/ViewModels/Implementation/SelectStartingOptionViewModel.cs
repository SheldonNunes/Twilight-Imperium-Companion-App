using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using TwilightImperiumMasterCompanion.Core.Resources;

namespace TwilightImperiumMasterCompanion.Core
{
	public class SelectStartingOptionViewModel : BaseViewModel
	{
		public ICommand NavigateToRaceSelectionView
		{
			get
			{
				return new MvxCommand(
			  () => ShowViewModel<RaceSelectionViewModel>());
			}
		}

		public bool ShatteredEmpiresExpansionEnabled
		{
			get { return BaseService.ShatteredEmpiresExpansionEnabled; }
			set { BaseService.ShatteredEmpiresExpansionEnabled = value; }
		}

		public bool ShardsOfTheThroneExpansionEnabled
		{
			get { return BaseService.ShardsOfTheThroneExpansionEnabled; }
			set
			{
				BaseService.ShardsOfTheThroneExpansionEnabled = value;
			}
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
