using System;
using System.Collections.Generic;

namespace TwilightImperiumMasterCompanion.Core
{
	public abstract class RaceRepositoryDecorator : IRaceRepository
	{
		public abstract List<Race> GetRaces();
	}
}
