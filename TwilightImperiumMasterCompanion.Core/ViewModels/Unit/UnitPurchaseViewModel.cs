using System.Collections.Generic;
using MvvmCross.Core.Navigation;
using TwilightImperiumMasterCompanion.Core.Model;
using TwilightImperiumMasterCompanion.Core.Resources;
using TwilightImperiumMasterCompanion.Core.Services.Interfaces;
using TwilightImperiumMasterCompanion.Core.ViewModels.Unit;

namespace TwilightImperiumMasterCompanion.Core
{
    public class UnitPurchaseViewModel : UnitViewModel, IPurchaseUnitViewModel
	{
		public static string Title
		{
			get { return UIStrings.Purchase; }
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

		public UnitPurchaseViewModel(IMvxNavigationService navigationService, IUnitService unitService)
        :base(navigationService)
		{
			Units = unitService.GetUnits();
		}

	}
}
