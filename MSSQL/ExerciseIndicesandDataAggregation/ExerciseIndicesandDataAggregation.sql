USE [Gringotts]

--Problem 1
SELECT COUNT(*)
FROM [WizzardDeposits]

--Problem 2
SELECT 
	MAX(MagicWandSize) AS [LongestMagicWand]
FROM [WizzardDeposits]

--Problem 3
SELECT 
	[DepositGroup] AS [DepositGroup],
	MAX(MagicWandSize) AS [LongestMagicWand]
FROM [WizzardDeposits]
GROUP BY [DepositGroup]

--Problem 4
SELECT TOP (2)
	[DepositGroup] AS [DepositGroup]
FROM [WizzardDeposits]
GROUP BY [DepositGroup]
ORDER BY AVG(MagicWandSize) 

--Problem 05
SELECT [DepositGroup],
	SUM([DepositAmount]) AS [TotalSum]
FROM [WizzardDeposits]
GROUP BY [DepositGroup]

--Problem 06
SELECT [DepositGroup],
	SUM([DepositAmount]) AS [TotalSum]
FROM [WizzardDeposits]
WHERE [MagicWandCreator] = 'Ollivander family'
GROUP BY [DepositGroup]

--Problem 07
SELECT [DepositGroup],
	SUM([DepositAmount]) AS [TotalSum]
FROM [WizzardDeposits]
WHERE [MagicWandCreator] = 'Ollivander family'
GROUP BY [DepositGroup]
HAVING Sum([DepositAmount]) < 150000
ORDER BY [TotalSum] DESC

--Problem 08
SELECT [DepositGroup], 
		[MagicWandCreator] AS [MagicWandCreator], 
		MIN([DepositCharge]) AS [MinDepositCharge] 
FROM WizzardDeposits
GROUP BY DepositGroup, MagicWandCreator
ORDER BY MagicWandCreator, DepositGroup

--Problem 09
SELECT [AgeGroup],
	COUNT (*)
	AS [WizzardCount]
FROM 
(
	SELECT [Age],
		CASE 
			WHEN [Age] BETWEEN 0 AND 10 THEN '[0-10]'
			WHEN [Age] BETWEEN 11 AND 20 THEN '[11-20]'
			WHEN [Age] BETWEEN 21 AND 30 THEN '[21-30]'
			WHEN [Age] BETWEEN 31 AND 40 THEN '[31-40]'
			WHEN [Age] BETWEEN 41 AND 50 THEN '[41-50]'
			WHEN [Age] BETWEEN 51 AND 60 THEN '[51-60]'
			WHEN [Age] >= 61 THEN '[61+]'
		END
	  AS [AgeGroup]
	FROM [WizzardDeposits]
) AS [AgeGroupingSubQuery]
GROUP BY [AgeGroup]

--Problem 10
SELECT DISTINCT LEFT([FirstName], 1) AS [FirstLetter]
FROM [WizzardDeposits]
WHERE [DepositGroup] = 'Troll Chest'
GROUP BY [FirstName]
ORDER BY [FirstLetter]


--Problem 11
SELECT [DepositGroup],
		[IsDepositExpired],
		AVG([DepositInterest]) AS [AverageInterest]
FROM [WizzardDeposits]
WHERE [DepositStartDate] > '01/01/1985'
GROUP BY [DepositGroup], [IsDepositExpired]
ORDER BY [DepositGroup] DESC, [IsDepositExpired]


--==Problem 12

--SELECT * 
--FROM [WizzardDeposits] AS [wd1]
--INNER JOIN [WizzardDeposits] AS [wd2]
--ON [wd1].[Id] + 1 = [wd2].[Id]

SELECT SUM([Host Wizard Deposit] - [Guest Wizard Deposit]) AS [SumDifference]
FROM (
SELECT 
	[FirstName] AS [Host Wizard],
	[DepositAmount] AS [Host Wizard Deposit],
	LEAD([FirstName]) OVER(ORDER BY [Id]) AS [Guest Wizard],
	LEAD([DepositAmount]) OVER(ORDER BY [Id]) AS [Guest Wizard Deposit]
FROM [WizzardDeposits]
) AS [HostGuestWizardQuery]
WHERE [Guest Wizard] IS NOT NULL


USE [SoftUni]
--Problem 13
SELECT [e].[DepartmentID],
		SUM([Salary])
FROM [Employees] AS [e]
GROUP BY [DepartmentID]
ORDER BY [DepartmentID]

--Problem 14
SELECT [e].[DepartmentID],
		MIN([Salary])
FROM [Employees] AS [e]
WHERE [DepartmentID] IN (2,5,7) AND [e].[HireDate] > 01/01/2000
GROUP BY [DepartmentID]

--Problem 15
SELECT *
INTO [EmployeesNew]
FROM [Employees]
WHERE [Salary] > 30000

DELETE 
	FROM [EmployeesNew]
 WHERE [ManagerID] = 42

UPDATE [EmployeesNew]
SET [Salary] += 5000
WHERE [DepartmentID] = 1

SELECT [DepartmentID],
		AVG([Salary])
FROM [EmployeesNew]
GROUP BY [DepartmentID]

--Problem 16
SELECT DepartmentID,
       MAX(Salary) AS MaxSalary
FROM Employees
GROUP BY DepartmentID
HAVING MAX(Salary) NOT BETWEEN 30000 AND 70000;

--Problem 17
SELECT COUNT(*) AS [Count]
FROM [Employees]
WHERE [ManagerID] IS NULL

--Problem 18
SELECT DISTINCT [DepartmentID],
				[Salary]
 FROM (
	SELECT [DepartmentID],
			[Salary],
			DENSE_RANK() OVER(PARTITION BY [DepartmentID] ORDER BY [Salary] DESC)
			AS [SalaryRank]
	FROM [Employees]
	) AS [SalaryRankigQuery]
WHERE [SalaryRank] = 3

--Problem 19
SELECT TOP (10) [FirstName],
				[LastName],
				[DepartmentID]
			FROM [Employees]
			  AS [e]
			WHERE [e].[Salary] > (
									SELECT AVG([Salary]) AS [AverageSalary]
									  FROM [Employees]
									    AS [esub]
									 WHERE [esub].[DepartmentID] = [e].[DepartmentID]
								  GROUP BY [DepartmentID]
								 )
		ORDER BY [e].[DepartmentID]