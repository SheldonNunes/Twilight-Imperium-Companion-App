using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;

namespace TwilightImperiumMasterCompanion.Core
{
	public class RaceSelectionViewModel : BaseViewModel
	{
		private Race[] _races;

		public Race[] Races
		{
			get { return _races; }
			set
			{
				_races = value;
				RaisePropertyChanged(() => _races);
			}
		}


		private MvxCommand<Race> _itemSelectedCommand;
		public ICommand RaceSelectionChangedCommand
		{
			get
			{
				_itemSelectedCommand = _itemSelectedCommand ?? new MvxCommand<Race>(DoSelectItem);
				return _itemSelectedCommand;
			}
		}

		private void DoSelectItem(Race item)
		{
			var test = 3;
		}

		public RaceSelectionViewModel()
		{
			_races = new RaceRepository().GetRaces().ToArray();
		}

		public override void Start()
		{
			base.Start();
		}
	}
}
