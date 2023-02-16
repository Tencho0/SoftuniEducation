CREATE DATABASE [NationalTouristSitesOfBulgaria]

USE [NationalTouristSitesOfBulgaria]

CREATE TABLE [Categories](
[Id] INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE [Locations](
[Id] INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50) NOT NULL,
[Municipality] VARCHAR(50),
[Province] VARCHAR(50)
)

CREATE TABLE [Sites](
[Id] INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(100) NOT NULL,
[LocationId] INT FOREIGN KEY REFERENCES [Locations]([Id]) NOT NULL,
[CategoryId] INT FOREIGN KEY REFERENCES [Categories]([Id]) NOT NULL,
[Establishment] VARCHAR(15)
)

CREATE TABLE [Tourists](
[Id] INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50) NOT NULL,
[Age] INT NOT NULL
	CHECK ([Age] BETWEEN 0 AND 120),
[PhoneNumber] VARCHAR(20) NOT NULL,
[Nationality] VARCHAR(30) NOT NULL,
[Reward] VARCHAR(20)
)

CREATE TABLE [SitesTourists](
[TouristId] INT FOREIGN KEY REFERENCES [Tourists]([Id]) NOT NULL,
[SiteId] INT FOREIGN KEY REFERENCES [Sites]([Id]) NOT NULL,
PRIMARY KEY([TouristId], [SiteId])
)

CREATE  TABLE [BonusPrizes](
[Id] INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE [TouristsBonusPrizes](
[TouristId] INT FOREIGN KEY REFERENCES [Tourists]([Id]) NOT NULL,
[BonusPrizeId] INT FOREIGN KEY REFERENCES [BonusPrizes]([Id]) NOT NULL,
PRIMARY KEY([TouristId], [BonusPrizeId])
)

-- Problem 02
INSERT INTO [Tourists]([Name],	[Age],	[PhoneNumber],	[Nationality],	[Reward])
VALUES
	('Borislava Kazakova', 52,'+359896354244',	'Bulgaria',NULL),
	('Peter Bosh', 48,'+447911844141',	'UK',NULL),
	('Martin Smith', 29,'+353863818592',	'Ireland','Bronze badge'),
	('Svilen Dobrev', 49,'+359986584786',	'Bulgaria', 'Silver badge'),
	('Kremena Popova', 38,'+359893298604',	'Bulgaria',NULL)

INSERT INTO [Sites]([Name],	[LocationId],	[CategoryId],	[Establishment])
VALUES
	('Ustra fortress', 90, 7,	'X'),
	('Karlanovo Pyramids', 65, 7,	NULL),
	('The Tomb of Tsar Sevt', 63, 8,	'V BC'),
	('Sinite Kamani Natural Park', 17, 1,	NULL),
	('St. Petka of Bulgaria – Rupite', 92, 6,	'1994')


-- Problem 03
UPDATE [Sites]
SET [Establishment] = '(not defined)'
WHERE [Establishment] IS NULL


-- Problem 04
DELETE FROM [TouristsBonusPrizes] WHERE [BonusPrizeId]= (
	SELECT [Id] FROM [BonusPrizes] WHERE [Name] = 'Sleeping bag'
)

DELETE FROM [BonusPrizes] WHERE [Name] = 'Sleeping bag'

-- Problem 05
SELECT [Name],	[Age],	[PhoneNumber],	[Nationality]
FROM [Tourists]
ORDER BY [Nationality], [Age] DESC, [Name]

-- Problem 06
SELECT [s].[Name] AS [Site], 
		[l].[Name] AS [Location],
		[Establishment],
		[c].[Name] AS [Category]
FROM [Sites] AS [s]
JOIN [Categories] AS [c]
ON [s].CategoryId = [c].Id
JOIN [Locations] AS [l]
ON [l].Id = [s].LocationId
ORDER BY [c].[Name] DESC, [l].[Name], [s].[Name]

-- Problem 07
SELECT [l].[Province],	
		[l].[Municipality],	
		[l].[Name] AS [Location],	
		COUNT(l.Id) AS [CountOfSites]
FROM [Locations] AS [l]
JOIN [Sites] AS [s]
ON [s].LocationId = [l].Id
WHERE [l].Province = 'Sofia'
GROUP BY [l].Id, [l].Province, l.Municipality, l.[Name]
ORDER BY COUNT(l.Id) DESC, [l].[Name]

-- Problem 08
SELECT 
	[s].[Name] AS 'Site',
	[l].[Name] AS 'Location',
	[l].Municipality,
	[l].Province,
	[s].Establishment
FROM [Sites] AS [s]
JOIN [Locations] AS [l]
ON [s].LocationId = [l].Id
WHERE (LEFT([l].[Name], 1) NOT IN ('B', 'M', 'D')) AND ([s].Establishment LIKE '%BC')
ORDER BY [s].[Name] 

-- Problem 09
SELECT [t].[Name], 
[t].Age, 
[t].PhoneNumber, 
[t].Nationality,
CASE WHEN ([bp].[Name] IS NULL) THEN '(no bonus prize)'
ELSE [bp].[Name] 
END AS  'Reward'
FROM [TouristsBonusPrizes] AS [tbp]
FULL JOIN [Tourists] AS [t]
ON [tbp].TouristId = [t].Id
LEFT JOIN [BonusPrizes] AS [bp]
ON [bp].Id = [tbp].BonusPrizeId
ORDER BY [t].[Name] 

SELECT t.Name, t.Age, t.PhoneNumber, t.Nationality,
	ISNULL(bp.Name, '(no bonus prize)') AS 'BonusPrize'
FROM Tourists AS t
LEFT JOIN TouristsBonusPrizes AS tbp ON tbp.TouristId = t.Id
LEFT JOIN BonusPrizes AS bp ON tbp.BonusPrizeId = bp.Id
ORDER BY t.Name


-- Problem 10
SELECT 
	SUBSTRING([t].[Name], CHARINDEX(' ', [t].[Name], 0), LEN([t].[Name])) AS 'LastName',
	[t].Nationality,
	[t].Age,	
	[t].PhoneNumber
FROM [SitesTourists] AS [st]
JOIN [Tourists] AS [t] ON [t].Id = [st].TouristId
JOIN [Sites] AS [s] ON [s].Id = [st].SiteId
JOIN [Categories] AS [c] ON [c].Id = [s].CategoryId
WHERE [c].Id =(
				SELECT Id FROM [Categories]
				WHERE [Name] = 'History and archaeology'
			  )
GROUP BY [t].[Name], [t].Nationality, [t].Age, [t].PhoneNumber
ORDER BY [LastName]


-- Problem 11
CREATE FUNCTION udf_GetTouristsCountOnATouristSite (@Site VARCHAR(100))
RETURNS INT
AS 
BEGIN 
RETURN (
	SELECT COUNT([t].[Id])
	FROM [Sites] AS [s]
	JOIN [SitesTourists] AS [st] ON [s].Id = [st].SiteId
	JOIN [Tourists] AS [t] ON [t].Id = [st].TouristId
	WHERE [s].[Name] = @Site
	GROUP BY [s].[Name]
)
END

SELECT dbo.udf_GetTouristsCountOnATouristSite ('Regional History Museum – Vratsa')


-- Problem 12
CREATE PROC usp_AnnualRewardLottery(@TouristName VARCHAR(50))
AS BEGIN
	SELECT [t].[Name],
	CASE WHEN COUNT([s].Id) >= 100 THEN 'Gold badge'
		 WHEN COUNT([s].Id) >= 50 THEN 'Silver badge'
		 WHEN COUNT([s].Id) >= 25 THEN 'Bronze badge'
	END AS [Reward]
	FROM [Tourists] AS [t]
	JOIN [SitesTourists] AS [st] ON [t].Id = [st].TouristId
	JOIN [Sites] AS [s] ON [st].SiteId = [s].Id
	WHERE [t].[Name] = @TouristName
	GROUP BY [t].Id, [t].[Name]

END

EXEC usp_AnnualRewardLottery 'Gerhild Lutgard'
EXEC usp_AnnualRewardLottery 'Teodor Petrov'
EXEC usp_AnnualRewardLottery 'Zac Walsh'
EXEC usp_AnnualRewardLottery 'Brus Brown'