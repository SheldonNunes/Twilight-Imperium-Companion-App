using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using TwilightImperiumMasterCompanion.Core.Resources;

namespace TwilightImperiumMasterCompanion.Core
{
    public class RaceSelectionViewModel : MvxViewModel
    {
        public string Title
        {
            get { return UIStrings.RaceSelection; }
        }


        private IEnumerable<Race> _races;
        public IEnumerable<Race> Races
        {
            get { return _races; }
            set
            {
                _races = value;
                RaisePropertyChanged(() => Races);
            }
        }

        private IMvxAsyncCommand navigateToConfirmRaceView;
        public IMvxAsyncCommand NavigateToConfirmRaceView
        {
            get
            {
                return navigateToConfirmRaceView = navigateToConfirmRaceView ?? 
                        new MvxAsyncCommand<Race>(
                            (race) => navigationService.Navigate<ConfirmRaceViewModel, SelectedRaceNavigationParameter>(
                            new SelectedRaceNavigationParameter() { SelectedRace = race }));
            }
        }

        private readonly IRaceService raceService;
        private readonly IRaceAbilityService raceAbilityService;
        private readonly IMvxNavigationService navigationService;

        public RaceSelectionViewModel(IMvxNavigationService navigationService, IRaceService raceService, IRaceAbilityService raceAbilityService)
        {
            this.navigationService = navigationService;
            this.raceService = raceService;
            this.raceAbilityService = raceAbilityService;

            Races = raceService.GetRaces();
        }
    }
}
