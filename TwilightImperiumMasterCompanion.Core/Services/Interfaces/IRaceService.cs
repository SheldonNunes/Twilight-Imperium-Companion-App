﻿using System;
using System.Collections.Generic;
using TwilightImperiumMasterCompanion.Core.Dto;
using TwilightImperiumMasterCompanion.Core.Model;

namespace TwilightImperiumMasterCompanion.Core.Services.Interfaces
{
	public interface IRaceService
	{
		List<Race> GetRaces();

        Race GetRace(string raceName);

        List<StartingPlanetDto> GetStartingPlanets(Race race);

        List<StartingUnitDto> GetStartingUnits(Race race);

        List<Technology> GetStartingTechnology(Race race);

        List<Leader> GetLeaders(Race race);
	}
}
