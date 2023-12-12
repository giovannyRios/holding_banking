CREATE DATABASE exercise_one
GO

USE exercise_one
GO

--DDL
CREATE TABLE departments(
	[id] int Identity(1,1) primary key,
	[name] varchar(255) not null
)
GO

CREATE TABLE projects(
	[id] int Identity(1,1) primary key,
	[title] varchar(255) not null,
	[start_date] date not null,
	[end_date] date not null,
	[budget] int not null
)
GO

CREATE TABLE employees(
	[id] int Identity(1,1) primary key,
	[first_name] varchar(255) not null,
	[last_name] varchar(255) not null,
	[salary] int not null,
	[department_id] int not null
)
GO

CREATE TABLE employees_projects(
	[project_id] int not null,
	[employee_id] int not null	
)
GO

--RESTRICTIONS
ALTER TABLE employees_projects ADD CONSTRAINT fk_employee FOREIGN KEY (employee_id) REFERENCES employees([id])
ALTER TABLE employees_projects ADD CONSTRAINT fk_project FOREIGN KEY (project_id) REFERENCES projects([id])
ALTER TABLE employees ADD CONSTRAINT fk_department FOREIGN KEY (department_id) REFERENCES departments([id])


--DML

--departments
INSERT INTO [dbo].[departments] ([name]) VALUES ('Reporting')
INSERT INTO [dbo].[departments] ([name]) VALUES ('Engineering')
INSERT INTO [dbo].[departments] ([name]) VALUES ('Marketing')
INSERT INTO [dbo].[departments] ([name]) VALUES ('BizDev')
INSERT INTO [dbo].[departments] ([name]) VALUES ('Silly Walks')

--projects
INSERT INTO [dbo].[projects] ([title], [start_date], [end_date],[budget]) VALUES ('Build a cool site', CAST('2011-10-28' as date),CAST('2012-01-26' as date), 1000000)
INSERT INTO [dbo].[projects] ([title], [start_date], [end_date],[budget]) VALUES ('Update TPS Reports', CAST('2011-07-20' as date),CAST('2011-10-28' as date), 100000)
INSERT INTO [dbo].[projects] ([title], [start_date], [end_date],[budget]) VALUES ('Design 3 New Silly Walks', CAST('2009-05-11' as date),CAST('2009-08-19' as date), 100)

--Employees
INSERT INTO [dbo].[employees] ([first_name], [last_name], [salary], [department_id]) VALUES ('John','Smith',20000,1)
INSERT INTO [dbo].[employees] ([first_name], [last_name], [salary], [department_id]) VALUES ('Ava','Muffinson',10000,5)
INSERT INTO [dbo].[employees] ([first_name], [last_name], [salary], [department_id]) VALUES ('Cailin','Ninson',30000,2)
INSERT INTO [dbo].[employees] ([first_name], [last_name], [salary], [department_id]) VALUES ('Mike','Peterson',20000,2)
INSERT INTO [dbo].[employees] ([first_name], [last_name], [salary], [department_id]) VALUES ('Ian','Peterson',80000,2)
INSERT INTO [dbo].[employees] ([first_name], [last_name], [salary], [department_id]) VALUES ('John','Mills',20000,3)

--employees_projects
INSERT INTO [dbo].[employees_projects] ([project_id], [employee_id]) VALUES (2,1)
INSERT INTO [dbo].[employees_projects] ([project_id], [employee_id]) VALUES (3,2)
INSERT INTO [dbo].[employees_projects] ([project_id], [employee_id]) VALUES (1,3)
INSERT INTO [dbo].[employees_projects] ([project_id], [employee_id]) VALUES (1,4)
INSERT INTO [dbo].[employees_projects] ([project_id], [employee_id]) VALUES (1,5)