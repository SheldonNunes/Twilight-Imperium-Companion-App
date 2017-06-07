using System;
using System.Threading.Tasks;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using TwilightImperiumMasterCompanion.Core.NavigationParameters;

namespace TwilightImperiumMasterCompanion.Core.ViewModels.Unit
{
    public class UnitDetailViewModel : MvxViewModel<SelectedUnitNavigationParameter>
    {

        public UnitDetailViewModel(IMvxNavigationService navigationService)
        {
         
        }

        public override Task Initialize(SelectedUnitNavigationParameter parameter)
        {
            return Task.Run(() => null);
        }
    }
}
