SELECT Planet.ID As PlanetId,
       Name AS Title,
       Resource, 
       Influence, 
       ExpansionLevel 
   FROM Planet 
   JOIN RaceStartingPlanets
   ON Planet.ID = RaceStartingPlanets.PlanetID
   WHERE RaceStartingPlanets.RaceID = ?