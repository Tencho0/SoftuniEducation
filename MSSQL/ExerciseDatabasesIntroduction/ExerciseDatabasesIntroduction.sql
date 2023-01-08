CREATE DATABASE [Minions2]

USE [Minions2] 

CREATE TABLE [Minions] (
	[Id] INT PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL,
	[Age] INT NOT NULL
)

CREATE TABLE [Towns] (
	[Id] INT PRIMARY KEY,
	[Name] NVARCHAR(70) NOT NULL
)

ALTER TABLE [Minions]
ADD [TownId] INT FOREIGN KEY REFERENCES [Towns]([Id]) NOT NULL

ALTER TABLE [Minions]
ALTER COLUMN [Age] INT

GO
-- Task 04
INSERT INTO [Towns]([Id],[Name])
	VALUES
(1, 'Sofia'),
(2, 'Plovdiv'),
(3, 'Varna')

INSERT INTO [Minions]([Id], [Name], [Age], [TownId])
	VALUES
(1, 'Kevin', 22, 1),
(2, 'Bob', 15, 3),
(3, 'Steward',NULL, 2)
-- End of task 4
GO

TRUNCATE TABLE [Minions]

-- Task 7
CREATE TABLE [People](
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(200) NOT NULL,
	[Picture] VARBINARY(MAX),
	CHECK (DATALENGTH([Picture]) <= 2000000),
	[Height] DECIMAL(3,2),
	[Weight] DECIMAL(5,2),
	[Gender] CHAR(1) NOT NULL,
	CHECK([Gender] = 'm' OR [Gender] ='f'),
	[Birthdate] DATE NOT NULL,
	[Biography] NVARCHAR(MAX)
)

INSERT INTO [People]([Name], [Height], [Weight], [Gender], [Birthdate])
	VALUES
	('Pesho', 1.77, 75.2, 'm', '1998-05-25'),
	('Gosho', NULL, NULL, 'm', '1998-11-05'),
	('Maria', 1.65, 42.2, 'f', '1998-06-27'),
	('Viki', NULL , NULL, 'f', '1998-02-02'),
	('Vancho', 1.69, 77.8, 'm', '1998-03-03')

--END OF TAKS 7

SELECT * FROM [People]

ALTER TABLE [People]
ADD CONSTRAINT DF_DefaultBiography DEFAULT ('No biography provided ...') FOR [Biography]

--Task 8
CREATE TABLE [Users](
	[Id] INT PRIMARY KEY IDENTITY,
	[Username] VARCHAR(30) UNIQUE NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	[ProfilePicture] VARBINARY(MAX),
	CHECK (DATALENGTH([ProfilePicture]) <= 900000),
	[LastLoginTime] DATETIME2,
	[IsDeleted] BIT NOT NULL
)

INSERT INTO [Users]([Username], [Password],[IsDeleted])
	VALUES
	('Pesho3', 'pesho123', 0),
	('Pesho', 'pesho123', 0),
	('Gosho', 'gosho123', 0),
	('Maria', 'maria123', 1),
	('Viki', 'viki123', 1),
	('Vancho', 'vancho123', 0)
-- END OF TASK 8

SELECT * FROM [Users]

--Task 9
ALTER TABLE [Users]
DROP CONSTRAINT [PK__Users__3214EC078D60330F]

ALTER TABLE [Users]
ADD CONSTRAINT [PK_UsersCompositeIdUsername] PRIMARY KEY ([Id], [Username])
--End of task 9

--Task 11
ALTER TABLE [Users]
ADD CONSTRAINT DF_DefaultLastLoginTime DEFAULT (GETDATE()) FOR [LastLoginTime]
--End of task 11

--Task 13
CREATE DATABASE [Movies]

USE [Movies] 

CREATE TABLE [Directors](
	[Id] INT IDENTITY,
	[DirectorName] NVARCHAR(50) NOT NULL,
	[Notes] NVARCHAR(MAX)
)
CREATE TABLE [Genres](
	[Id] INT IDENTITY,
	[GenreName] NVARCHAR(50) NOT NULL,
	[Notes] NVARCHAR(MAX)
)
CREATE TABLE [Categories](
	[Id] INT IDENTITY,
	[CategoryName] NVARCHAR(50) NOT NULL,
	[Notes] NVARCHAR(MAX)
)
CREATE TABLE [Movies](
	[Id] INT IDENTITY,
	[Title] NVARCHAR(50) NOT NULL,
	[DirectorId] NVARCHAR(MAX), 
	[CopyrightYear] NVARCHAR(50) NOT NULL,
	[Length] NVARCHAR(50) NOT NULL,
	[GenreId] NVARCHAR(50) NOT NULL,
	[CategoryId] NVARCHAR(50) NOT NULL,
	[Rating] NVARCHAR(50) NOT NULL,
	[Notes] NVARCHAR(50) NOT NULL
)

ALTER TABLE Directors
ADD CONSTRAINT PK_Directors
PRIMARY KEY([Id])

ALTER TABLE Genres
ADD CONSTRAINT PK_Genres
PRIMARY KEY([Id])

ALTER TABLE Categories
ADD CONSTRAINT PK_Categories
PRIMARY KEY([Id])

ALTER TABLE Movies
ADD CONSTRAINT PK_Movies
PRIMARY KEY([Id])

INSERT INTO Directors(DirectorName,Notes)
VALUES ('Pesho', 'Pesho work hard'), 
('Mitko','Mitko work harder than Pesho'),
('Kalin', 'The exelent one'),
('Iwan', 'Perfect one!!'),
('Boro', 'Not enought good at work')

INSERT INTO Genres (GenreName, Notes)
VALUES ('HISTORY', 'Well...'),
('Action', 'Oscar'),
('History','lklllllk'),
('drama', 'lkooooopo' ),
('Triller', 'llkllkklk')

INSERT INTO Categories (CategoryName,Notes)
VALUES ('Pop', 'Some music'),
('Folk', 'Top!'),
('Hip', 'Cool music'),
('Hop', 'Chill music'),
('Mop', 'Music for workout')


INSERT INTO Movies (Title,DirectorId,CopyrightYear,[Length],GenreId,[CategoryId],Rating,Notes)
VALUES(' King' ,5,1999,78,1,5,10,'otlichen'),
('RRIRIR',4,2000,90,2,4,9,'otlichen'),
('plpppo',3,1980,100,3,3,5,'otlichen'),
('kkiklo',2,1890,20,4,2,10,'iopkll'),
('ukukkk',1,1990,120,5,1,10,'plpppp')

--End of task 13 

--Task 14

CREATE DATABASE [CarRental]

USE [CarRental] 

CREATE TABLE [Categories](
	[Id] INT IDENTITY,
	[CategoryName] NVARCHAR(50) NOT NULL,
	[DailyRate] INT NOT NULL,
	[WeeklyRate] INT NOT NULL,
	[MonthlyRate] INT NOT NULL,
	[WeekendRate] INT NOT NULL,
)
CREATE TABLE [Cars](
	[Id] INT IDENTITY,
	[PlateNumber] NVARCHAR(50) NOT NULL,
	[Manufacturer] NVARCHAR(50) NOT NULL,
	[Model] NVARCHAR(50) NOT NULL,
	[CarYear]  INT NOT NULL,
	[CategoryId] INT NOT NULL,
	[Doors] INT NOT NULL,
	[Picture] VARBINARY(MAX),
	CHECK (DATALENGTH([Picture]) <= 2000000),
	[Condition] NVARCHAR(50) NOT NULL,
	[Available] BIT
)
CREATE TABLE [Employees](
	[Id] INT IDENTITY,
	[FirstName] NVARCHAR(50) NOT NULL,
	[LastName] NVARCHAR(50) NOT NULL,
	[Title] NVARCHAR(50) NOT NULL,
	[Notes] NVARCHAR(50) NOT NULL
)
CREATE TABLE [Customers](
	[Id] INT IDENTITY,
	[DriverLicenceNumber] NVARCHAR(50) NOT NULL,
	[FullName] NVARCHAR(50) NOT NULL,
	[Address] NVARCHAR(50) NOT NULL,
	[City] NVARCHAR(50) NOT NULL,
	[ZIPCode] INT,
	[Notes] NVARCHAR(50) NOT NULL,
)
CREATE TABLE [RentalOrders](
	[Id] INT IDENTITY,
	[EmployeeId] INT NOT NULL,
	[CustomerId] INT NOT NULL,
	[CarId] INT NOT NULL,
	[TankLevel] NVARCHAR(50) NOT NULL,
	[KilometrageStart] INT NOT NULL,
	[KilometrageEnd] INT NOT NULL,
	[TotalKilometrage] INT NOT NULL,
	[StartDate]  DATE,
	[EndDate]  DATE,
	[TotalDays] INT NOT NULL,
	[RateApplied] INT NOT NULL,
	[TaxRate] INT NOT NULL,
	[OrderStatus] BIT,
	[Notes] NVARCHAR(50) NOT NULL,
)

INSERT INTO Categories(CategoryName,[DailyRate], [WeeklyRate], [MonthlyRate], [WeekendRate])
VALUES ('Sedan', 2, 14, 10, 50), 
		('Coupe', 4, 24, 20, 60),
		('Cabrio', 6, 34, 30, 70) 
		
INSERT INTO Cars([PlateNumber],[Manufacturer], [Model], [CarYear], [CategoryId], [Doors], [Condition], [Available])
VALUES ('E 1001 E', 'BMW', 'E46', 2001, 1, 4, 'Broken Car', 0), 
		('CB 1001 CB', 'VW', 'Toureg', 2003, 2, 4, 'Big Car', 1),
		('CB XAXAXA', 'Mercedes', 'S500', 2017, 3, 4, 'New Car', 1) 

INSERT INTO Employees([FirstName],[LastName], [Title], [Notes])
VALUES ('Iwan', 'Gerasimow', 'Drifter', 'Nowi gumi wsqka sedmica!!!'), 
		('Gerasim', 'Cecow', 'Truck Driver', 'Profesional driver!'),
		('Ceco', 'Gerasimow', 'Pizza Deliver', 'Fast driver!') 

INSERT INTO Customers([DriverLicenceNumber],[FullName], [Address], [City], [Notes])
VALUES ('DSADSA','Iwan Gerasimow', 'Ul.Ivan Sirakow 21', 'Novi Iskur','Nowi gumi wsqka sedmica!!!'), 
		('DSweqDSA','Gerasim Cecow', 'Ul.Ivan Sirakow 22', 'Stari Iskur','Nowi gumi wsqka sedmica!!!'), 
		('DSA23fA','Ceco Gerasimow', 'Ul.Ivan Sirakow 23', 'Renoviran Iskur','Nowi gumi wsqka sedmica!!!')

INSERT INTO RentalOrders(
[EmployeeId],
[CustomerId], 
[CarId], 
[TankLevel], 
[KilometrageStart], 
[KilometrageEnd],
[TotalKilometrage],
[TotalDays],
[RateApplied],
[TaxRate],
[OrderStatus],
[Notes])
Values(1, 1, 1, 'Full', 0, 1000, 1000,1, 1,1, 1, 'Nice trip!'),
		(2, 2, 2, 'Full', 0, 1000, 1000,2, 2, 2, 2, 'Nice trip!'),
		(3, 3, 3, 'Full', 0, 1000, 1000,3, 3, 3, 3, 'Nice trip!')

--End of task 14


--Task 15

--CREATE DATABASE [Hotel]

--USE [Hotel] 

--CREATE TABLE [Employees](
--	[Id] INT IDENTITY,
--	[FirstName] NVARCHAR(50) NOT NULL,
--	[LastName] NVARCHAR(50) NOT NULL,
--	[Title] NVARCHAR(50) NOT NULL,
--	[Notes] NVARCHAR(50) NOT NULL
--)
--CREATE TABLE [Customers](
--	[AccountNumber] INT NOT NULL,
--	[FirstName] NVARCHAR(50) NOT NULL,
--	[LastName] NVARCHAR(50) NOT NULL,
--	[PhoneNumber] NVARCHAR(50) NOT NULL,
--	[EmergencyName] NVARCHAR(50) NOT NULL,
--	[EmergencyNumber] NVARCHAR(50) NOT NULL,
--	[Notes] NVARCHAR(50)
--)
--CREATE TABLE [RoomStatus](
--	[RoomStatus] BIT,
--	[Notes] NVARCHAR(50)
--)
--CREATE TABLE [RoomTypes](
--	[RoomType] BIT,
--	[Notes] NVARCHAR(50)
--)
--CREATE TABLE [BedTypes](
--	[BedType] BIT,
--	[Notes] NVARCHAR(50)
--)
--CREATE TABLE [Rooms](
--	[RoomNumber] INT NOT NULL,
--	[RoomType] NVARCHAR(50) NOT NULL,
--	[BedType] NVARCHAR(50) NOT NULL,
--	[Rate] INT NOT NULL,
--	[RoomStatus] BIT,
--	[Notes] NVARCHAR(50)
--)
--CREATE TABLE [Payments](
--	[Id] INT IDENTITY,
--	[EmployeeId] INT NOT NULL,
--	[PaymentDate] DATE,
--	[AccountNumber] INT NOT NULL,
--	[FirstDateOccupied] DATE,
--	[LastDateOccupied] DATE,
--	[TotalDays] INT NOT NULL,
--	[AmountCharged] INT NOT NULL,
--	[TaxRate] INT NOT NULL,
--	[TaxAmount] INT NOT NULL,
--	[PaymentTotal] INT NOT NULL,
--	[Notes] NVARCHAR(50)
--)
--CREATE TABLE [Occupancies](
--	[Id] INT IDENTITY,
--	[EmployeeId] INT NOT NULL,
--	[DateOccupied] DATE,
--	[AccountNumber] INT NOT NULL,
--	[RoomNumber] INT NOT NULL,
--	[RateApplied] INT,
--	[PhoneCharge] BIT,
--	[Notes] NVARCHAR(50)
--)

--INSERT INTO Employees([FirstName],[LastName], [Title], [Notes])
--VALUES ('Iwan', 'Gerasimow', 'Drifter', 'Nowi gumi wsqka sedmica!!!'), 
--		('Gerasim', 'Cecow', 'Truck Driver', 'Profesional driver!'),
--		('Ceco', 'Gerasimow', 'Pizza Deliver', 'Fast driver!') 

--INSERT INTO Customers([AccountNumber],
--	[FirstName],
--	[LastName],
--	[PhoneNumber],
--	[EmergencyName],
--	[EmergencyNumber])
--VALUES (123,'Iwan', 'Gerasimow', '088888888', 'Iwan', '0999999999'), 
--		(223,'Iwan2', 'Gerasimow2', '0888888882', 'Iwa2n', '09999999992'), 
--		(323,'Iwan3', 'Gerasimow3', '0888888883', 'Iwan3', '09999999993')

--INSERT INTO RoomStatus([RoomStatus])
--VALUES (0),(1)

--INSERT INTO RoomTypes([RoomType])
--VALUES (0),(1)

--INSERT INTO BedTypes([BedType])
--VALUES (0),(1)

--INSERT INTO Rooms(
--	[RoomNumber],
--	[RoomType],
--	[BedType],
--	[Rate],
--	[RoomStatus])
--VALUES (1,'Garsoniera', 'big', 8, 1),
--		(2,'Apartament', 'small', 8, 0),
--		(3,'Malka staq', 'medium', 8, 1)

--INSERT INTO Payments(
--	[EmployeeId],
--	[AccountNumber],
--	[TotalDays],
--	[AmountCharged],
--	[TaxRate],
--	[TaxAmount],
--	[PaymentTotal])
--VALUES (1, 1, 1, 1, 1, 1, 1),
--		(2, 2, 2, 2, 2, 2, 2),
--		(3, 3, 3, 3, 3, 3, 3)

--INSERT INTO [Occupancies](
--	[EmployeeId],
--	[AccountNumber],
--	[RoomNumber])
--VALUES (1, 1, 1),
--		(2, 2, 2),
--		(3, 3, 3)
--End of task 15


--Task 15
CREATE TABLE Employees(
Id INT PRIMARY KEY IDENTITY NOT NULL,
FirstName VARCHAR(50),
LastName VARCHAR(50),
Title VARCHAR(50),
Notes VARCHAR(MAX)
)
 
INSERT INTO Employees
VALUES
('Velizar', 'Velikov', 'Receptionist', 'Nice customer'),
('Ivan', 'Ivanov', 'Concierge', 'Nice one'),
('Elisaveta', 'Bagriana', 'Cleaner', 'Poetesa')
 
CREATE TABLE Customers(
Id INT PRIMARY KEY IDENTITY NOT NULL,
AccountNumber BIGINT,
FirstName VARCHAR(50),
LastName VARCHAR(50),
PhoneNumber VARCHAR(15),
EmergencyName VARCHAR(150),
EmergencyNumber VARCHAR(15),
Notes VARCHAR(100)
)
 
INSERT INTO Customers
VALUES
(123456789, 'Ginka', 'Shikerova', '359888777888', 'Sistry mi', '7708315342', 'Kinky'),
(123480933, 'Chaika', 'Stavreva', '359888777888', 'Sistry mi', '7708315342', 'Lawer'),
(123454432, 'Mladen', 'Isaev', '359888777888', 'Sistry mi', '7708315342', 'Wants a call girl')
 
CREATE TABLE RoomStatus(
Id INT PRIMARY KEY IDENTITY NOT NULL,
RoomStatus BIT,
Notes VARCHAR(MAX)
)
 
INSERT INTO RoomStatus(RoomStatus, Notes)
VALUES
(1,'Refill the minibar'),
(2,'Check the towels'),
(3,'Move the bed for couple')
 
CREATE TABLE RoomTypes(
RoomType VARCHAR(50) PRIMARY KEY,
Notes VARCHAR(MAX)
)
 
INSERT INTO RoomTypes (RoomType, Notes)
VALUES
('Suite', 'Two beds'),
('Wedding suite', 'One king size bed'),
('Apartment', 'Up to 3 adults and 2 children')
 
CREATE TABLE BedTypes(
BedType VARCHAR(50) PRIMARY KEY,
Notes VARCHAR(MAX)
)
 
INSERT INTO BedTypes
VALUES
('Double', 'One adult and one child'),
('King size', 'Two adults'),
('Couch', 'One child')
 
CREATE TABLE Rooms (
RoomNumber INT PRIMARY KEY IDENTITY NOT NULL,
RoomType VARCHAR(50) FOREIGN KEY REFERENCES RoomTypes(RoomType),
BedType VARCHAR(50) FOREIGN KEY REFERENCES BedTypes(BedType),
Rate DECIMAL(6,2),
RoomStatus NVARCHAR(50),
Notes NVARCHAR(MAX)
)
 
INSERT INTO Rooms (Rate, Notes)
VALUES
(12,'Free'),
(15, 'Free'),
(23, 'Clean it')
 
CREATE TABLE Payments(
Id INT PRIMARY KEY IDENTITY NOT NULL,
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
PaymentDate DATE,
AccountNumber BIGINT,
FirstDateOccupied DATE,
LastDateOccupied DATE,
TotalDays AS DATEDIFF(DAY, FirstDateOccupied, LastDateOccupied),
AmountCharged DECIMAL(14,2),
TaxRate DECIMAL(8, 2),
TaxAmount DECIMAL(8, 2),
PaymentTotal DECIMAL(15, 2),
Notes VARCHAR(MAX)
)
 
INSERT INTO Payments (EmployeeId, PaymentDate, AmountCharged)
VALUES
(1, '12/12/2018', 2000.40),
(2, '12/12/2018', 1500.40),
(3, '12/12/2018', 1000.40)
 
CREATE TABLE Occupancies(
Id  INT PRIMARY KEY IDENTITY NOT NULL,
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
DateOccupied DATE,
AccountNumber BIGINT,
RoomNumber INT FOREIGN KEY REFERENCES Rooms(RoomNumber),
RateApplied DECIMAL(6,2),
PhoneCharge DECIMAL(6,2),
Notes VARCHAR(MAX)
)
 
INSERT INTO Occupancies (EmployeeId, RateApplied, Notes) VALUES
(1, 55.55, 'too'),
(2, 15.55, 'much'),
(3, 35.55, 'typing')
--End of task 15



CREATE DATABASE [SoftUni]
USE [SoftUni]
CREATE TABLE Towns(
	[Id] INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] NVARCHAR(50) NOT NULL
)
CREATE TABLE[Addresses](
	[Id] INT PRIMARY KEY IDENTITY NOT NULL,
	[AddressText] NVARCHAR(50) NOT NULL,
	[TownId] INT NOT NULL
)
CREATE TABLE Departments(
	[Id] INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] NVARCHAR(50) NOT NULL
)
CREATE TABLE [Employees](
	[Id] INT PRIMARY KEY IDENTITY NOT NULL,
	[FirstName] NVARCHAR(50) NOT NULL,
	[MiddleName] NVARCHAR(50) NOT NULL,
	[LastName] NVARCHAR(50) NOT NULL,
	[JobTitle] NVARCHAR(50) NOT NULL,
	[DepartmentId] INT NOT NULL,
	[HireDate] DATE,
	[Salary] INT NOT NULL,
	[AddressId] INT NOT NULL
)

INSERT INTO [dbo].[Towns]([Name])
VALUES('Sofia'), ('Plovdiv'), ('Varna'), ('Burgas')

INSERT INTO [dbo].[Departments]([Name])
VALUES('Engineering'), ('Sales'),('Marketing'), ('Software Development'), ('Quality Assurance')

INSERT INTO [dbo].[Employees]([FirstName], [MiddleName], [LastName], [JobTitle], [DepartmentId], [HireDate], [Salary], [AddressId])
VALUES	('Ivan','Ivanov','Ivanov', '.NET Developer', 4, '01/02/2013', 3500.00, 1),
		('Peter','Petrov','Petrov', 'Senior Engineer', 1, '02/03/2004', 4000.00, 2),
		('Maria','Petrova','Ivanova', 'Intern', 5, '28/08/2016', 525.25, 3),
		('Georgi','Terziev','Ivanov', 'CEO', 2, '09/12/2007', 3000.00,4),
		('Peter','Pan','Pan', 'Intern', 3, '28/08/2016', 599.88,1)


--Task 19
SELECT * FROM Towns
SELECT * FROM Departments
SELECT * FROM Employees
-- End of taks 19

--Task 20
SELECT *  FROM Towns order by [Name]
SELECT *  FROM Departments order by [Name]
SELECT *  FROM Employees order by [Salary] DESC
--End of task 20

--Task 21
SELECT [Name] FROM Towns order by [Name]
SELECT [Name] FROM Departments order by [Name]
SELECT [FirstName], [LastName], [JobTitle], [Salary] FROM Employees order by [Salary] DESC
--End of task 21

--Task 22
UPDATE Employees 
SET 
    Salary = Salary * 1.1
WHERE
    Salary IS NOT NULL
SELECT [Salary] FROM Employees --order by [Salary] DESC
--End of task 22 


-- Task	22.Increase Employees Salary
UPDATE Employees
  SET
      Salary *= 1.10;

SELECT [Salary]
FROM Employees;
--End of taks 24


-- Task 23.Decrease Tax Rate
USE Hotel;

-- ALTER TABLE Payments
-- DROP CONSTRAINT [CK_TaxAmount];

UPDATE Payments
  SET
      TaxRate = TaxRate - (TaxRate * 0.03);

SELECT TaxRate
FROM Payments;
--End of taks 23

--Task 24.Delete All Records
TRUNCATE TABLE Occupancies;
--End of taks 24