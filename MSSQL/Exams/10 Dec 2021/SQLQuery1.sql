CREATE DATABASE [Airport]

USE [Airport]

-- Problem 01
CREATE TABLE [Passengers]
	(
		Id INT PRIMARY KEY IDENTITY, 
		FullName VARCHAR(100) UNIQUE NOT NULL,
		Email VARCHAR(50) UNIQUE NOT NULL	
	)


CREATE TABLE [Pilots]
	(
		Id INT PRIMARY KEY IDENTITY, 
		FirstName VARCHAR(30) UNIQUE  NOT NULL,
		LastName VARCHAR(30) UNIQUE  NOT NULL,
		Age TINYINT NOT NULL CHECK(Age >= 21 AND Age <= 62),
		Rating FLOAT CHECK(Rating BETWEEN 0.0 AND 10.0)
	)

CREATE TABLE [AircraftTypes]
	(
		Id INT PRIMARY KEY IDENTITY, 
		TypeName VARCHAR(30) UNIQUE NOT NULL
	)

CREATE TABLE [Aircraft]
	(
		Id INT PRIMARY KEY IDENTITY, 
		Manufacturer VARCHAR(25) NOT NULL,
		Model VARCHAR(30) NOT NULL,
		[Year] INT NOT NULL,
		FlightHours INT,
		Condition CHAR NOT NULL,
		TypeId INT NOT NULL FOREIGN KEY REFERENCES [AircraftTypes](Id)
	)

	
CREATE TABLE [PilotsAircraft]
	(
		AircraftId INT NOT NULL FOREIGN KEY REFERENCES [Aircraft](Id),
		PilotId INT NOT NULL FOREIGN KEY REFERENCES [Pilots](Id),
		PRIMARY KEY (AircraftId, PilotId)
	)

CREATE TABLE [Airports]
	(
		Id INT PRIMARY KEY IDENTITY, 
		AirportName VARCHAR(70) UNIQUE NOT NULL,
		Country VARCHAR(100) UNIQUE NOT NULL,
	)

CREATE TABLE [FlightDestinations]
	(
		Id INT PRIMARY KEY IDENTITY, 
		AirportId INT NOT NULL FOREIGN KEY REFERENCES [Airports](Id),
		[Start] DateTime NOT NULL,
		AircraftId INT NOT NULL FOREIGN KEY REFERENCES [Aircraft](Id),
		PassengerId INT NOT NULL FOREIGN KEY REFERENCES [Passengers](Id),
		TicketPrice DECIMAL(18, 2) NOT NULL DEFAULT 15
	)

-- Problem 02
SELECT * FROM [Pilots]
WHERE [Id] BETWEEN 5 AND 15

SELECT * FROM [Passengers]

INSERT INTO Passengers (FullName, Email)
	(
			SELECT 
				Concat([FirstName],' ', LastName), 
				Concat([FirstName],LastName, '@gmail.com') 
			FROM [Pilots]
			WHERE [Id] BETWEEN 5 AND 15
	)
	
-- Problem 03
UPDATE [Aircraft]
SET [Condition] = 'A'
WHERE ([Condition] IN ('C', 'B')) AND ([FlightHours] IS NULL OR [FlightHours] <= 100) AND [Year] >= 2013


-- Problem 04
DELETE FROM [Passengers]
WHERE LEN([FullName]) <= 10


-- Problem 05
SELECT 	Manufacturer, Model, FlightHours, Condition 
FROM [Aircraft]
ORDER BY [FlightHours] DESC


-- Problem 06
SELECT 
	[p].FirstName, 
	[p].LastName,
	[a].Manufacturer,
	[a].Model,
	[a].FlightHours
FROM [PilotsAircraft] AS [pa]
	INNER JOIN [Aircraft] AS [a] ON [a].Id = [pa].AircraftId
	INNER JOIN [Pilots] AS [p] ON [p].Id = [pa].PilotId
WHERE [a].FlightHours IS NOT NULL AND [a].FlightHours <=304
ORDER BY [a].FlightHours DESC, [p].FirstName 


-- Problem 07
SELECT TOP(20)
[a].[Id] AS [DestinationId], 
[a].[Start], 
[p].FullName AS [FullName], 
[ap].AirportName AS [AirportName], 
[a].[TicketPrice]
FROM FlightDestinations AS [a]
LEFT JOIN [Passengers] AS [p]
ON [p].Id = [a].PassengerId
JOIN [Airports] AS [ap]
ON [ap].Id = [a].AirportId
WHERE DATEPART(DAY, [Start]) % 2 = 0
ORDER BY [a].[TicketPrice] DESC, [ap].AirportName


-- Problem 08
SELECT [a].Id AS [AircraftId], 
		[a].Manufacturer, 
		[a].FlightHours, 
		COUNT([a].Id) AS FlightDestinationsCount, 
		ROUND(AVG(TicketPrice), 2) AS AvgPrice
FROM [FlightDestinations] AS [fd]
JOIN [Aircraft] AS [a]
ON [a].Id = [fd].AircraftId
GROUP BY [a].Id, [a].Manufacturer, [a].FlightHours
HAVING COUNT([fd].Id) >= 2
ORDER BY FlightDestinationsCount DESC, [a].Id


-- Problem 09
SELECT [p].FullName,
		COUNT([fd].Id) AS [CountOfAircraft],
		SUM([fd].TicketPrice) AS [TotalPayed]
FROM FlightDestinations AS [fd]
LEFT JOIN [Passengers] AS [p]
ON [fd].PassengerId = [p].Id
GROUP BY [p].FullName
HAVING ((COUNT([fd].Id) > 1) AND SUBSTRING([p].FullName, 2, 1) = 'a')
ORDER BY [p].FullName


-- Problem 10
 SELECT [ap].AirportName, 
		[fd].[Start] AS [DayTime], 
		[fd].TicketPrice, 
		[p].FullName, 
		[a].Manufacturer, 
		[a].Model
  FROM [FlightDestinations] AS [fd]
	LEFT JOIN [Aircraft] AS [a] 
		ON [a].Id = [fd].AircraftId
	LEFT JOIN [Passengers] AS [p] 
		ON [p].Id = [fd].PassengerId
	LEFT JOIN [Airports] AS [ap] 
		ON [ap].Id = [fd].AirportId
 WHERE (DATEPART(HOUR, [fd].[Start]) BETWEEN 6 AND 20) AND [fd].[TicketPrice] > 2500
--WHERE CAST(fd.[Start] AS TIME) BETWEEN '06:00' AND '20:00'
ORDER BY [a].Model


-- Problem 11
CREATE FUNCTION udf_FlightDestinationsByEmail(@email VARCHAR(50)) 
RETURNS INT AS
BEGIN
	DECLARE @count INT
	SET @count = (
	 SELECT COUNT([fd].[Id]) FROM [FlightDestinations] AS [fd]
	 LEFT JOIN [Passengers] AS [p]
	 ON [p].Id = [fd].PassengerId
	 WHERE [p].Email = @email
	 GROUP BY [p].Id)

	 IF(@count IS NULL)
	 BEGIN RETURN 0 END

	 RETURN @count;
END

SELECT dbo.udf_FlightDestinationsByEmail ('PierretteDunmuir@gmail.com')
SELECT dbo.udf_FlightDestinationsByEmail('Montacute@gmail.com')
SELECT dbo.udf_FlightDestinationsByEmail('MerisShale@gmail.com')


-- Problem 12
CREATE PROC usp_SearchByAirportName @airportName VARCHAR(70)
AS
BEGIN
	SELECT [a].AirportName, 
			[p].FullName, 
			CASE WHEN [fd].[TicketPrice] <= 400 THEN 'Low'
				 WHEN [fd].[TicketPrice] BETWEEN 401 AND 1500 THEN 'Medium'
				 ELSE 'High'
			  END AS LevelOfTickerPrice,
			[ac].Manufacturer,
			[ac].Condition,
			[at].TypeName
	FROM [Airports] AS [a]
	 JOIN [FlightDestinations] AS [fd] ON [a].Id = [fd].AirportId
	 JOIN [Aircraft] AS [ac] ON [ac].Id = [fd].AircraftId
	 JOIN [Passengers] AS [p] ON [fd].PassengerId = [p].Id
	 JOIN [AircraftTypes] AS [at] ON [ac].TypeId = [at].Id
	WHERE [a].AirportName = @airportName
	ORDER BY [ac].Manufacturer, [p].FullName
END

EXEC usp_SearchByAirportName 'Sir Seretse Khama International Airport'