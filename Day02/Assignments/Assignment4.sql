CREATE PROCEDURE sp_ExecutiveDashboard
AS
BEGIN

    SELECT
        COUNT(*) AS TotalActivePatients
    FROM Patient
    WHERE IsActive = 1;

    SELECT TOP 5
        d.Name AS DepartmentName,
        COUNT(*) AS TotalEncounters
    FROM Encounter e
    JOIN Department d
        ON e.DepartmentId = d.DepartmentId
    GROUP BY d.Name
    ORDER BY TotalEncounters DESC;

    SELECT
        COUNT(*) AS DeniedClaims
    FROM Claim
    WHERE Status = 'Denied';

END;

Exec sp_ExecutiveDashboard;

--highest worload provider

SELECT TOP 1
    p.FullName,
    COUNT(*) AS TotalEncounters
FROM Provider p
JOIN Encounter e
    ON e.ProviderId = p.ProviderId
GROUP BY p.ProviderId, p.FullName
ORDER BY TotalEncounters DESC;