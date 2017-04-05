using System;

namespace TwilightImperiumMasterCompanion.Core
{
	public class Planet
	{

		public string PlanetName {
			get;
			set;
		}

		public string Description {
			get;
			set;
		}

		public int Resource {
			get;
			set;
		}

		public int Influence {
			get;
			set;
		}

		public Player Owner {
			get;
			set;
		}
	}
}

