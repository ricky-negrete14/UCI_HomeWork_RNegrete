--------------------------------------------- DATA ANALYSIS ----------------------------------------------

-- 1. List the following details of each employee: employee number, last name, first name, sex, and salary.

SELECT Employees.emp_no,Employees.last_name, Employees.first_name, Employees.sex, Salaries.salary
FROM Employees
JOIN Salaries
ON Employees.emp_no = Salaries.emp_no

-- 2. List first name, last name, and hire date for employees who were hired in 1986.S first_name,last_name,hire_date

SELECT first_name,last_name,hire_date
FROM Employees
WHERE hire_date >'1986-01-01'
AND hire_date < '1986-12-31';

-- 3. List the manager of each department with the following information: department number, department name, the manager's employee number, last name, first name.

SELECT Departments.dept_no, Departments.dept_name, Department_Managers.emp_no, Employees.last_name, Employees.first_name
FROM Departments
JOIN Department_Managers ON d.dept_no = dm.dept_no
JOIN Employees ON Department_Managers.emp_no = Employees.emp_no;

-- 4. List the department of each employee with the following information: employee number, last name, first name, and department name.

SELECT Employees.emp_no, Employees.last_name, Employees.first_name, Departments.dept_name
FROM Employees
JOIN Department_Employees ON Employees.emp_no = Department_Employees.emp_no
JOIN Departments ON Department_Employees.dept_no = Departments.dept_no;

-- 5. List first name, last name, and sex for employees whose first name is "Hercules" and last names begin with "B."

SELECT * FROM Employees
WHERE first_name = 'Hercules'
AND last_name LIKE 'B%';

-- 6. List all employees in the Sales department, including their employee number, last name, first name, and department name.

SELECT Employees.emp_no, Employees.last_name, Employees.first_name, Departments.dept_name
FROM Employees
JOIN Department_Employees ON Employees.emp_no = Department_Employees.emp_no
JOIN Departments ON Department_Employees.dept_no = Departments.dept_no
WHERE Departments.dept_name = 'Sales';

-- 7. List all employees in the Sales and Development departments, including their employee number, last name, first name, and department name.

SELECT Employees.emp_no, Employees.last_name, Employees.first_name, Departments.dept_name
FROM Employees 
JOIN Department_Employees ON Employees.emp_no = Department_Employees.emp_no
JOIN Departments ON Department_Employees.dept_no = Departments.dept_no
WHERE Departments.dept_name = 'Sales' OR Departments.dept_name = 'Development';

-- 8. In descending order, list the frequency count of employee last names, i.e., how many employees share each last name.

SELECT last_name, 
COUNT(last_name) as "Frequency"
FROM Employees
GROUP BY last_name
ORDER BY "Frequency" DESC;