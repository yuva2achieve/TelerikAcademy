-- Task 1 --
CREATE DATABASE BankSystem

USE BankSystem

CREATE TABLE Persons (
	[Id] int IDENTITY UNIQUE,
	[FirstName] nvarchar(30),
	[LastName] nvarchar(30),
	[SSN] nvarchar(30),
	CONSTRAINT PK_Persons PRIMARY KEY(Id)
)

CREATE TABLE Accounts (
	[Id] int IDENTITY UNIQUE,
	[PersonId] int,
	[Balance] money,
	CONSTRAINT PK_Accounts PRIMARY KEY(Id),
	CONSTRAINT FK_Accounts_Persons FOREIGN KEY(PersonId) REFERENCES Persons(Id)
)

CREATE PROC usp_SelectPersonsFullName
AS
	SELECT
		FirstName + ' ' + LastName AS [FullName]
	FROM Persons
GO

EXEC usp_SelectPersonsFullName

-- Task 2 --
USE BankSystem
GO
CREATE PROC usp_SelectBiggerBalance(@balanceValue int)
AS
	SELECT
		p.FirstName + ' ' + p.LastName AS [Person name],
		a.Balance
	FROM Accounts a
	JOIN Persons p
	ON a.PersonId = p.Id
	WHEREs
		a.Balance > @balanceValue
GO

EXEC usp_SelectBiggerBalance 100

-- Task 3 --
USE BankSystem
GO

CREATE PROC usp_CalculateNewSum(
	@currentSum money,
	@interestRate money,
	@numberOfMonths int,
	@newSum money OUTPUT
)
AS
	SET @newSum = @currentSum + (@numberOfMonths / 12.0) * ((@interestRate * @currentSum) / 100)
GO

DECLARE @result int
EXEC usp_CalculateNewSum
	100.0,
	4.5,
	36,
	@result OUTPUT
SELECT @result

-- Task 4 --
USE BankSystem
GO

CREATE PROC usp_AddInterestToAccount(@accountId int, @interestRate money)
AS
	DECLARE @currentBalance money
	DECLARE @newBalance money
	DECLARE @numberOfMonths int = 1
	
	SET @currentBalance = 
		(
			SELECT
				Balance
			FROM Accounts
			WHERE
				Id = @accountId
		)

	EXEC usp_CalculateNewSum
		@currentBalance,
		@interestRate,
		@numberOfMonths,
		@newBalance OUTPUT

	UPDATE Accounts
	SET Balance = @newBalance
	WHERE
		Id = @accountId

GO

EXEC usp_AddInterestToAccount 1, 5

-- Task 5 --
USE BankSystem
GO

CREATE PROC usp_DepositMoney(@AccountId int, @Money money)
AS
	BEGIN TRAN
		UPDATE Accounts
		SET Balance = Balance + @Money
		WHERE
			Id = @AccountId
	COMMIT TRAN
GO

CREATE PROC usp_WithdrawMoney(@AccountId int, @Money money)
AS
	BEGIN TRAN
		UPDATE Accounts
		SET Balance = Balance - @Money
		WHERE
			Id = @AccountId
	COMMIT TRAN
GO

EXEC usp_DepositMoney 1, 1250
EXEC usp_WithdrawMoney 1, 1250

-- Task 6 --
USE BankSystem
GO

CREATE TABLE Logs (
	[LogId] int IDENTITY,
	[AccountId] int,
	[OldSum] money,
	[NewSum] money,
	CONSTRAINT PK_Logs PRIMARY KEY(LogId),
	CONSTRAINT FK_Logs_Accounts
		FOREIGN KEY(AccountId)
		REFERENCES Accounts(Id)
)

GO

CREATE TRIGGER tr_OnAccountUpdate ON Accounts FOR UPDATE
AS
	DECLARE @OldBalance money
	DECLARE @CurrentBalance money
	DECLARE @AccountId int

	SET @OldBalance = 
	(
		SELECT Balance
		FROM deleted
	)

	SET @CurrentBalance =
	(
		SELECT Balance
		FROM inserted
	)

	SET @AccountId =
	(
		SELECT Id
		FROM inserted
	)

	INSERT INTO Logs(AccountId, OldSum, NewSum)
	VALUES(@AccountId, @OldBalance, @CurrentBalance) 
GO

EXEC usp_DepositMoney 1, 100
EXEC usp_WithdrawMoney 1, 50