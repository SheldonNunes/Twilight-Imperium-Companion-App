SELECT DESCRIPTION 
FROM RaceAbilityTranslation 
JOIN Race ON Race.RaceID = RaceAbilityTranslation.RaceID 
WHERE Name=?