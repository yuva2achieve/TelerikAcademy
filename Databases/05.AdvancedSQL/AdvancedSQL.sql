-- Task 1 --
SELECT
	e.FirstName + ' ' + e.LastName AS EMPLOYEE,
	e.Salary
FROM Employees e
WHERE e.Salary =
	(SELECT MIN(Salary) FROM Employees

-- Task 2 --
SELECT
	e.FirstName + ' ' + e.LastName AS EMPLOYEE,
	e.Salary
FROM Employees e
WHERE e.Salary BETWEEN (SELECT MIN(Salary) FROM Employees) AND (SELECT MIN(Salary) FROM Employees) * 1.1

-- Task 3 --
SELECT
	e.FirstName + ' ' + e.LastName AS EMPLOYEE,
	e.Salary,
	e.DepartmentID
FROM Employees e
WHERE e.Salary =
	(SELECT MIN(em.Salary) 
	 FROM Employees em
	 WHERE em.DepartmentID = e.DepartmentID)

-- Task 4 --
SELECT
	AVG(Salary) AS [Average Salary]
FROM Employees

-- Task 5 --
SELECT
	AVG(e.Salary) AS [Average Salary]
FROM
	Employees e
WHERE
	e.DepartmentID = 3
	
-- Task 6 --
SELECT
	COUNT(e.EmployeeID) AS [Employee Count]
FROM
	Employees e
WHERE
	e.DepartmentID = 3
	
-- Task 7 --
SELECT
	COUNT(e.EmployeeID) AS [Employee Count]
FROM
	Employees e
WHERE
	e.ManagerID IS NOT NULL
	
-- Task 8 --
SELECT
	COUNT(e.EmployeeID) AS [Employee Count]
FROM
	Employees e
WHERE
	e.ManagerID IS NULL

-- Task 9 --
SELECT
	AVG(Salary) AS [Average Salary],
	DepartmentID
FROM Employees
GROUP BY DepartmentID

-- Task 10 --
SELECT
	COUNT(e.EmployeeID) AS [Employee Count],
	e.DepartmentID,
	a.TownID
FROM Employees e, Addresses a
GROUP BY e.DepartmentID, a.TownID

-- Task 11 --
SELECT
	e.FirstName,
	e.LastName
FROM Employees e
WHERE 5 =
	(
		SELECT
			COUNT(*)
		FROM Employees m
		WHERE
			m.ManagerID = e.EmployeeID
	)

-- Task 12 --
SELECT
	(e.FirstName + ' ' + e.LastName) AS [Employee],
	ISNULL(m.FirstName + ' ' + m.LastName,'No manager') AS [Manager]
FROM Employees e
LEFT JOIN
	Employees m
ON
	e.ManagerID = m.EmployeeID
	
-- Task 13 --
SELECT
	(e.FirstName + ' ' + e.LastName) AS [Employee]
FROM Employees e
WHERE
	LEN(e.LastName) = 5
	
-- Task 14 --
SELECT CONVERT(VARCHAR(24), GETDATE(), 113) AS [Current Date]

-- Task 15 --
CREATE TABLE Users (
	[UserID] int IDENTITY NOT NULL,
	[Username] nvarchar(30) UNIQUE NOT NULL,
	[Password] nvarchar(30) CHECK (LEN(Password) > 4),
	[FullName] nvarchar(50) NOT NULL, 
	[LastLogin] smalldatetime,
	CONSTRAINT PK_Users PRIMARY KEY (UserID)
)

-- Task 16 --
CREATE VIEW UsersFromToday
AS
SELECT *
FROM Users
WHERE
	DAY(LastLogin) = DAY(GETDATE())

-- Task 17 --
CREATE TABLE Groups (
	[GroupID] int IDENTITY,
	[Name] nvarchar(50) UNIQUE,
	CONSTRAINT PK_GROUPS PRIMARY KEY(GroupID)
)

-- Task 18 --
ALTER TABLE Users ADD GroupID int,
CONSTRAINT FK_Users_Groups 
FOREIGN KEY(GroupID)
REFERENCES Groups(GroupID)

-- Task 19 --
USE TelerikAcademy

INSERT INTO Users(Username, Password, FullName, LastLogin, GroupID)
VALUES
 ('test user', '5252222', 'Full name', GETDATE(), 2),
 ('another user', '199922', 'Name Full', GETDATE(), 3)

INSERT INTO Groups(Name)
VALUES
 ('Group4'),
 ('Group5')
 
-- Task 20 --
USE TelerikAcademy

UPDATE Users
SET Username = 'user234'
WHERE Username = 'user123'

UPDATE Groups
SET Name = 'Group55'
WHERE Name = 'Group5'

-- Task 21 --
USE TelerikAcademy

DELETE
FROM Users
WHERE
	Username = 'user234'

DELETE
FROM GROUPS
WHERE
	Name = 'Group55'

-- Task 22 --
USE TelerikAcademy

INSERT INTO Users(Username, Password, FullName, LastLogin, GroupID)
SELECT 
	LOWER(LEFT(FirstName, 1) + LastName + CONVERT(nvarchar(20), EmployeeId)),
	LOWER(LEFT(FirstName, 1) + LastName) + CONVERT(nvarchar(20), EmployeeId),
	FirstName + ' ' + LastName,
	NULL,
	1
FROM Employees

-- Task 23 --
UPDATE Users
SET Password = NULL
WHERE
	LastLogin <= CAST('10.03.2010 00:00:00' AS smalldatetime)
	
-- Task 24 --
DELETE
FROM Users
WHERE
	Password IS NULL
	
-- Task 25 --
SELECT
	AVG(Salary) AS [AverageSalary],
	JobTitle,
	DepartmentID
FROM Employees
GROUP BY JobTitle, DepartmentID

-- Task 26 --
SELECT d2.Name, e.JobTitle, e.FirstName + ' ' + e.LastName as Name, e.Salary 
FROM Employees e
JOIN Departments d2 ON d2.DepartmentID = e.DepartmentID
WHERE e.Salary IN (SELECT MIN(em.Salary) 
				   FROM Employees em
				   JOIN Departments d on d.DepartmentID = em.DepartmentID
				   WHERE d2.DepartmentID = d.DepartmentID AND e.JobTitle = em.JobTitle
				   GROUP BY d.Name, em.JobTitle)
				   
-- Task 27 --
SELECT
	TOP 1 t.Name,
	COUNT(*)
FROM Employees e
JOIN Addresses a
ON 
	e.AddressID = a.AddressID
JOIN Towns t
ON
	a.TownID = t.TownID
GROUP BY t.Name
ORDER BY COUNT(*) DESC
   
-- Task 28 --
SELECT t.Name, COUNT(e.ManagerID)
FROM Employees e
JOIN Addresses a
ON
	e.AddressID = a.AddressID
JOIN Towns t
ON a.TownID = t.TownID
WHERE
	e.EmployeeID IN (SELECT DISTINCT ManagerID FROM Employees)
GROUP BY t.Name

-- Task 30 --
BEGIN TRAN
	DELETE
	FROM Employees
	SELECT
		e.DepartmentID,
		d.Name
	FROM Employees e
	JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
	WHERE d.Name = 'Sales'
ROLLBACK TRAN