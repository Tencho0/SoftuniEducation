CREATE DATABASE [CigarShop]

USE [CigarShop]

-- Problem 01
CREATE TABLE [Sizes](
[Id] INT PRIMARY KEY IDENTITY,
[Length] INT CHECK([LENGTH] BETWEEN 10 AND 25) NOT NULL,
[RingRange] DECIMAL(18, 2) CHECK([RingRange] BETWEEN 1.5 AND 7.5) NOT NULL
)

CREATE TABLE [Tastes](
[Id] INT PRIMARY KEY IDENTITY,
[TasteType] VARCHAR(20) NOT NULL,
[TasteStrength] VARCHAR(15) NOT NULL,
[ImageURL] VARCHAR(100) NOT NULL
)

CREATE TABLE [Brands](
[Id] INT PRIMARY KEY IDENTITY,
[BrandName] VARCHAR(30) NOT NULL,
[BrandDescription] VARCHAR(8000)
)

CREATE TABLE [Cigars](
[Id] INT PRIMARY KEY IDENTITY,
[CigarName] VARCHAR(80) NOT NULL,
[BrandId] INT FOREIGN KEY REFERENCES [Brands]([Id]) NOT NULL,
[TastId] INT FOREIGN KEY REFERENCES [Tastes]([Id]) NOT NULL,
[SizeId] INT FOREIGN KEY REFERENCES [Sizes]([Id]) NOT NULL,
[PriceForSingleCigar] MONEY NOT NULL,
[ImageURL] VARCHAR(100) NOT NULL
)

CREATE TABLE [Addresses](
[Id] INT PRIMARY KEY IDENTITY,
[Town] VARCHAR(30) NOT NULL,
[Country] NVARCHAR(30) NOT NULL,
[Streat] NVARCHAR(100) NOT NULL,
[ZIP] VARCHAR(20) NOT NULL
)
CREATE TABLE [Clients](
[Id] INT PRIMARY KEY IDENTITY,
[FirstName] VARCHAR(30) NOT NULL,
[LastName] VARCHAR(30) NOT NULL,
[Email] VARCHAR(50) NOT NULL,
[AddressId] INT FOREIGN KEY REFERENCES [Addresses]([Id]) NOT NULL
)

CREATE TABLE [ClientsCigars](
[ClientId] INT FOREIGN KEY REFERENCES [Clients]([Id]) NOT NULL,
[CigarId] INT FOREIGN KEY REFERENCES [Cigars]([Id]) NOT NULL,
PRIMARY KEY (ClientId, CigarId)
)


-- Problem 02
INSERT INTO [Cigars](CigarName,	BrandId, TastId,	SizeId,	PriceForSingleCigar, ImageURL)
VALUES
('COHIBA ROBUSTO',	9,	1,	5,	15.50,	'cohiba-robusto-stick_18.jpg'),
('COHIBA SIGLO I',	9,	1,	10,	410.00,	'cohiba-siglo-i-stick_12.jpg'),
('HOYO DE MONTERREY LE HOYO DU MAIRE',	14,	5,	11,	7.50,	'hoyo-du-maire-stick_17.jpg'),
('HOYO DE MONTERREY LE HOYO DE SAN JUAN',	14,	4,	15,	32.00,	'hoyo-de-san-juan-stick_20.jpg'),
('TRINIDAD COLONIALES',	2,	3,	8,	85.21,	'trinidad-coloniales-stick_30.jpg')

INSERT INTO [Addresses](Town, Country, Streat, ZIP)
VALUES
('Sofia',	'Bulgaria',	'18 Bul. Vasil levski',	'1000'),
('Athens', 'Greece','4342 McDonald Avenue',	'10435'),
('Zagreb', 'Croatia', '4333 Lauren Drive', '10000')


-- Problem 03
UPDATE [Cigars]
SET [PriceForSingleCigar] *= 1.2
WHERE [TastId] = (SELECT [Id] FROM [Tastes] WHERE [TasteType] = 'Spicy')

UPDATE [Brands]
SET [BrandDescription] = 'New description'
WHERE [BrandDescription] IS NULL


-- Problem 04
DELETE [Clients]
WHERE [AddressId] IN (SELECT [Id] FROM [Addresses] WHERE LEFT([Country], 1) = 'C')

DELETE [Addresses]
WHERE LEFT([Country], 1) = 'C' 


-- Problem 05
SELECT CigarName, PriceForSingleCigar, ImageURL
FROM [Cigars]
ORDER BY [PriceForSingleCigar], CigarName DESC


-- Problem 06
SELECT [c].Id,	CigarName,	PriceForSingleCigar, TasteType,	TasteStrength
FROM [Cigars] AS [c]
JOIN [Tastes] AS [t] ON [t].Id = [c].TastId
WHERE [TastId] IN (SELECT [Id] FROM [Tastes] WHERE [TasteType] IN ('Earthy', 'Woody'))
ORDER BY [PriceForSingleCigar] DESC


-- Problem 07
SELECT [c].[Id],
CONCAT ([c].FirstName, ' ', [c].LastName) AS [ClientName],
[c].Email
FROM [Clients] AS [c]
WHERE [c].Id NOT IN (
						SELECT [cc].ClientId FROM [ClientsCigars] AS [cc]
						GROUP BY ([cc].ClientId)
					)
ORDER BY ClientName


-- Problem 08
SELECT TOP (5) CigarName, PriceForSingleCigar, ImageURL
FROM [Cigars] AS [c]
JOIN [Sizes] AS [s] ON [s].Id = [c].SizeId
WHERE [s].[Length] >= 12 AND ([c].CigarName LIKE '%ci%' OR [c].PriceForSingleCigar > 50 AND [s].RingRange > 2.55)
ORDER BY [c].CigarName, [c].PriceForSingleCigar DESC


-- Problem 09
SELECT CONCAT([c].FirstName, ' ', [c].LastName) AS 'FullName', 
[a].Country, 
[a].ZIP, 
CONCAT('$', MAX([cg].PriceForSingleCigar)) AS 'CigarPrice'
FROM [Clients] AS [c]
JOIN [Addresses] AS [a] ON [c].AddressId = [a].Id
JOIN [ClientsCigars] AS [cc] ON [cc].ClientId = [c].Id
JOIN [Cigars] AS [cg] ON [cg].Id = [cc].CigarId
WHERE [a].[ZIP] NOT LIKE '%[^0-9]%'
GROUP BY [c].Id, [c].FirstName, [c].LastName, [a].Country, [a].ZIP
ORDER BY [FullName]


-- Problem 10
SELECT [c].LastName, 
AVG([s].[Length]) AS CiagrLength, 
CEILING(AVG([s].RingRange)) AS CiagrRingRange
FROM [ClientsCigars] AS [cc]
JOIN [Clients] AS [c] ON [cc].ClientId = [c].Id
JOIN [Cigars] AS [cg] ON [cc].CigarId = [cg].Id
JOIN [Sizes] AS [s] ON [s].Id = [cg].SizeId
GROUP BY [c].LastName
ORDER BY AVG([s].[Length])DESC


-- Problem 11
CREATE OR ALTER FUNCTION udf_ClientWithCigars(@name VARCHAR(30))
RETURNS INT
BEGIN
	RETURN
		(
			SELECT COUNT([cc].CigarId)
			FROM [Clients] AS [c]
			JOIN [ClientsCigars] AS [cc] ON [c].Id = [cc].ClientId
			WHERE [c].FirstName = @name
		)
END

SELECT dbo.udf_ClientWithCigars('Betty')


-- Problem 12
CREATE PROC usp_SearchByTaste(@taste VARCHAR(20))
AS BEGIN
	SELECT [c].CigarName, 
			CONCAT('$', [c].PriceForSingleCigar) AS Price, 
			[t].TasteType, 
			[b].BrandName, 
			CONCAT([s].[Length], ' cm') AS CigarLength, 
			CONCAT([s].[RingRange], ' cm') AS CigarRingRange
	FROM [Cigars] AS [c]
	JOIN [Brands] AS [b] ON [c].BrandId = [b].Id
	JOIN [Tastes] AS [t] ON [t].Id = [c].TastId
	JOIN [Sizes] AS [s] ON [s].Id = [c].SizeId
	WHERE [t].TasteType = @taste
	ORDER BY [s].[Length], [s].RingRange DESC
END

EXEC usp_SearchByTaste 'Woody'