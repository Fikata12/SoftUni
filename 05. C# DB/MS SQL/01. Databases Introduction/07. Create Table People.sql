CREATE TABLE People
(
    Id INT PRIMARY KEY IDENTITY,
    [Name] NVARCHAR(200) NOT NULL,
    Picture VARBINARY(MAX),
    Height DECIMAL(3, 2),
    [Weight] DECIMAL(5, 2),
    Gender CHAR(1) NOT NULL,
    Birthdate DATE NOT NULL,
    Biography NVARCHAR(MAX)
);

INSERT INTO People
VALUES
    ('Ivan', NULL, 1.72 , 75.1 , 'm' , '09-10-2006', NULL),
    ('Peter', NULL, 1.75 , 70.5 , 'm' , '02-12-2006', NULL),
    ('John', NULL, 1.81 , 71.5 , 'm' , '01-29-2007', NULL),
    ('George', NULL, 1.85 , 83.2 , 'm' , '12-07-2006', NULL),
    ('Bob', NULL, 1.69 , 69 , 'm' , '12-12-2009', 'Biography')