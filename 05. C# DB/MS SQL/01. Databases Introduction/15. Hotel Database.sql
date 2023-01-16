CREATE TABLE Employees
(
    Id INT PRIMARY KEY IDENTITY,
    FirstName VARCHAR(200),
    LastName VARCHAR(200),
    Title VARCHAR(200),
    Notes VARCHAR(MAX)
);

CREATE TABLE Customers
(
    AccountNumber INT,
    FirstName VARCHAR(200),
    LastName VARCHAR(200),
    PhoneNumber INT,
    EmergencyName VARCHAR(200),
    EmergencyNumber INT,
    Notes VARCHAR(MAX)
);

CREATE TABLE RoomStatus
(
    RoomStatus BIT,
    Notes VARCHAR(MAX)
);

CREATE TABLE RoomTypes
(
    RoomType VARCHAR(200),
    Notes VARCHAR(MAX)
);

CREATE TABLE BedTypes
(
    BedType VARCHAR(200),
    Notes VARCHAR(MAX)
);

CREATE TABLE Rooms
(
    RoomNumber INT,
    RoomType VARCHAR(200),
    BedType VARCHAR(200),
    Rate DECIMAL,
    RoomStatus BIT,
    Notes VARCHAR(MAX)
);

CREATE TABLE Payments
(
    Id INT PRIMARY KEY IDENTITY,
    EmployeeId INT,
    PaymentDate DATE,
    AccountNumber INT,
    FirstDateOccupied DATE,
    LastDateOccupied DATE,
    TotalDays INT,
    AmountCharged INT,
    TaxRate DECIMAL,
    TaxAmount DECIMAL,
    PaymentTotal DECIMAL,
    Notes VARCHAR(200)
);

CREATE TABLE Occupancies
(
    Id INT PRIMARY KEY IDENTITY,
    EmployeeId INT,
    DateOccupied DATE,
    AccountNumber INT,
    RoomNumber INT,
    RateApplied DECIMAL,
    PhoneCharge INT,
    Notes VARCHAR(MAX)
);

INSERT INTO Employees
VALUES
    ('a', 'a', 'a', 'a'),
    ('a', 'a', 'a', 'a'),
    ('a', 'a', 'a', 'a');

INSERT INTO Customers
VALUES
    (1, 'a', 'a', 1, 'a', 1, 'a'),
    (2, 'a', 'a', 2, 'a', 2, 'a'),
    (3, 'a', 'a', 3, 'a', 3, 'a');

INSERT INTO RoomStatus
VALUES
    (1, 'a'),
    (1, 'a'),
    (1, 'a');

INSERT INTO RoomTypes
VALUES
    ('a', 'a'),
    ('a', 'a'),
    ('a', 'a');

INSERT INTO BedTypes
VALUES
    ('a', 'a'),
    ('a', 'a'),
    ('a', 'a');

INSERT INTO Rooms
VALUES
    (1, 'a', 'a', 1.1, 1, 'a'),
    (2, 'a', 'a', 1.2, 1, 'a'),
    (3, 'a', 'a', 1.3, 1, 'a');

INSERT INTO Payments
VALUES
    (1, GETDATE(), 1, GETDATE(), GETDATE(), 10, 10, 1.1, 1.1, 1.1, 'a'),
    (2, GETDATE(), 2, GETDATE(), GETDATE(), 20, 20, 1.2, 1.2, 1.2, 'a'),
    (3, GETDATE(), 3, GETDATE(), GETDATE(), 30, 30, 1.3, 1.3, 1.3, 'a');

INSERT INTO Occupancies
VALUES
    (1, GETDATE(), 1, 1, 1.1, 1, 'a'),
    (2, GETDATE(), 2, 2, 1.2, 2, 'a'),
    (3, GETDATE(), 1, 3, 1.3, 3, 'a');