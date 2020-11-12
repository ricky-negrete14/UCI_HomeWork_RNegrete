-- SCRAP CODE TO CLEAR TABLES 
DROP TABLE IF EXISTS ""

-- Inserting code to create tables to import CSV Files. . . 
CREATE TABLE Departments (
	dept_no VARCHAR NOT NULL, 
	dept_name VARCHAR NOT NULL
);

-- Departments Table Visual Verification Point . . . 
SELECT * FROM Departments

CREATE TABLE Department_Employees (
	emp_no INTEGER, 
	dept_no VARCHAR NOT NULL
);

-- Department Employee Visual Verification Point . . . 
SELECT * FROM Department_Employees

CREATE TABLE Department_Managers (
	dept_no VARCHAR NOT NULL, 
	emp_no INTEGER
);

-- Manager Visual Verification Point . . . 
SELECT * FROM Department_Managers

CREATE TABLE Employees ( 
	emp_no INTEGER, 
	emp_title_id VARCHAR NOT NULL, 
	birth_date DATE, 
	first_name VARCHAR NOT NULL, 
	last_name VARCHAR NOT NULL, 
	sex VARCHAR NOT NULL, 
	hire_date DATE
);

-- Employees Info Visual Verification Point . . .
SELECT * FROM Employees

CREATE TABLE Salaries (
	emp_no INTEGER, 
	salary INTEGER 
);

-- Salary Visual Verification Point . . . 
SELECT * FROM Salaries

CREATE TABLE Titles (
	title_id VARCHAR NOT NULL,
	title VARCHAR NOT NULL
);

-- Title IDs Visual Verification Point . . . 
SELECT * FROM Titles
