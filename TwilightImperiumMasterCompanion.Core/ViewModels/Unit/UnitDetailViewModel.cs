using System;
using System.Threading.Tasks;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using TwilightImperiumMasterCompanion.Core.Model;
using TwilightImperiumMasterCompanion.Core.NavigationParameters;

namespace TwilightImperiumMasterCompanion.Core.ViewModels.Unit
{
    public class UnitDetailViewModel : MvxViewModel<SelectedUnitNavigationParameter>
    {
        private Model.Unit _selectedUnit;
        public Model.Unit SelectedUnit
		{
			get { return _selectedUnit; }
			set
			{
				_selectedUnit = value;
				RaisePropertyChanged(() => SelectedUnit);
			}
		}

        public UnitDetailViewModel(IMvxNavigationService navigationService)
        {
         
        }

        public override Task Initialize(SelectedUnitNavigationParameter parameter)
        {
            return Task.Run(() => this.SelectedUnit = parameter.Unit);
        }
    }
}
