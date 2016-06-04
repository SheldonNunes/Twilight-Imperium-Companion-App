using System;
using XLabs.Forms.Mvvm;

namespace TwilightImperiumMasterCompanion
{
	public class SelectedPlanetViewModel : ViewModel
	{
		public string PlanetName {
			get;
			set;
		}

		public string Description {
			get;
			set;
		}

		public string Resource {
			get;
			set;
		}

		public string Influence {
			get;
			set;
		}

		public SelectedPlanetViewModel (Planet planet)
		{
			this.PlanetName = planet.PlanetName;
			this.Description = planet.Description;
			this.Influence = planet.Influence.ToString ();
			this.Resource = planet.Resource.ToString ();
		}
	}
}

