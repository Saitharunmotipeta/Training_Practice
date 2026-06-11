--Temporal Columns addition 
ALTER TABLE Insurance
ADD
    ValidFrom DATETIME2
        GENERATED ALWAYS AS ROW START
        DEFAULT SYSUTCDATETIME(),

    ValidTo DATETIME2
        GENERATED ALWAYS AS ROW END
        DEFAULT '9999-12-31 23:59:59.9999999',

    PERIOD FOR SYSTEM_TIME (ValidFrom, ValidTo);

--system versioning control
ALTER TABLE Insurance
SET
(
    SYSTEM_VERSIONING = ON
    (
        HISTORY_TABLE = dbo.Insurance_History
    )
);

--Query to fetch
DECLARE @PatientId INT = 1;

SELECT
    p.FullName,
    i.InsuranceId,
    i.Payer,
    i.PolicyNumber,
    i.ValidFrom,
    i.ValidTo,
    CASE
        WHEN i.ValidTo = '9999-12-31 23:59:59.9999999'
            THEN 'Current Policy'
        ELSE 'Historical Policy'
    END AS PolicyStatus
FROM Insurance FOR SYSTEM_TIME ALL i
JOIN Patient p
    ON p.PatientId = i.PatientId
WHERE p.PatientId = @PatientId
ORDER BY i.ValidFrom;