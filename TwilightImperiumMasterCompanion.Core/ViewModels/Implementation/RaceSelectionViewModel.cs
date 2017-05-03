using System.Collections.Generic;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;

namespace TwilightImperiumMasterCompanion.Core
{
	public class RaceSelectionViewModel : BaseViewModel<ExpansionsNavigationParameter>
	{

		private readonly IMvxMessenger messenger;
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

		public RaceSelectionViewModel(IMvxMessenger messenger)
		{
			this.messenger = messenger;
		}

		protected override void RealInit(ExpansionsNavigationParameter parameter)
		{
			if (raceRepository != null)
				return;

			raceRepository = new RaceRepository();
			if (parameter.ShardsofTheThroneExpansionEnabled)
			{
				raceRepository = new ShardsOfTheThroneRaceRepository(raceRepository);
			}

			if (parameter.ShatteredEmpiresExpansionEnabled)
			{
				raceRepository = new ShatteredEmpiresRaceRepository(raceRepository);
			}
			Races = raceRepository.GetRaces();
		}
	}
}
