using System;
using System.Collections.Generic;

namespace TwilightImperiumMasterCompanion.Core
{
	public class RaceRepository : IRaceRepository
	{
		private static readonly List<Race> _races = new List<Race>()
		{
			new Race("Barony of Letnev"),
			new Race("Emirates of Hacan"),
			new Race("Federation of Sol"),
			new Race("Lizix Mindnet"),
			new Race("Mentak Coalition"),
			new Race("Naalu Collective"),
			new Race("Sardakk Norr"),
			new Race("Universities of Jol-Nar"),
			new Race("Xxcha Kingdom"),
			new Race("Ysaril Tribes")
		};


		public List<Race> GetRaces()
		{
			return _races;
		}
	}
}
