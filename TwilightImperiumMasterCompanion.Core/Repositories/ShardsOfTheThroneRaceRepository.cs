using System.Collections.Generic;
using System.Linq;

namespace TwilightImperiumMasterCompanion.Core
{
	public class ShardsOfTheThroneRaceRepository : RaceRepositoryDecorator
	{
		private IRaceRepository _raceRepository;

		public ShardsOfTheThroneRaceRepository(IRaceRepository raceRepository)
		{
			_raceRepository = raceRepository;
		}


		public override List<Race> GetRaces()
		{
			var baseRaces = _raceRepository.GetRaces();
			var newRaces = new List<Race>()
			{
				//new Race("Arborec", "Arborec"),
				//new Race("Ghosts of Creuss", "Ghosts"),
				//new Race("Nekro Virus", "Nekro"),
			};
			newRaces.AddRange(baseRaces);
			newRaces = newRaces.OrderBy(x => x.Name).ToList();
			return newRaces;
		}
	}
}
