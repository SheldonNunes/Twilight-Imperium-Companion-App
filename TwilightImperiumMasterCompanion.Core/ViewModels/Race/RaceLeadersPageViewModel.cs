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

        private List<IMvxPagedViewModel> viewModels;
        private int position;
        private List<Leader> Leaders;

        public RaceLeadersPageViewModel(IMvxNavigationService navigationService, ISessionService sessionService, IRaceService raceService) : base(navigationService)
		{
            var race = sessionService.GetSelectedRace();
            Leaders = raceService.GetLeaders(race);
            position = 0;
            viewModels = new List<IMvxPagedViewModel>();
            foreach (var leader in Leaders)
            {
                var viewModel = new RaceLeadersPageComponentViewModel(leader.Name, leader);
                viewModels.Add(viewModel);
            }
        }

        public IMvxPagedViewModel GetDefaultViewModel()
        {
            return viewModels[0];
        }

        public IMvxPagedViewModel GetNextViewModel(IMvxPagedViewModel currentViewModel)
        {
            position++;

            var id = currentViewModel.PagedViewId;
            var index = viewModels.FindIndex(x => x.PagedViewId == id);

            if(index == viewModels.Count() - 1){
                return null;
            }
            return viewModels[index + 1];

		}

        public IMvxPagedViewModel GetPreviousViewModel(IMvxPagedViewModel currentViewModel)
        {
            position--;

			var id = currentViewModel.PagedViewId;
			var index = viewModels.FindIndex(x => x.PagedViewId == id);

			if (index == 0)
			{
				return null;
			}
            return viewModels[index - 1];
        }
    }
}
