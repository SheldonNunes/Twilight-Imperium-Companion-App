﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace TwilightImperiumMasterCompanion.Core
{
	public class ShatteredEmpiresRaceRepository : RaceRepositoryDecorator
	{
		private IRaceRepository _raceRepository;

		public ShatteredEmpiresRaceRepository(IRaceRepository raceRepository)
		{
			_raceRepository = raceRepository;
		}


		public override List<Race> GetRaces()
		{
			var baseRaces = _raceRepository.GetRaces();
			var newRaces = new List<Race>() { 
				new Race("Clan of Saar", "Saar"),
				new Race("Embers of Muaat", "Clan"),
				new Race("Winnu", "Winnu"),
				new Race("Yin Brotherhood", "Yin"),
			};
			newRaces.Concat(baseRaces);
			newRaces.OrderBy(x => x.Name);
			return newRaces;
		}
	}
}
