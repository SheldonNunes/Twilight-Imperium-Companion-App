using System.Collections.Generic;
using TwilightImperiumMasterCompanion.Core.Services.Interfaces;

namespace TwilightImperiumMasterCompanion.Core
{
    public class UnitPurchaseViewModel : BaseViewModel, IPurchaseUnitViewModel
	{
        private IEnumerable<Unit> _units;
        public IEnumerable<Unit> Units
		{
			get { return _units; }
			set
			{
				_units = value;
				RaisePropertyChanged(() => Units);
			}
		}

		public UnitPurchaseViewModel(IUnitService unitService)
		{
			Units = unitService.GetUnits();
		}

	}
}
