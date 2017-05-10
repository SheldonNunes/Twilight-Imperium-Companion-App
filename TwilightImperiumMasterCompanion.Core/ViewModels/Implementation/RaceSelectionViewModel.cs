using System.Collections.Generic;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;

namespace TwilightImperiumMasterCompanion.Core
{
	public class RaceSelectionViewModel : BaseViewModel<ExpansionsNavigationParameter>
	{

		private readonly IMvxMessenger messenger;
		private readonly IRaceService raceService;
		private readonly IRaceAbilityService raceAbilityService;

		private IRaceRepository raceRepository;

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

		public ICommand RaceSelected
		{
			get
			{
				return new MvxCommand<Race>((race) =>
				{
					messenger.Publish(new RaceSelectedMessage(this, race));
					this.Close(this);
				});
			}
		}

		public RaceSelectionViewModel(IMvxMessenger messenger, IRaceService raceService, IRaceAbilityService raceAbilityService)
		{
			this.messenger = messenger;
			this.raceService = raceService;
			this.raceAbilityService = raceAbilityService;
		}

		protected override void RealInit(ExpansionsNavigationParameter parameter)
		{
			Races = raceService.GetRaces();
		}
	}
}
