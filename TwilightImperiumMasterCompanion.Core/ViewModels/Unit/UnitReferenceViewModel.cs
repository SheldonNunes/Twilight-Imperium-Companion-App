using System.Collections.Generic;
using MvvmCross.Core.Navigation;
using TwilightImperiumMasterCompanion.Core.Resources;
using TwilightImperiumMasterCompanion.Core.Services.Interfaces;
using TwilightImperiumMasterCompanion.Core.ViewModels.Unit;

namespace TwilightImperiumMasterCompanion.Core
{
    public class UnitReferenceViewModel : UnitViewModel, IUnitReferenceViewModel
	{
		public static string Title
		{
            get { return UIStrings.UnitReference; }
		}

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

		public UnitReferenceViewModel(IMvxNavigationService navigationService, IUnitService unitService)
            :base(navigationService)
		{
			Units = unitService.GetUnits();
		}

	}
}
