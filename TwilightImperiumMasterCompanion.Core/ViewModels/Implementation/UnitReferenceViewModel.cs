using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace TwilightImperiumMasterCompanion.Core
{
	public class UnitReferenceViewModel : BaseViewModel, IUnitReferenceViewModel
	{
		private IEnumerable<Ship> _ships;

		public IEnumerable<Ship> Ships
		{
			get { return _ships; }
			set
			{
				_ships = value;
				RaisePropertyChanged(() => Ships);
			}
		}

		public UnitReferenceViewModel()
		{
			var shipRepository = new ShipRepository();
			Ships = new ObservableCollection<Ship>();
			Ships = shipRepository.GetShips();
		}

	}
}
