SELECT * 
	FROM Unit 
	JOIN RaceStartingUnits ON Unit.UnitID = RaceStartingUnits.UnitID 
	WHERE RaceStartingUnits.RaceID = ?