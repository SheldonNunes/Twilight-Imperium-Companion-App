using System;
using System.Collections.Generic;

namespace TwilightImperiumMasterCompanion
{
	public class PlanetGenerator
	{
		public static List<Planet> GeneratePlanets(){
			List<Planet> planets = new List<Planet> {
				new Planet (PlanetConstants.MECATOLREX_NAME, PlanetConstants.MECATOLREX_DESCRIPTION, 1, 6),
				new Planet (PlanetConstants.ZERO_NAME, PlanetConstants.ZERO_DESCRIPTION, 1, 6),
				new Planet (PlanetConstants.ABYZ_NAME, PlanetConstants.ABYZ_DESCRIPTION, 1, 6),
				new Planet (PlanetConstants.ARCHON_REN_NAME, PlanetConstants.ARCHON_REN_DESCRIPTION, 1, 6),
				new Planet (PlanetConstants.BEREG_NAME, PlanetConstants.BEREG_DESCRIPTION, 1, 6),
				new Planet (PlanetConstants.CENTAURI_NAME, PlanetConstants.CENTAURI_DESCRIPTION, 1, 6),
				new Planet (PlanetConstants.DAL_BOOTHA_NAME, PlanetConstants.DAL_BOOTHA_DESCRIPTION, 1, 6),



			};


			return(planets);
		}
	}
}

