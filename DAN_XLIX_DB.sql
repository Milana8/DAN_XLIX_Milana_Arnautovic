CREATE DATABASE DAN_XLIX
 IF DB_ID('DAN_XLIX') IS NULL
CREATE DATABASE DAN_XLIX;
GO
USE DAN_XLIX;

if exists (SELECT name FROM sys.sysobjects WHERE name = 'tblUsers')
drop table tblUsers;

if exists (SELECT name FROM sys.sysobjects WHERE name = 'tblEmployees')
drop table tblEmployees;

if exists (SELECT name FROM sys.sysobjects WHERE name = 'tblManager')
drop table tblManagers;

if exists (SELECT name FROM sys.sysobjects WHERE name = 'tblAbsence')
drop table tblAbsence;


Create table tblUsers(
 UserID int identity(1,1) Primary key,
 NameSurname nvarchar (50) not null,
 Email varchar(50) UNIQUE,
 DateOfBirth date not null,
 Username varchar(50) UNIQUE NOT NULL,
 Pasword varchar(50)  NOT NULL,

);


Create table tblEmployees(
 EmployeeID int IDENTITY(1,1) Primary key not null, --Primary key
 HotelFloor int not null,
 Gender char (1) not null,
 Citizenship varchar (50) not null,
 Engagment varchar(50) NOT NULL,
 Salary INT not null,	
 UserID int,	
 
 
);

CREATE TABLE tblManagers(
	ManagerID INT PRIMARY KEY IDENTITY(1,1),
	HotelFloor int NOT NULL,
	Exprience int NOT NULL,
	Qualifications varchar(3) not null,
	UserID int,
);

CREATE TABLE tblAbsence(
	AbsenceID INT PRIMARY KEY IDENTITY(1,1),
	FirstDay date NOT NULL,
	LastDay date NOT NULL,
	Reason varchar(100) not null,
	StatusRequest varchar (50) not null,
	EmployeeID int,
);
 
 

ALTER TABLE tblEmployees
ADD FOREIGN KEY (UserID) REFERENCES tblUsers(UserID);


ALTER TABLE tblManagers
ADD FOREIGN KEY (UserID) REFERENCES tblUsers(UserID);

ALTER TABLE tblAbsence
ADD FOREIGN KEY (EmployeeID) REFERENCES tblEmployees(EmployeeID);





