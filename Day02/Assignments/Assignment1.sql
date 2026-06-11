--Assignement01 => The Overloaded Emergency Department

Select p.FullName,d.Name,Count(e.EncounterId) As Totalencounter,
Rank()Over(Order By Count(e.EncounterId) Desc) As ProviderRank
From Provider p 
Join Encounter e on p.ProviderId = e.ProviderId
Join Department d on d.DepartmentId = p.DepartmentId
Group By p.FullName,d.Name
Order By Totalencounters Desc;

--Assignemnt02 => The Insurance Dispute Investigation

--Assignement03 => 