CREATE TABLE Users
(
    Id BIGINT PRIMARY KEY IDENTITY,
    Username VARCHAR(30) NOT NULL,
    [Password] VARCHAR(26) NOT NULL,
    ProfilePicture VARBINARY(MAX),
    LastLoginTime DATETIME2,
    IsDeleted BIT
)

INSERT INTO Users
VALUES
    ('User1', '123', NULL, '12-01-2022', 1),
    ('User2', '123', NULL, '12-01-2022', 0),
    ('User3', '123', NULL, '12-01-2022', 1),
    ('User4', '123', NULL, '12-01-2022', 1),
    ('User5', '123', NULL, '12-01-2022', 0);