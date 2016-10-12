using System;
using System.Collections.Generic;

namespace TwilightImperiumMasterCompanion.Core
{
	public class RaceRepository : IRaceRepository
	{
		private static readonly List<Race> _races = new List<Race>()
		{
			new Race("Barony of Letnev", "Barony"),
			new Race("Emirates of Hacan", "Hacan"),
			new Race("Federation of Sol" , "Sol"),
			new Race("Lizix Mindnet", "Mindnet"),
			new Race("Mentak Coalition", "Mentak"),
			new Race("Naalu Collective", "Naalu"),
			//todo figure out which spelling is correct
			new Race("Sardakk Norr", "Saardak"),
			new Race("Universities of Jol-Nar", "JolNar"),
			new Race("Xxcha Kingdom", "Xxcha"),
			new Race("Ysaril Tribes", "Ysaril")
		};


		public List<Race> GetRaces()
		{
			return _races;
		}
	}
}
