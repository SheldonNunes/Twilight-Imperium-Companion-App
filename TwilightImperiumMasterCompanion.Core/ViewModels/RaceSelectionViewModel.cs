using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;

namespace TwilightImperiumMasterCompanion.Core
{
	public class RaceSelectionViewModel : BaseViewModel
	{
		private List<Race> _races;
		private Race _selectedRace;

		public List<Race> Races
		{
			get { return _races; }
			set
			{
				_races = value;
				RaisePropertyChanged(() => _races);
			}
		}

		public Race SelectedRace
		{
			get { return _selectedRace; }
			set
			{
				_selectedRace = value;
				RaisePropertyChanged("SelectedRace");
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

		private void RaceSelected(Race race)
		{
			SelectedRace = race;
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
