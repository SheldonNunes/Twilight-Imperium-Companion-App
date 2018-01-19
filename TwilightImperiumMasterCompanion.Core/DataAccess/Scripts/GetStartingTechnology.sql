SELECT * 
	FROM RaceStartingTechnology 
	JOIN Technology ON RaceStartingTechnology.TechnologyID = Technology.TechnologyID 
	WHERE RaceStartingTechnology.RaceID = ?