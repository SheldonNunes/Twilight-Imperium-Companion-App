using System.Collections.Generic;
using MvvmCross.Core.ViewModels;
using TwilightImperiumMasterCompanion.Core.Model;
using TwilightImperiumMasterCompanion.Core.Resources;
using TwilightImperiumMasterCompanion.Core.Services.Interfaces;

namespace TwilightImperiumMasterCompanion.Core.ViewModels
{
    public class AddPlanetViewModel : MvxViewModel
    {
		public static string Title
		{
			get { return UIStrings.AddPlanet; }
		}

        private IEnumerable<Planet> _planets;
        public IEnumerable<Planet> Planets
		{
			get { return _planets; }
			set
			{
				_planets = value;
				RaisePropertyChanged(() => Planets);
			}
		}

        public AddPlanetViewModel(IPlanetService planetService)
        {
            Planets = planetService.GetPlanets();
        }
    }
}
