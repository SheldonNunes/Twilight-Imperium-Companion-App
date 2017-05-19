using System.Collections.Generic;
using TwilightImperiumMasterCompanion.Core.Services.Interfaces;

namespace TwilightImperiumMasterCompanion.Core
{
    public class UnitReferenceViewModel : BaseViewModel, IUnitReferenceViewModel
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

		public UnitReferenceViewModel(IUnitService unitService)
		{
			Units = unitService.GetUnits();
		}

	}
}
