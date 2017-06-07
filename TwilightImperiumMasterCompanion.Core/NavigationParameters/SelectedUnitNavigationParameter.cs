using System;
namespace TwilightImperiumMasterCompanion.Core.NavigationParameters
{
    public class SelectedUnitNavigationParameter
    {
        public Unit Unit
        {
            get;
            set;
        }

        public SelectedUnitNavigationParameter(Unit unit){
            this.Unit = unit;
        }
    }
}
