CREATE DATABASE [Zoo]

USE [Zoo]

-- Problem 01
CREATE TABLE Owners(
	Id INT PRIMARY KEY IDENTITY,
	Name VARCHAR(50) NOT NULL,
	PhoneNumber VARCHAR(15) NOT NULL,
	Address VARCHAR(50),
)

CREATE TABLE [AnimalTypes] 
	(
		[Id] INT PRIMARY KEY IDENTITY,
		[AnimalType] VARCHAR(30) NOT NULL,
	)

CREATE TABLE [Cages] 
	(
		[Id] INT PRIMARY KEY IDENTITY,
		AnimalTypeId INT NOT NULL FOREIGN KEY REFERENCES AnimalTypes(Id),
	)
	
CREATE TABLE [Animals] 
	(
		[Id] INT PRIMARY KEY IDENTITY,
		[Name] VARCHAR(30) NOT NULL,
		[BirthDate] DATE NOT NULL,
		OwnerId INT FOREIGN KEY REFERENCES Owners(Id),
		AnimalTypeId INT NOT NULL FOREIGN KEY REFERENCES AnimalTypes(Id)
	)

	
CREATE TABLE [AnimalsCages] 
	(
		[CageId] INT NOT NULL FOREIGN KEY REFERENCES [Cages]([Id]),
		[AnimalId] INT NOT NULL FOREIGN KEY REFERENCES [Animals]([Id]),
		PRIMARY KEY ([CageId], [AnimalId])
	)
	
CREATE TABLE [VolunteersDepartments] 
	(
		[Id] INT PRIMARY KEY IDENTITY,
		[DepartmentName] VARCHAR(30) NOT NULL
	)
	
CREATE TABLE [Volunteers] 
	(
		[Id] INT PRIMARY KEY IDENTITY,
		[Name] VARCHAR(50) NOT NULL,
		[PhoneNumber] VARCHAR(15) NOT NULL,
		[Address] VARCHAR(50),
		[AnimalId] INT FOREIGN KEY REFERENCES [Animals]([Id]),
		[DepartmentId] INT FOREIGN KEY REFERENCES [VolunteersDepartments]([Id]) NOT NULL
	)


--Problem 02
INSERT INTO Volunteers(Name, PhoneNumber, Address, AnimalId, DepartmentId)	
	VALUES 
	('Anita Kostova', '0896365412','Sofia, 5 Rosa str.', 15,	1),
	('Dimitur Stoev', '0877564223', null , 42,	4),
	('Kalina Evtimova', '0896321112','Silistra, 21 Breza str.', 9, 7),
	('Stoyan Tomov', '0898564100','Montana, 1 Bor str.', 18, 8),
	('Boryana Mileva', '0888112233', null, 31,	5)

INSERT INTO Animals(Name, BirthDate, OwnerId, AnimalTypeId)	
	VALUES 
	('Giraffe', '2018-09-21', 21, 1), 
	('Harpy Eagle', '2015-04-17', 15, 3), 
	('Hamadryas Baboon', '2017-11-02', null, 1), 
	('Tuatara', '2021-06-30', 2, 4)


-- Problem 03
UPDATE [Animals]
SET OwnerId = (
				SELECT [Id] FROM [Owners]
				WHERE Name = 'Kaloqn Stoqnov'
			  )
WHERE OwnerId IS NULL


-- Problem 04
DELETE FROM [Volunteers]
WHERE DepartmentId =(
						SELECT [Id] FROM [VolunteersDepartments]
						WHERE DepartmentName = 'Education program assistant'
					 )

DELETE FROM [VolunteersDepartments]
WHERE DepartmentName = 'Education program assistant'

-- Problem 05
SELECT Name, PhoneNumber, Address, AnimalId, DepartmentId
FROM Volunteers
ORDER BY Name, AnimalId, DepartmentId

-- Problem 06
   SELECT 
		[a].Name, 
		[at].AnimalType,
		FORMAT([a].BirthDate, 'dd.MM.yyyy') AS [BirthDate]
	FROM Animals AS [a]
		LEFT JOIN [AnimalTypes] AS [at]
		ON [a].AnimalTypeId = [at].Id
ORDER BY Name


-- Problem 07
SELECT TOP (5)
		[o].[Name] AS [Owner], 
		COUNT([a].Id) AS[CountOfAnimals]
FROM [Owners] AS [o]
LEFT JOIN [Animals] AS [a]
ON [a].[OwnerId] = [o].[Id] 
GROUP BY [o].Name
ORDER BY [CountOfAnimals] DESC, [Owner]

--SELECT TOP (5)
--		[o].Name, 
--		COUNT([a].Id) AS[CountOfAnimals]
--FROM [Animals] AS [a]
--LEFT JOIN [Owners] AS [o]
--ON [a].OwnerId = [o].Id 
--WHERE [a].OwnerId IS NOT NULL
--GROUP BY [o].Name
--ORDER BY [CountOfAnimals] DESC


-- Problem 08
SELECT CONCAT(o.Name, '-', a.Name) as OwnersAnimals , o.PhoneNumber, c.Id as CageId
FROM Owners AS o
JOIN Animals AS a ON a.OwnerId = o.id
JOIN AnimalTypes AS at ON at.Id = a.AnimalTypeId
JOIN AnimalsCages AS ac ON ac.AnimalId = a.Id
JOIN Cages AS c ON c.Id = ac.CageId
WHERE AnimalType = 'Mammals'
ORDER BY o.Name, a.Name DESC

--	SELECT 
--			CONCAT([o].Name, '-',[a].Name) AS [OwnersAnimals],	
--			[o].PhoneNumber,
--			[ac].CageId
--	FROM [Animals] AS [a]
--	  JOIN [AnimalTypes] AS [at]
--      ON [a].AnimalTypeId = [at].Id
--		JOIN [Owners] AS [o]
--		ON [a].OwnerId = [o].Id 
--			JOIN [AnimalsCages] AS [ac]
--			ON [ac].AnimalId = [a].Id
--	WHERE [at].AnimalType = 'Mammals'
--ORDER BY [o].Name, [a].Name DESC


-- Problem 09
SELECT 
[v].Name,
[v].PhoneNumber,
--LTRIM (REPLACE(REPLACE([v].Address, 'Sofia', ''), ',', '')) AS Address
SUBSTRING(Address, CHARINDEX(',', Address) + 2, LEN(v.Address)) AS Address
FROM [Volunteers] AS [v]
LEFT JOIN [VolunteersDepartments] AS [vd]
ON [v].DepartmentId = [vd].Id
WHERE [vd].DepartmentName = 'Education program assistant' AND [v].Address LIKE '%Sofia%'
ORDER BY [v].Name

-- Problem 10
SELECT 
	[a].Name, 
	YEAR([a].BirthDate) AS [BirthYear], 
	[at].AnimalType
FROM Animals AS [a]
JOIN [AnimalTypes] AS [at]
ON [a].AnimalTypeId = [at].Id
WHERE [a].OwnerId IS NULL AND [at].AnimalType <> 'Birds' AND DATEDIFF(YEAR, [a].BirthDate, '01/01/2022') < 5
ORDER BY [a].Name

GO
-- Problem 11
CREATE FUNCTION udf_GetVolunteersCountFromADepartment (@VolunteersDepartment VARCHAR(30)) 
	RETURNS INT AS 
			BEGIN
			          DECLARE @departmentId INT;
                    SET @departmentId = (
                                            SELECT [Id]
                                              FROM [VolunteersDepartments]
                                             WHERE [DepartmentName] = @VolunteersDepartment
                                        );
 
                    DECLARE @departmentVoluntersCount INT;
                    SET @departmentVoluntersCount = (
                                                        SELECT COUNT(*)
                                                          FROM [Volunteers]
                                                         WHERE [DepartmentId] = @departmentId
                                                    );
 
                    RETURN @departmentVoluntersCount;      

			END
	
	--RETURN (SELECT COUNT([v].Id) FROM VolunteersDepartments AS [vd]
	--LEFT JOIN [Volunteers] AS [v]
	--ON [v].DepartmentId = [vd].Id
	--WHERE [vd].[DepartmentName] = @VolunteersDepartment
	--GROUP BY [v].DepartmentId)

	--RETURN(SELECT COUNT(v.Id) FROM Volunteers AS v
	--JOIN VolunteersDepartments AS vd ON vd.Id = v.DepartmentId
	--WHERE vd.DepartmentName = @VolunteersDepartment)
GO
SELECT dbo.udf_GetVolunteersCountFromADepartment ('Education program assistant')



GO
-- Problem 12
CREATE PROC [usp_AnimalsWithOwnersOrNot](@AnimalName VARCHAR(30))
	AS
		BEGIN
				
				SELECT [a].[Name],
                              ISNULL([o].[Name], 'For adoption') AS [OwnersName]
                         FROM [Animals] AS [a]
                    LEFT JOIN [Owners] AS [o]
                           ON [a].[OwnerId] = [o].[Id]
                        WHERE [a].[Name] = @AnimalName

	--IF (SELECT OwnerId FROM Animals
	--		WHERE Name = @AnimalName) IS NULL
	--BEGIN 
	--	SELECT Name, 'For adoption' AS OwnerName
	--		FROM Animals
	--		WHERE Name = @AnimalName
	--END
	--ELSE
	--BEGIN
	--	SELECT a.Name, o.Name as OwnerName
	--		FROM Animals AS a
	--		JOIN Owners AS o ON o.Id = a.OwnerId
	--		WHERE a.Name = @AnimalName
	--END

				--DECLARE @ownerId INT;
				--SET @ownerId = (
				--					SELECT [OwnerId] FROM [Animals]
				--					WHERE [Name] = @AnimalName
				--				   )

				--DECLARE @ownerName VARCHAR(30);
				--IF (@ownerId IS NULL)
				--	BEGIN
				--		SET @ownerName = 'For adoption';
				--	END
				--ELSE 
				--	BEGIN
				--		SET @ownerName = (SELECT [Name] 
				--					FROM [Owners]
				--					WHERE [Id] = @ownerId)
				--	END

				--SELECT 
				--	@AnimalName AS [Name],
				--	@ownerName AS [OwnersName]
		END

GO
EXEC usp_AnimalsWithOwnersOrNot 'Pumpkinseed Sunfish'