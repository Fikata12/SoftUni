CREATE TABLE Categories
(
    Id INT PRIMARY KEY IDENTITY,
    CategoryName VARCHAR(200),
    DailyRate DECIMAL,
    WeeklyRate DECIMAL,
    MonthlyRate DECIMAL,
    WeekendRate DECIMAL
);

CREATE TABLE Cars
(
    Id INT PRIMARY KEY IDENTITY,
    PlateNumber INT,
    Manufacturer VARCHAR(50),
    Model VARCHAR(50),
    CarYear DATE,
    CategoryId INT,
    Doors TINYINT,
    Picture VARBINARY,
    Condition VARCHAR(50),
    Available BIT
);

CREATE TABLE Employees
(
    Id INT PRIMARY KEY IDENTITY,
    FirstName VARCHAR(100),
    LastName VARCHAR(100),
    Title VARCHAR(100),
    Notes VARCHAR(MAX)
);

CREATE TABLE Customers
(
    Id INT PRIMARY KEY IDENTITY,
    DriverLicenceNumber INT,
    FullName VARCHAR(200),
    [Address] VARCHAR(MAX),
    City VARCHAR(100),
    ZIPCode TINYINT,
    Notes VARCHAR(MAX)
);

CREATE TABLE RentalOrders
(
    Id INT PRIMARY KEY IDENTITY,
    EmployeeId INT,
    CustomerId INT,
    CarId INT,
    TankLevel INT,
    KilometrageStart INT,
    KilometrageEnd INT,
    TotalKilometrage INT,
    StartDate DATE,
    EndDate DATE,
    TotalDays INT,
    RateApplied DECIMAL,
    TaxRate DECIMAL,
    OrderStatus BIT,
    Notes VARCHAR(MAX)
);

INSERT INTO Categories
VALUES
    ('a', 1.1, 1.1, 1.1, 1.1),
    ('a', 1.2, 1.2, 1.2, 1.2),
    ('a', 1.3, 1.3, 1.3, 1.3);

INSERT INTO Cars
VALUES
    (1, 'a', 'a', GETDATE(), 2, 1, NULL, 'a', 1),
    (2, 'a', 'a', GETDATE(), 1, 5, NULL, 'a', 2),
    (3, 'a', 'a', GETDATE(), 3, 5, NULL, 'a', 3);

INSERT INTO Employees
VALUES
    ('a', 'a', 'a', 'a'),
    ('a', 'a', 'a', 'a'),
    ('a', 'a', 'a', 'a');

INSERT INTO Customers
VALUES
    (1, 'a', 'a', 'a', 1, 'a'),
    (2, 'a', 'a', 'a', 2, 'a'),
    (3, 'a', 'a', 'a', 3, 'a');

INSERT INTO RentalOrders
VALUES
    (1, 1, 1, 1, 1, 1, 1, GETDATE(), GETDATE(), 1, 1, 1.1, 1, 'a'),
    (2, 2, 2, 2, 2, 2, 2, GETDATE(), GETDATE(), 2, 2, 1.2, 1, 'a'),
    (3, 3, 3, 3, 3, 3, 3, GETDATE(), GETDATE(), 2, 2, 1.3, 1, 'a');