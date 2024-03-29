CREATE TABLE Majors
(
    MajorID INT PRIMARY KEY,
    [Name] VARCHAR(50)
);

CREATE TABLE Students
(
    StudentID INT PRIMARY KEY,
    StudentNumber INT,
    StudentName VARCHAR(100),
    MajorID INT FOREIGN KEY REFERENCES Majors(MajorID)
);

CREATE TABLE Subjects
(
    SubjectID INT PRIMARY KEY,
    SubjectName VARCHAR(100)
);

CREATE TABLE Agenda
(
    StudentID INT FOREIGN KEY REFERENCES Students(StudentID),
    SubjectID INT FOREIGN KEY REFERENCES Subjects(SubjectID),
    PRIMARY KEY(StudentID, SubjectID)
);

CREATE TABLE Payments
(
    PaymentID INT PRIMARY KEY,
    PaymentDate DATE,
    PaymentAmount DECIMAL(10, 2),
    StudentID INT FOREIGN KEY REFERENCES Students(StudentID)
);