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

		public bool isOwned {
			get;
			set;
		}
			
		public Planet (string planetName, string description, int resourceValue, int influenceValue )
		{
			PlanetName = planetName;
			Description = description;
			Influence = influenceValue;
			Resource = resourceValue;
		}
	}
}

