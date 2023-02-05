USE [SoftUni]

-- Problem 01
CREATE PROCEDURE [usp_GetEmployeesSalaryAbove35000]
		AS
		BEGIN
			SELECT [FirstName], [LastName] FROM Employees WHERE [Salary] > 35000
		END

EXEC [dbo].[usp_GetEmployeesSalaryAbove35000]

-- Problem 02
CREATE PROCEDURE [usp_GetEmployeesSalaryAboveNumber] @minSalary DECIMAL(18,4)
			AS
			BEGIN
			SELECT [FirstName], [LastName] FROM Employees WHERE [Salary] >= @minSalary
			END

EXEC [dbo].[usp_GetEmployeesSalaryAboveNumber] 48100


-- Problem 03
CREATE PROCEDURE [usp_GetTownsStartingWith] @inputParameter VARCHAR(50)
		AS 
		BEGIN
			SELECT [Name] 
			FROM [Towns]
			WHERE SUBSTRING([Name], 1, LEN(@inputParameter)) = @inputParameter
		END

		--CREATE PROC usp_GetTownsStartingWith(@searchedString NVARCHAR(50))
		--	AS
		--	BEGIN
		--		 DECLARE @stringCount int = LEN(@searchedString)
		--	SELECT [Name] FROM Towns
		--	WHERE LEFT([Name],@stringCount) = @searchedString
		--	END

		EXEC [dbo].[usp_GetTownsStartingWith] 'b'

-- Problem 04
CREATE PROCEDURE [usp_GetEmployeesFromTown] @townName VARCHAR(50)
		AS
		BEGIN
			SELECT [FirstName], [LastName] FROM [Employees] AS [e]
			JOIN Addresses AS [a]
			ON a.AddressID = e.AddressID
			JOIN Towns AS [t]
			ON t.TownID = a.TownID
			WHERE [t].[Name] = @townName
		END

EXEC [dbo].[usp_GetEmployeesFromTown] 'Sofia'


-- Problem 05
CREATE FUNCTION [ufn_GetSalaryLevel](@salary DECIMAL(18,4))
RETURNS VARCHAR(8)
AS 
BEGIN
	DECLARE @salaryLevel VARCHAR(8)

	IF @salary < 30000
	BEGIN
		SET @salaryLevel = 'Low'
	END
	ELSE IF @salary BETWEEN 30000 AND 50000
	BEGIN
		SET @salaryLevel = 'Average'
	END
	ELSE IF @salary > 50000
	BEGIN
		SET @salaryLevel = 'High' 
	END

	RETURN @salaryLevel
END

-- Problem 06
CREATE PROCEDURE [usp_EmployeesBySalaryLevel] @salaryLevel VARCHAR(8)
		AS
		BEGIN
			SELECT [FirstName], [LastName] FROM [Employees]
			WHERE [dbo].[ufn_GetSalaryLevel]([Salary]) = @salaryLevel
		END
EXEC [dbo].[usp_EmployeesBySalaryLevel] 'High'


-- Problem 07
CREATE OR ALTER FUNCTION [ufn_IsWordComprised](@setOfLetters VARCHAR(50), @word VARCHAR(50))
	RETURNS BIT
			AS 
	     BEGIN
				DECLARE @wordIndex int = 1;
				WHILE (@wordIndex <= LEN(@word))
					BEGIN 
						DECLARE @currentCharacter CHAR = SUBSTRING(@word, @wordIndex, 1);

						IF CHARINDEX(@currentCharacter, @setOfLetters) = 0
						BEGIN
						RETURN 0;
						END

						SET  @wordIndex += 1;
					END

			RETURN 1;
		   END

SELECT [dbo].[ufn_IsWordComprised]('oistmiahf', 'Sofia');
SELECT [dbo].[ufn_IsWordComprised]('pppp', 'Sofia');


-- Problem 08
CREATE PROCEDURE usp_DeleteEmployeesFromDepartment (@departmentId INT) 
		AS 
		BEGIN
			DECLARE @employeesToDelete TABLE ([Id] INT)

			INSERT INTO @employeesToDelete
				SELECT [EmployeeID]
				FROM [Employees]
				WHERE [DepartmentID] = @departmentId
			
			DELETE FROM [EmployeesProjects] WHERE [EmployeeID] IN (SELECT [Id] FROM @employeesToDelete)

			ALTER TABLE [Departments]
			ALTER COLUMN [ManagerID] INT
			
			UPDATE [Departments]
			   SET [ManagerID] = NULL
			 WHERE [ManagerID] IN (
										SELECT * FROM @employeesToDelete
		           			      )

			UPDATE [Employees]
			   SET [ManagerID] = NULL
			 WHERE [ManagerID] IN (
										SELECT * FROM @employeesToDelete
								  )
			DELETE 
			FROM [Employees]
			WHERE [DepartmentID] = @departmentId

			DELETE 
			FROM [Departments]
			WHERE [DepartmentID] = @departmentId

			SELECT COUNT (*)
			  FROM [Employees]
			 WHERE [DepartmentID] = @departmentId
		END 


USE [Bank]
-- Problem 09
CREATE PROCEDURE [usp_GetHoldersFullName]
		AS
		BEGIN
			SELECT CONCAT([FirstName], ' ', [LastName]) AS [FullName]
			FROM [AccountHolders]
		END
		

-- Problem 10
CREATE OR ALTER PROCEDURE [usp_GetHoldersWithBalanceHigherThan] @inputParameter MONEY 
		AS 
		BEGIN
			SELECT [FirstName], [LastName] FROM [Accounts] AS [a]
			JOIN [AccountHolders] AS [ah]
			ON [ah].Id = [a].[AccountHolderId]
			WHERE [Balance] > @inputParameter
			ORDER BY [FirstName], [LastName]
		END

EXEC [dbo].[usp_GetHoldersWithBalanceHigherThan] 10000

CREATE PROCEDURE usp_GetHoldersWithBalanceHigherThan
(
	@sum MONEY
)
AS
BEGIN 
	SELECT FirstName AS [First Name], LastName AS [Last Name] FROM
	(
		SELECT FirstName, LastName, SUM(a.Balance) AS TotalBalance FROM AccountHolders AS ah
		JOIN Accounts AS a
		ON a.AccountHolderId = ah.Id
		GROUP BY ah.FirstName, ah.LastName
	) AS tb
	WHERE tb.TotalBalance > @sum
			ORDER BY [FirstName], [LastName]
END

		
-- Problem 11
CREATE FUNCTION ufn_CalculateFutureValue (@sum DECIMAL(18,4), @yearlyInterestRate FLOAT, @numberOfYears INT)
RETURNS DECIMAL(18,4)
BEGIN
    DECLARE @FutureValue DECIMAL(18,4);

    SET @FutureValue = @Sum * POWER((1 + @YearlyInterestRate), @NumberOfYears)
    
    RETURN @FutureValue
END
		
-- Problem 12
CREATE PROC usp_CalculateFutureValueForAccount (@AccountId INT, @InterestRate FLOAT) AS
SELECT a.Id AS [Account Id],
	   ah.FirstName AS [First Name],
	   ah.LastName AS [Last Name],
	   a.Balance,
	   dbo.ufn_CalculateFutureValue(Balance, @InterestRate, 5) AS [Balance in 5 years]
  FROM AccountHolders AS ah
  JOIN Accounts AS a ON ah.Id = a.Id
 WHERE a.Id = @AccountId


USE [Diablo]		
-- Problem 13
CREATE FUNCTION ufn_CashInUsersGames(@gameName NVARCHAR(50))
  RETURNS TABLE
             AS
         RETURN
                (
                    SELECT SUM([Cash])
                        AS [SumCash]
                      FROM (
                                SELECT [g].[Name],
                                       [ug].[Cash],
                                       ROW_NUMBER() OVER(ORDER BY [ug].[Cash] DESC)
                                    AS [RowNumber]
                                  FROM [UsersGames]
                                    AS [ug]
                            INNER JOIN [Games]
                                    AS [g]
                                    ON [ug].[GameId] = [g].[Id]
                                 WHERE [g].[Name] = @gameName
                           ) 
                        AS [RankingSubQuery]
                     WHERE [RowNumber] % 2 <> 0
                )
 
SELECT * FROM [dbo].[ufn_CashInUsersGames]('Love in a mist')