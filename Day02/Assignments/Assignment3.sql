--view creation because if * operator used uer may see unecessary data

CREATE VIEW vw_BillingClaims
AS
SELECT
    ClaimId,
    Status,
    BilledAmount,
    ReimbursedAmt
FROM Claim;

--stored procedure 

CREATE PROCEDURE sp_RevenueLeakageReport
AS
BEGIN
    SELECT
        Status AS ClaimStatus,
        COUNT(*) AS TotalClaims,
        SUM(BilledAmount) AS TotalBilledAmount,
        SUM(ISNULL(ReimbursedAmt,0))
            AS TotalReimbursedAmount,
        SUM(BilledAmount - ISNULL(ReimbursedAmt,0))
            AS OutstandingAmount,
        RANK() OVER
        (
            ORDER BY
            SUM(BilledAmount - ISNULL(ReimbursedAmt,0)) DESC
        ) AS LossRank
    FROM vw_BillingClaims
    GROUP BY Status
    ORDER BY OutstandingAmount DESC;
END;

--fetch query 

SELECT *
FROM vw_BillingClaims;