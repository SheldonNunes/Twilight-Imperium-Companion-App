SELECT * 
	FROM Planet
	LEFT JOIN Session 
	WHERE ExpansionLevel = 0 
	    OR (ShatteredEmpireExpansionEnabled IS 1 AND ExpansionLevel = 1) 
	    OR (ShardsOfTheThroneExpansionEnabled IS 1 AND ExpansionLevel = 2)