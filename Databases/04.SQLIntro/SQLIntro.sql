-- Task 4 --
SELECT * 
FROM Departments

-- Task 5 --
SELECT 
	d.Name FROM 
Departments d

-- Task 6 --
SELECT 
	e.Salary
FROM Employees e

-- Task 7 --
SELECT
	(e.FirstName + ' ' + e.LastName) AS [Full name] 
FROM Employees e

-- Task 8 --
SELECT
	(e.FirstName + '.' + e.LastName + '@telerik.com') AS [Full Email Addresses]
FROM Employees e

-- Task 9 --
SELECT 
	Distinct e.Salary 
FROM Employees e

-- Task 10 --
SELECT 
	*
FROM Employees e
WHERE
	e.JobTitle = 'Sales Representative'
	
-- Task 11 --
SELECT 
	e.FirstName
FROM Employees e
WHERE
	e.FirstName LIKE 'SA%'
	
-- Task 12 --
SELECT 
	e.LastName
FROM Employees e
WHERE
	e.LastName LIKE '%ei'
	
-- Task 13 --
SELECT 
	e.Salary
FROM Employees e
WHERE
	e.Salary BETWEEN 20000 AND 30000
	
-- Task 14 --
SELECT 
	e.FirstName + ' ' + e.LastName AS [Full Name]
FROM Employees e
WHERE
	e.Salary IN(25000, 14000, 12500, 23600)
	
-- Task 15 --
SELECT 
	*
FROM Employees e
WHERE
	e.ManagerID is NULL
	
-- Task 16 --
SELECT 
	*
FROM Employees e
WHERE
	e.Salary > 50000
ORDER BY e.Salary DESC

-- Task 17 --
SELECT 
	TOP 5 *
FROM Employees e
ORDER BY e.Salary DESC

-- Task 18 --
SELECT 
	(e.FirstName + ' ' + e.LastName) as [Employee],
	a.AddressText
FROM Employees e INNER JOIN Addresses a
ON e.AddressID = a.AddressID

-- Task 19 --
SELECT 
	(e.FirstName + ' ' + e.LastName) as [Employee],
	a.AddressText
FROM Employees e, Addresses a
WHERE e.AddressID = a.AddressID

-- Task 20 --
SELECT 
	(e.FirstName + ' ' + e.LastName) as [Employee],
	(m.FirstName + ' ' + m.LastName) as [Manager]
FROM Employees e JOIN Employees m
ON e.ManagerID = m.EmployeeID

-- Task 21 --
SELECT 
	(e.FirstName + ' ' + e.LastName) as [Employee],
	ae.AddressText as [Employee Address],
	(m.FirstName + ' ' + m.LastName) as [Manager],
	am.AddressText as [Manager Address]
FROM Employees e 
	JOIN Employees m
		ON e.ManagerID = m.EmployeeID
	JOIN Addresses ae
		ON e.AddressID = ae.AddressID
	Join Addresses am
		ON m.AddressID = am.AddressID
		
-- Task 22 --
SELECT 
	d.Name
FROM Departments d
UNION
SELECT
	t.Name
FROM Towns t

-- Task 23 --
-- RIGHT OUTER JOIN --
SELECT 
	(e.FirstName + ' ' + e.LastName) as [Employee],
	(m.FirstName + ' ' + m.LastName) as [Manager]
FROM Employees e RIGHT OUTER JOIN Employees m
ON e.ManagerID = m.EmployeeID

-- LEFT OUTER JOIN --
SELECT 
	(e.FirstName + ' ' + e.LastName) as [Employee],
	(m.FirstName + ' ' + m.LastName) as [Manager]
FROM Employees e LEFT OUTER JOIN Employees m
ON e.ManagerID = m.EmployeeID

-- Task 24 --
SELECT 
	e.FirstName + ' ' + e.LastName AS Employee,
	e.HireDate,
	d.Name AS Department
FROM
	Employees e
JOIN
	Departments d
ON 
	e.DepartmentID = d.DepartmentID
WHERE
	d.Name IN ('Finance', 'Sales') AND e.HireDate BETWEEN '1/1/1995' AND '1/1/2005'