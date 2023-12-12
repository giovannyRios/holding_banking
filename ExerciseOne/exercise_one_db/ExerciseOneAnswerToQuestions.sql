--literal a
CREATE VIEW LITERAL_A AS 
SELECT 
	p.title AS project_name, 
	p.[start_date], 
	p.[end_date], 
	p.budget,
	d.[name] AS department_name
	FROM [dbo].[employees_projects] ep 
	INNER JOIN [dbo].[employees] e ON ep.employee_id = e.id
	INNER JOIN [dbo].[projects] p ON p.id = ep.project_id AND ep.employee_id = e.id
	INNER JOIN [dbo].[departments] d ON d.id = e.department_id
	GROUP BY 
	p.title,
	p.[start_date], 
	p.[end_date], 
	p.budget,
	d.[name]


--literal b
CREATE VIEW LITERAL_B AS 
SELECT
	count(distinct p.id) As ProjectsByDepartment,
	p.title as project_name,
	d.[name] AS department_name
FROM [dbo].[employees_projects] ep 
INNER JOIN [dbo].[employees] e ON ep.employee_id = e.id
INNER JOIN [dbo].[projects] p ON p.id = ep.project_id AND ep.employee_id = e.id
INNER JOIN [dbo].[departments] d ON d.id = e.department_id
GROUP BY 
	ep.project_id,
	d.[name],
	p.title


--literal c
CREATE VIEW LITERAL_C AS 
SELECT
	count(distinct p.id) As ProjectsByDepartment,
	p.title as project_name,
	d.[name] AS department_name
FROM [dbo].[employees_projects] ep 
INNER JOIN [dbo].[employees] e ON ep.employee_id = e.id
INNER JOIN [dbo].[projects] p ON p.id = ep.project_id AND ep.employee_id = e.id
INNER JOIN [dbo].[departments] d ON d.id = e.department_id
GROUP BY 
	ep.project_id,
	d.[name],
	p.title
having count(distinct p.id) > 1


--literal d
CREATE VIEW LITERAL_D AS 
SELECT
	(e.first_name + ' ' + e.last_name) as  nameEmployee,
	p.title as project_name
FROM [dbo].[employees_projects] ep 
INNER JOIN [dbo].[employees] e ON ep.employee_id = e.id
INNER JOIN [dbo].[projects] p ON p.id = ep.project_id AND ep.employee_id = e.id




