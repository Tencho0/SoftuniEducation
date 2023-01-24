USE [SoftUni]

--Problem 1
  SELECT TOP 5
	e.EmployeeID,
	e.JobTitle,
	e.AddressID,
	a.AddressText
  FROM Employees AS e
 JOIN [Addresses] AS a ON e.AddressID = a.AddressID
ORDER BY e.AddressID

--Problem 2
SELECT TOP (50)
		[e].[FirstName],
		[e].[LastName],
		[t].[Name] AS [Town],
		[a].AddressText AS [AddressText]
FROM Employees AS [e]
JOIN [Addresses] AS [a]
		ON e.AddressID = a.AddressID
	JOIN [Towns] AS [t]
		ON a.TownID = t.TownID
ORDER BY [e].[FirstName], [e].[LastName]

--Problem 3
SELECT 
		[e].[EmployeeID],
		[e].[FirstName],
		[e].[LastName],
		[d].[Name]
FROM [Employees] AS [e]
JOIN [Departments] AS [d]
ON [e].[DepartmentID] = [d].[DepartmentID]
WHERE [d].[Name] = 'Sales'
ORDER BY [e].[EmployeeID]

--Problem 4
SELECT TOP (5)
		[e].[EmployeeID],
		[e].[FirstName],
		[e].[Salary],
		[d].[Name]
FROM [Employees] AS [e]
JOIN [Departments] AS [d]
ON [e].[DepartmentID] = [d].[DepartmentID]
WHERE [e].[Salary] > 15000
ORDER BY [d].[DepartmentID]

--Problem 5
  SELECT TOP (3)
	  [e].[EmployeeID], [e].[FirstName]
	FROM Employees AS [e]
 LEFT JOIN [EmployeesProjects] AS [ep] 
	ON [e].EmployeeID = [ep].EmployeeID
	WHERE [ep].[ProjectID] IS NULL
ORDER BY [e].[EmployeeID]

--Problem 6
SELECT 
		[e].[FirstName],
		[e].[LastName],
		[e].[HireDate],
		[d].[Name] AS [DeptName]
FROM [Employees] AS [e]
JOIN [Departments] AS [d]
ON [e].[DepartmentID] = [d].[DepartmentID]
WHERE [e].[HireDate] > 01/01/1999 AND [d].[Name] IN ('Sales', 'Finance')
ORDER BY [e].[HireDate]

--Problem 7
  SELECT TOP (5)
		 [e].[EmployeeID],
   		 [e].[FirstName], 
		 [p].[Name] AS [ProjectName] 
  FROM [Employees] AS [e]
	INNER JOIN [EmployeesProjects] AS [ep]
		ON [e].[EmployeeID] = [ep].[EmployeeID]
	INNER JOIN [Projects] as [p]
		ON [p].[ProjectID] = [ep].[ProjectID]
	WHERE [p].[StartDate] > '08/13/2002' AND [p].[EndDate] IS NULL
ORDER BY [e].[EmployeeID]

--Problem 8
SELECT 
	[e].[EmployeeID],
	[e].[FirstName],
  CASE 
   WHEN [p].StartDate > '01/01/2005' THEN NULL
   ELSE [p].[NAME]
  END 
FROM [EmployeesProjects] AS [ep]
LEFT JOIN [Projects] AS [p]
ON [ep].[ProjectID] = [p].[ProjectID]
LEFT JOIN [Employees] AS [e]
ON [ep].[EmployeeID] = [e].[EmployeeID]
WHERE [e].[EmployeeID] = 24

--Problem 9
  SELECT 
	[e].[EmployeeID],
	[e].[FirstName],
	[m].[EmployeeID] AS [ManagerID],
	[m].[FirstName] AS [ManagerName]
  FROM [Employees] AS [e]
	INNER JOIN [Employees] AS [m]
	   ON [e].ManagerID = [m].[EmployeeID]
 WHERE [m].[EmployeeID] IN (3, 7)
ORDER BY [e].[EmployeeID]


--Problem 10
SELECT TOP (50)
	[e].[EmployeeID],
	CONCAT([e].[FirstName], ' ', [e].[LastName]) AS [EmployeeName],
	CONCAT([m].[FirstName], ' ', [m].[LastName]) AS [ManagerName],
	[d].[Name] AS [DepartmentName]
FROM [Employees] AS [e]
JOIN [Employees] AS [m]
ON [e].ManagerID = [m].[EmployeeID]
JOIN [Departments] AS [d]
ON [d].[DepartmentID] = [e].[DepartmentID]
ORDER BY [e].[EmployeeID]

--Problem 11
SELECT min(avg) AS [MinAverageSalary]
FROM (
       SELECT avg(Salary) AS [avg]
       FROM Employees
       GROUP BY DepartmentID
     ) AS AverageSalary



USE [Geography]

--Problem 12
SELECT 
		[mc].[CountryCode], 
		[m].[MountainRange],
		[p].[PeakName],
		[p].[Elevation]
FROM [Peaks] AS [p]
INNER JOIN [Mountains] AS [m]
ON [p].[MountainId] = [m].[Id]
INNER JOIN [MountainsCountries] AS [mc]
ON [m].[Id] = [mc].[MountainId]
WHERE [mc].[CountryCode] = 'BG' AND [p].[Elevation] > 2835
ORDER BY [p].[Elevation] DESC


--Problem 13
SELECT 
	[c].[CountryCode],
	COUNT([mc].[MountainId]) AS [MountainRanges]
FROM [Countries] AS [c]
LEFT JOIN [MountainsCountries] AS [mc]
ON [c].[CountryCode] = [mc].[CountryCode]
WHERE [c].[CountryName] IN ('Bulgaria', 'Russia', 'United States')
GROUP BY [c].[CountryCode]


--Problem 14
SELECT TOP (5)
	[c].[CountryName],
	[r].[RiverName]
FROM [CountriesRivers] AS [cr]
RIGHT JOIN [Rivers] AS [r]
ON [r].[Id] = [cr].[RiverId]
RIGHT JOIN [Countries] AS [c]
ON [cr].[CountryCode] = [c].[CountryCode]
WHERE [c].[ContinentCode] = 'AF'
ORDER BY [c].[CountryName]

--Problem 15
SELECT 
	[ContinentCode],
	[CurrencyCode],
	[CurrencyUsage]
FROM ( SELECT *,
			DENSE_RANK() OVER (PARTITION BY [ContinentCode] ORDER BY [CurrencyUsage] DESC)
			AS [CurrencyRank]
		FROM (SELECT 
			[co].[ContinentCode],
			[c].[CurrencyCode],
			COUNT([c].[CurrencyCode]) AS [CurrencyUsage]
			  FROM [Continents] AS [co]
		LEFT JOIN [Countries] AS [c]
			ON [c].[ContinentCode] = [co].[ContinentCode]
		GROUP BY [co].[ContinentCode], [c].[CurrencyCode] 
		) AS [CurrencyUsageQuery]
	  WHERE [CurrencyUsage] > 1
	  ) AS [CurrencyRankingQuery]
	WHERE [CurrencyRank] = 1
ORDER BY [ContinentCode]


--Problem 16
SELECT COUNT(c.CountryCode) AS [CountryCode]
FROM Countries AS c
LEFT OUTER JOIN MountainsCountries AS m ON c.CountryCode = m.CountryCode
WHERE m.MountainId IS NULL

--Problem 17
SELECT TOP (5)
		[c].[CountryName],
		MAX([p].[Elevation]) AS [HighestPeakElevation],
		MAX([r].[Length]) AS [LongestRiverLength]
FROM [Countries] AS [c]
	LEFT JOIN [CountriesRivers] AS [cr]
		ON [c].[CountryCode] = [cr].[CountryCode]
	LEFT JOIN [Rivers] AS [r]
		ON [cr].[RiverId] = [r].[Id]
	LEFT JOIN [MountainsCountries] AS [mc]
		ON [mc].[CountryCode] = [c].[CountryCode]
	LEFT JOIN [Mountains] AS [m]
		ON [mc].[MountainId] = [m].[Id]
	LEFT JOIN [Peaks] AS [p]
		ON [p].[MountainId] = [m].[Id]
GROUP BY [c].[CountryName]
ORDER BY [HighestPeakElevation] DESC, [LongestRiverLength] DESC, [CountryName]


--Problem 18
SELECT TOP (5) [Country],
               CASE
                    WHEN [PeakName] IS NULL THEN '(no highest peak)'
                    ELSE [PeakName]
               END AS [Highest Peak Name],
               CASE
                    WHEN [Elevation] IS NULL THEN 0
                    ELSE [Elevation]
               END AS [Highest Peak Elevation],
               CASE
                    WHEN [MountainRange] IS NULL THEN '(no mountain)'
                    ELSE [MountainRange]
               END AS [Mountain]          
               FROM (
                       SELECT [c].[CountryName] AS [Country],
                              [m].[MountainRange],
                              [p].[PeakName],
                              [p].[Elevation],
                              DENSE_RANK() OVER(PARTITION BY [c].[CountryName] ORDER BY [p].[Elevation] DESC) 
                           AS [PeakRank]
                         FROM [Countries] AS [c]
                    LEFT JOIN [MountainsCountries] AS [mc]
                           ON [mc].[CountryCode] = [c].[CountryCode]
                    LEFT JOIN [Mountains] AS [m]
                           ON [mc].[MountainId] = [m].[Id]
                    LEFT JOIN [Peaks] AS [p]
                           ON [p].[MountainId] = [m].[Id]
                   ) AS [PeakRankingQuery]
        WHERE [PeakRank] = 1
     ORDER BY [Country], [Highest Peak Name]