using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;

namespace TwilightImperiumMasterCompanion.Core
{
	public class RaceSelectionViewModel : BaseViewModel
	{
		private List<Race> _races;

		public List<Race> Races
		{
			get { return _races; }
			set
			{
				_races = value;
				RaisePropertyChanged(() => _races);
			}
		}

		private MvxCommand<Race> _raceSelectionChangedCommand;
		public ICommand RaceSelectionChangedCommand
		{
			get
			{
				_raceSelectionChangedCommand = _raceSelectionChangedCommand ?? new MvxCommand<Race>(RaceSelected);
				return _raceSelectionChangedCommand;
			}
		}

		private void RaceSelected(Race item)
		{
		}

		public RaceSelectionViewModel()
		{
			_races = new RaceRepository().GetRaces();
		}

		public override void Start()
		{
			base.Start();
		}
	}
}
