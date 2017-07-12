using System.Collections.Generic;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using TwilightImperiumMasterCompanion.Core.Model;
using TwilightImperiumMasterCompanion.Core.NavigationParameters;
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

        private MvxCommand<Unit> showDetailView;
        public MvxCommand<Unit> ShowDetailView
        {
            get
            {
                showDetailView = showDetailView ?? new MvxCommand<Unit>((unit) =>
                {
                    navigationService.Navigate<UnitDetailViewModel, SelectedUnitNavigationParameter>(new SelectedUnitNavigationParameter(unit));
                });
                return showDetailView;
            }
        }

        private readonly IMvxNavigationService navigationService;

        public UnitReferenceViewModel(IMvxNavigationService navigationService, IUnitService unitService)
            : base(navigationService)
        {
            Units = unitService.GetUnits();
            this.navigationService = navigationService;
        }

    }
}
