using System;
using System.Collections.Generic;

namespace TwilightImperiumMasterCompanion.Core
{
	public class RaceRepository : IRaceRepository
	{
		private static readonly List<Race> _races = new List<Race>()
		{
			new Race("Barony of Letnev", "BaronyEmblem"),
			new Race("Emirates of Hacan", "HacanEmblem"),
			new Race("Federation of Sol" , "SolEmblem"),
			new Race("Lizix Mindnet", "MindnetEmblem"),
			new Race("Mentak Coalition", "MentakEmblem"),
			new Race("Naalu Collective", "NaaluEmblem"),
			new Race("Sardakk Norr", "NecroEmblem"),
			new Race("Universities of Jol-Nar", "JolNarEmblem"),
			new Race("Xxcha Kingdom", "XxchaEmblem"),
			new Race("Ysaril Tribes", "YsarilEmblem")
		};


		public List<Race> GetRaces()
		{
			return _races;
		}
	}
}
