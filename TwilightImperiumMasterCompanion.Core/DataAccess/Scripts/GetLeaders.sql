SELECT 
    RaceLeaderID,
    LeaderType  
FROM Leader 
JOIN RaceLeader ON Leader.LeaderID = RaceLeader.LeaderID 
WHERE RaceID = ?