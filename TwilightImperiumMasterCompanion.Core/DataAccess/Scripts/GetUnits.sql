SELECT * 
    FROM Unit 
    LEFT JOIN Session 
    WHERE Expansion = 0 
        OR (ShatteredEmpireExpansionEnabled IS 1 AND Expansion = 1) 
        OR (ShardsOfTheThroneExpansionEnabled IS 1 AND Expansion = 2)