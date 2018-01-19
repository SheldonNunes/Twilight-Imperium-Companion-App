using System;
using System.Collections.Generic;
using System.Linq;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using TwilightImperiumMasterCompanion.Core.Model;
using TwilightImperiumMasterCompanion.Core.Resources;
using TwilightImperiumMasterCompanion.Core.Services.Interfaces;
using TwilightImperiumMasterCompanion.Core.ViewModels.Race;

namespace TwilightImperiumMasterCompanion.Core
{
    public class RaceLeadersPageViewModel : RaceViewModel, IRaceLeadersViewModel, IMvxPageViewModel
    {
        public static string Title
        {
            get { return UIStrings.Leaders; }
        }

        private int pageIndex;
        public int PageIndex
        {
			get { return pageIndex; }
			set
			{
				pageIndex = value;
				RaisePropertyChanged(() => PageIndex);
			}
        }

		private int leadersCount;
		public int LeadersCount
		{
			get { return leadersCount; }
			set
			{
				leadersCount = value;
				RaisePropertyChanged(() => LeadersCount);
			}
		}

        private List<IMvxPagedViewModel> viewModels;
        private List<Leader> Leaders;

        public RaceLeadersPageViewModel(IMvxNavigationService navigationService, ISessionService sessionService, IRaceService raceService) : base(navigationService)
        {
            var race = sessionService.GetSelectedRace();
            Leaders = raceService.GetLeaders(race);
            LeadersCount = Leaders.Count();
            viewModels = new List<IMvxPagedViewModel>();
            foreach (var leader in Leaders)
            {
                var viewModel = new RaceLeadersPageComponentViewModel(leader.RaceLeaderID.ToString(), leader);
                viewModels.Add(viewModel);
            }
        }

        public IMvxPagedViewModel GetDefaultViewModel()
        {
            return viewModels[0];
        }

        public IMvxPagedViewModel GetNextViewModel(IMvxPagedViewModel currentViewModel)
        {


            var id = currentViewModel.PagedViewId;
            var index = viewModels.FindIndex(x => x.PagedViewId == id);
            PageIndex = index;
            if (index == viewModels.Count() - 1)
            {
                return null;
            }

            return viewModels[index + 1];

        }

        public IMvxPagedViewModel GetPreviousViewModel(IMvxPagedViewModel currentViewModel)
        {
            var id = currentViewModel.PagedViewId;
            var index = viewModels.FindIndex(x => x.PagedViewId == id);
            PageIndex = index;
            if (index == 0)
            {
                return null;
            }

            return viewModels[index - 1];
        }
    }
}
