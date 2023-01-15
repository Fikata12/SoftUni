CREATE TABLE Directors
(
    Id INT PRIMARY KEY IDENTITY,
    DirectorName VARCHAR(200) NOT NULL,
    Notes VARCHAR(MAX)
);

CREATE TABLE Genres
(
    Id INT PRIMARY KEY IDENTITY,
    GenreName VARCHAR(200) NOT NULL,
    Notes VARchar(MAX)
);

CREATE TABLE Categories
(
    Id INT PRIMARY KEY IDENTITY,
    CategoryName VARCHAR(200) NOT NULL,
    Notes VARCHAR(MAX)
);

CREATE TABLE Movies
(
    Id INT PRIMARY KEY IDENTITY,
    Title VARCHAR(200) NOT NULL,
    DirectorId INT NOT NULL,
    CopyrightYear DATE,
    [Length] INT,
    GenreId INT NOT NULL,
    CategoryId INT NOT NULL,
    Rating DECIMAL,
    Notes VARCHAR(MAX)
);

INSERT INTO Directors
VALUES
    ('Director1', 'Notes1'),
    ('Director2', NULL),
    ('Director3', 'Notes3'),
    ('Director4', NULL),
    ('Director5', 'Notes5');

INSERT INTO Genres
VALUES
    ('Genre1', 'Notes1'),
    ('Genre2', NULL),
    ('Genre3', 'Notes3'),
    ('Genre4', NULL),
    ('Genre5', 'Notes5');

INSERT INTO Categories
VALUES
    ('Category1', 'Notes1'),
    ('Category2', NULL),
    ('Category3', 'Notes3'),
    ('Category4', NULL),
    ('Category5', 'Notes5');

INSERT INTO Movies
VALUES
    ('Movie1', 1, GETDATE(), 110, 1, 1, 1, 'Notes1'),
    ('Movie2', 2, GETDATE(), 120, 2, 2, 2, NULL),
    ('Movie3', 3, GETDATE(), 130, 3, 3, 3, 'Notes3'),
    ('Movie4', 4, GETDATE(), 140, 4, 4, 4, NULL),
    ('Movie5', 5, GETDATE(), 150, 5, 5, 5, 'Notes5');