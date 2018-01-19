SELECT 
    Description 
FROM LeaderAbilityTranslation 
JOIN Leader ON Leader.LeaderID = LeaderAbilityTranslation.LeaderID 
WHERE LeaderType = ?