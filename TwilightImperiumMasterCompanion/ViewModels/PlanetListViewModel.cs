using System;
using XLabs.Forms.Mvvm;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace TwilightImperiumMasterCompanion
{
	public class PlanetListViewModel : ViewModel
	{

		Planet planet = null;

		public List<Planet> Planets {
			get;
			set;
		}

		public List<ObservableGroupCollection<string,Planet>> PlanetsGrouped {
			get;
			set;
		}

		public Planet SelectedPlanet {
			get { return planet; }
			set { SetProperty(ref planet, value);
				OnSelection(value);
			}
		}

		public PlanetListViewModel ()
		{
			var planets = PlanetGenerator.GeneratePlanets ();
			Planets = planets;

			var groupedData =
				planets.OrderBy(p => p.PlanetName)
					.GroupBy(p => p.PlanetName[0].ToString())
					.Select(p => new ObservableGroupCollection<string, Planet>(p))
					.ToList();

			PlanetsGrouped = groupedData;

		}

		public async void OnSelection (Planet planet){
			
			if(planet != null){
				await Navigation.PushAsync (new SelectedPlanetView(planet));
			}
		}

	

	}
}

