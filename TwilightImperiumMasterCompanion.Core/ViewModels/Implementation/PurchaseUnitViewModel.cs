using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TwilightImperiumMasterCompanion.Core
{
	public class PurchaseUnitViewModel : BaseViewModel, IPurchaseUnitViewModel
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

		public PurchaseUnitViewModel()
		{
			var shipRepository = new ShipRepository();
			Ships = new ObservableCollection<Ship>();
			Ships = shipRepository.GetShips();
		}

	}
}
