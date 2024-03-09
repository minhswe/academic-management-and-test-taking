CREATE DATABASE ExaminationSystem
USE ExaminationSystem

CREATE TABLE Classes (
    ClassID VARCHAR(10) NOT NULL,
    ClassName NVARCHAR(255)
);

CREATE TABLE Courses (
	CourseID VARCHAR(10) NOT NULL,
	CourseName NVARCHAR(255),
	ClassID VARCHAR(10)
);

CREATE TABLE Topics (
	TopicID VARCHAR(10) NOT NULL,
	TopicName NVARCHAR(255),
	CourseID VARCHAR(10),
);

CREATE TABLE Questions (
	QuestionID VARCHAR(10) NOT NULL,
	QuestionContent NVARCHAR(500),
	TopicID VARCHAR(10)
);

CREATE TABLE QuestionChoices (
	ID INT IDENTITY(1,1) NOT NULL,
	QuestionID VARCHAR(10) NOT NULL,
	ChoiceLabel VARCHAR(1),
	ChoiceContent NVARCHAR(300)
);

CREATE TABLE QuestionCorrectAnswers (
	ID INT IDENTITY(1,1) NOT NULL,
	QuestionID VARCHAR(10) NOT NULL,
	CorrectChoice VARCHAR(1),
);

CREATE TABLE QuestionDisplayOrder (
	QuestionID VARCHAR(10) NOT NULL,
	DisplayOrder INT
);

CREATE TABLE Exams (
	ExamID VARCHAR(10) NOT NULL,
	ExamTitle NVARCHAR(255),
	ExamDate DATETIME,
	NumberOfQuestion int,
	MarkPerQuestion float,
	examTime tinyint
);

CREATE TABLE QuestionInExam (
	ID INT IDENTITY(1,1) NOT NULL,
	ExamID VARCHAR(10),
	QuestionID VARCHAR(10)
);

CREATE TABLE ExamEnrollment (
	ExamNumber INT IDENTITY(1,1),
	AttendDate Datetime,
	ExamID VARCHAR(10),
	StudentUserName VARCHAR(255),
	Mark float
);

CREATE TABLE Students (
	StudentUserName VARCHAR(255) NOT NULL,
	StudentPassword VARCHAR(255),
	StudentName NVARCHAR(255),
	StudentAddress NVARCHAR(255),
	ClassID VARCHAR(10)
);

CREATE TABLE StudentRespones (
	ResponeID INT IDENTITY(1,1) NOT NULL,
	ResponeChoice VARCHAR(10),
	StudentUserName VARCHAR(255),
	ExamID VARCHAR(10),
	QuestionID VARCHAR(10),
);

CREATE TABLE Enrollments (
	EnrollmentID INT IDENTITY(1,1) NOT NULL,
	CourseID VARCHAR(10),
	StudentUserName VARCHAR(255),
);

CREATE TABLE Administrators (
	AdminUserName VARCHAR(255) NOT NULL,
	AdminPassword VARCHAR(255),
	AdminName NVARCHAR(255),
);

ALTER TABLE Classes
ADD PRIMARY KEY (ClassID)

ALTER TABLE Courses
ADD PRIMARY KEY (CourseID)

ALTER TABLE Topics
ADD PRIMARY KEY (TopicID)

ALTER TABLE Questions
ADD PRIMARY KEY (QuestionID)

ALTER TABLE QuestionChoices
ADD PRIMARY KEY (ID)

ALTER TABLE QuestionCorrectAnswers
ADD PRIMARY KEY (ID)

ALTER TABLE QuestionDisplayOrder
ADD PRIMARY KEY (QuestionID)

ALTER TABLE Exams
ADD PRIMARY KEY (ExamID)

ALTER TABLE QuestionInExam
ADD PRIMARY KEY (ID)

ALTER TABLE ExamEnrollment
ADD PRIMARY KEY (ExamNumber)

ALTER TABLE Students
ADD PRIMARY KEY (StudentUserName)

ALTER TABLE StudentRespones
ADD PRIMARY KEY (ResponeID)

ALTER TABLE Enrollments
ADD PRIMARY KEY (EnrollmentID)

ALTER TABLE Administrators
ADD PRIMARY KEY (AdminUserName)

ALTER TABLE Courses
ADD FOREIGN KEY (ClassID) REFERENCES Classes(ClassID)

ALTER TABLE Topics
ADD FOREIGN KEY (CourseID) REFERENCES Courses(CourseID)

ALTER TABLE Questions
ADD FOREIGN KEY (TopicID) REFERENCES Topics(TopicID)

ALTER TABLE QuestionChoices
ADD FOREIGN KEY (QuestionID) REFERENCES Questions(QuestionID)

ALTER TABLE QuestionCorrectAnswers
ADD FOREIGN KEY (QuestionID) REFERENCES Questions(QuestionID)

ALTER TABLE QuestionDisplayOrder
ADD FOREIGN KEY (QuestionID) REFERENCES Questions(QuestionID)

ALTER TABLE QuestionInExam
ADD FOREIGN KEY (QuestionID) REFERENCES Questions(QuestionID)

ALTER TABLE QuestionInExam
ADD FOREIGN KEY (ExamID) REFERENCES Exams(ExamID)

ALTER TABLE ExamEnrollment
ADD FOREIGN KEY (StudentUserName) REFERENCES Students(StudentUserName)

ALTER TABLE ExamEnrollment
ADD FOREIGN KEY (ExamID) REFERENCES Exams(ExamID)

ALTER TABLE Students
ADD FOREIGN KEY (ClassID) REFERENCES Classes(ClassID)

ALTER TABLE StudentRespones
ADD FOREIGN KEY (StudentUserName) REFERENCES Students(StudentUserName)

ALTER TABLE StudentRespones
ADD FOREIGN KEY (ExamID) REFERENCES Exams(ExamID)

ALTER TABLE StudentRespones
ADD FOREIGN KEY (QuestionID) REFERENCES Questions(QuestionID)

ALTER TABLE Enrollments
ADD FOREIGN KEY (CourseID) REFERENCES Courses(CourseID)

ALTER TABLE Enrollments
ADD FOREIGN KEY (StudentUserName) REFERENCES Students(StudentUserName)

--INSERT Classes
INSERT INTO Classes (ClassID, ClassName) VALUES
('23CS001', N'Khoa học máy tính')
INSERT INTO Classes (ClassID, ClassName) VALUES
('23SWE001', N'Kỹ thuật phần mềm')

select * from Exams

select * from classes
select * from Courses

delete from Classes
delete from Courses
delete from Topics
delete from Questions
delete from Exams
delete from QuestionInExam
delete from QuestionChoices
delete from QuestionCorrectAnswers
delete from QuestionDisplayOrder
delete from ExamEnrollment
delete from StudentRespones
delete from Students
delete from Enrollments
