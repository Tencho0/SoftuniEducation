CREATE DATABASE [Service]

USE [Service]

CREATE TABLE [Users](
	[Id] INT PRIMARY KEY IDENTITY, 
	[Username] VARCHAR(30) UNIQUE NOT NULL,
	[Password] VARCHAR(50) NOT NULL,
	[Name] VARCHAR(50),
	[Birthdate] DateTime,
	[Age] INT CHECK([Age] BETWEEN 14 AND 110),
	[Email] VARCHAR(50) NOT NULL
)

CREATE TABLE [Departments](
	[Id] INT PRIMARY KEY IDENTITY, 
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE [Employees](
	[Id] INT PRIMARY KEY IDENTITY, 
	[FirstName] VARCHAR(25),
	[LastName] VARCHAR(25),
	[Birthdate] DateTime,
	[Age] INT CHECK([Age] BETWEEN 18 AND 110),
	[DepartmentId] INT FOREIGN KEY REFERENCES [Departments]([Id])
)

CREATE TABLE [Categories](
	[Id] INT PRIMARY KEY IDENTITY, 
	[Name] VARCHAR(50) NOT NULL,
	[DepartmentId] INT FOREIGN KEY REFERENCES [Departments]([Id]) NOT NULL
)

CREATE TABLE [Status](
	[Id] INT PRIMARY KEY IDENTITY, 
	[Label] VARCHAR(20) NOT NULL
)

CREATE TABLE [Reports](
	[Id] INT PRIMARY KEY IDENTITY, 
	[CategoryId] INT FOREIGN KEY REFERENCES [Categories]([Id]) NOT NULL,
	[StatusId] INT FOREIGN KEY REFERENCES [Status]([Id]) NOT NULL,
	[OpenDate] DateTime NOT NULL,
	[CloseDate] DateTime,
	[Description] VARCHAR(200) NOT NULL,
	[UserId] INT FOREIGN KEY REFERENCES [Users]([Id]) NOT NULL,
	[EmployeeId] INT FOREIGN KEY REFERENCES [Employees]([Id])
)

-- Problem 02
INSERT INTO [Employees](FirstName, LastName, Birthdate, DepartmentId)
VALUES
('Marlo', 'O''Malley', '1958-9-21',	1),
('Niki', 'Stanaghan', '1969-11-26',	4),
('Ayrton', 'Senna',	'1960-03-21', 9),
('Ronnie', 'Peterson', '1944-02-14', 9),
('Giovanna', 'Amati', '1959-07-20', 5)

INSERT INTO [Reports](CategoryId, StatusId, OpenDate, CloseDate, [Description], UserId, EmployeeId)
VALUES
(1,	1, '2017-04-13', NULL, 'Stuck Road on Str.133',	6,	2),
(6,	3,	'2015-09-05',	'2015-12-06',	'Charity trail running', 3, 5),
(14, 2,	'2015-09-07', NULL, 'Falling bricks on Str.58',	5,2),
(4,	3,	'2017-07-03',	'2017-07-06',	'Cut off streetlight on Str.11',1,	1)


-- Problem 03
UPDATE [Reports]
SET [CloseDate] = GETDATE()
WHERE [CloseDate] IS NULL


-- Problem 04
DELETE [Reports]
WHERE [StatusId] = 4


-- Problem 05
SELECT [Description],
	FORMAT(OpenDate, 'dd-MM-yyyy')
FROM [Reports]
WHERE [EmployeeId] IS NULL
ORDER BY [OpenDate], [Description]

-- Problem 06
SELECT 	[r].[Description],	[c].[Name]
FROM [Reports] AS [r]
JOIN [Categories] AS [c] ON [c].Id = [r].CategoryId
WHERE [r].[CategoryId] IS NOT NULL
ORDER BY [r].[Description], [c].[Name]

-- Problem 07
SELECT TOP(5) [c].[Name] AS CategoryName, 
COUNT([r].Id) AS ReportsNumber
FROM [Categories] AS [c]
JOIN [Reports] AS [r] ON [c].Id = [r].CategoryId
GROUP BY [c].Id, [c].[Name]
ORDER BY[ReportsNumber] DESC, [c].[Name]

-- Problem 08
SELECT 	[u].[Username] AS Username, 
		[c].[Name] AS CategoryName 
FROM [Users] AS [u]
JOIN [Reports] AS [r] ON [r].UserId = [u].Id
JOIN [Categories] AS [c] ON [r].CategoryId = [c].Id
WHERE FORMAT([r].OpenDate, 'dd-MM') = FORMAT([u].Birthdate, 'dd-MM')
ORDER BY [u].[Username], [c].[Name]


-- Problem 09
SELECT  CONCAT([e].FirstName, ' ', [e].LastName) AS FullName, 
		COUNT([u].Id) AS UsersCount
FROM [Employees] AS [e]
LEFT JOIN [Reports] AS [r] ON [r].EmployeeId = [e].Id
LEFT JOIN [Users] AS [u] ON [r].UserId = [u].Id
GROUP BY [e].Id, [e].FirstName, [e].LastName
ORDER BY [UsersCount] DESC, FullName

-- Problem 10
SELECT ISNULL(e.FirstName + ' ' + e.LastName, 'None') AS Employee,
		ISNULL(d.Name, 'None') AS Department,
		c.Name AS Category,
		r.Description,
		FORMAT(r.OpenDate, 'dd.MM.yyyy') AS OpenDate,
		s.[Label] AS [Status],
		ISNULL(u.Name, 'None') AS [User]
		FROM Reports AS r
   LEFT JOIN Employees AS e ON e.Id = r.EmployeeId
   LEFT JOIN Categories AS c ON c.Id = r.CategoryId
   LEFT JOIN Departments AS d ON d.Id = e.DepartmentId
   LEFT JOIN Status AS s ON s.Id = r.StatusId
   LEFT JOIN Users AS u ON u.Id = r.UserId
   ORDER BY e.FirstName DESC,
			e.LastName DESC,
			d.Name ASC,
			c.Name ASC,
			r.Description ASC,
			r.OpenDate ASC,
			s.Id ASC,
			u.Name ASC


--Problem 11
CREATE FUNCTION udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME)
RETURNS INT AS
BEGIN
	DECLARE @hoursToComplete INT = DATEDIFF(HOUR, @StartDate, @EndDate)
		IF (@StartDate IS NULL OR @EndDate IS NULL)
			RETURN 0
		RETURN @hoursToComplete		
END

SELECT dbo.udf_HoursToComplete(OpenDate, CloseDate) AS TotalHours
   FROM Reports

   
--Problem 12
CREATE PROC usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT) 
AS 
BEGIN
	DECLARE @employeeDepartment INT = (SELECT DepartmentId
											FROM Employees
											WHERE Id = @EmployeeId)

	DECLARE @reportDepartment INT = (SELECT c.DepartmentId
										FROM Reports AS r
										JOIN Categories AS c
										  ON c.Id = r.CategoryId
									   WHERE r.Id = @ReportId)

IF @employeeDepartment != @reportDepartment
	THROW 50001, 'Employee doesn''t belong to the appropriate department!', 1

ELSE
	UPDATE Reports
	SET EmployeeId = @EmployeeId
	WHERE Id = @ReportId
END

EXEC usp_AssignEmployeeToReport 30, 1