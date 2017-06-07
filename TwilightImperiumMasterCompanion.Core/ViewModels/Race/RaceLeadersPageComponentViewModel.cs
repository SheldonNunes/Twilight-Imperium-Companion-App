using System;
using MvvmCross.Core.ViewModels;
using TwilightImperiumMasterCompanion.Core.Model;

namespace TwilightImperiumMasterCompanion.Core.ViewModels.Race
{
    public class RaceLeadersPageComponentViewModel : MvxViewModel, IMvxPagedViewModel
    {
        private Leader leader;
        public Leader Leader
		{
			get { return leader; }
			set
			{
				leader = value;
				RaisePropertyChanged(() => Leader);
			}
		}

        private string pagedViewId;
        public string PagedViewId => pagedViewId;

        public RaceLeadersPageComponentViewModel(string pagedViewId, Leader leader)
        {
            this.pagedViewId = pagedViewId;
            this.leader = leader;
        }
    }
}
