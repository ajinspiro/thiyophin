-- TASK 1
create Database Employees_DB;
use Employees_DB;
create table Employees (Id int identity(1,1) primary key, Name varchar(100), Company varchar(100), JoinedDate date, IsIndian bit, Salary decimal(10,2));
drop table Employees;

 -- Task 2
insert into Employees values ('Arun Kumar', 'TechNova', '20200315', 1, 75000.50);
insert into Employees values ('Meera Nair', 'SoftEdge', '20210710', 1, 68000.00);
insert into Employees values ('John Smith', 'GlobalWorks', '20191122', 0, 95000.75);
insert into Employees values ('Priya Das', 'Innovent', '20220505', 1, 72000.00);
insert into Employees values ('Alex Brown', 'ByteSpace', '20150214', 0, 81000.25);
insert into Employees values ('Ravi Menon', 'TechNova', '20210912', 1, 83000.00);
insert into Employees values ('Sneha Pillai', 'SoftEdge', '20220125', 1, 69000.75);
insert into Employees values ('Emily Davis', 'GlobalWorks', '20040618', 0, 97000.00);

-- Task 3
select * from Employees;
select Name, Company from Employees;
select Name, Company, Salary from Employees where Salary > 90000.00;
select Name from Employees where JoinedDate <= '20200101';

-- Task 4
create table Companies (Name varchar(100));

-- Task 5
insert into Companies values('TechNova'), ('SoftEdge'), ('GlobalWorks'), ('Innovent'),('ByteSpace');
select * from Companies;
drop table Companies;

-- Task 6
ALTER TABLE Companies ADD Id int;

-- Task 7
update Companies set Id=5 where Name='ByteSpace';
ALTER TABLE Companies alter column Id int NOT NULL;
ALTER TABLE Companies ADD PRIMARY KEY (ID);

-- Task 8
-- This task cannot be done, Since we cannot add identity constraint to an existing column in mssql