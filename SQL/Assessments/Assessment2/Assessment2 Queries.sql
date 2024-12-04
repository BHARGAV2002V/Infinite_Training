use assessment
use Assignment2
--1.Write a query to display your birthday( day of week)

select DATENAME(weekday,'2002-08-18') as [day of week]



--2.Write a query to display your age in days

select DATEDIFF(Day,'2002-08-18',GETDATE()) as [Age in days]


--3.Write a query to display all employees information those who joined before 5 years in the current month
 
--  (Hint : If required update some HireDates in your EMP table of the assignment)

select * from EMP where DATEDIFF(Year,hiredate,getdate())>5 

update emp set hiredate='2022-12-12' where empno=7521
update emp set hiredate='2023-12-12' where empno=7654
select * from emp

--4.	Create table Employee with empno, ename, sal, doj columns or use and perform the following operations in a single transaction
	--a. First insert 3 rows 
	--b. Update the second row sal with 15% increment  
      --  c. Delete first row.
--After completing above all actions, recall the deleted row without losing increment of second row.

create table Employee(empno Int primary key,ename varchar(20),sal int,doj date)

begin transaction
--a. First insert 3 rows 
Insert into Employee values(1,'bhargav',10000,'2024-10-16'),
(2,'Mahesh babu',50000,'2019-08-18'),
(3,'Virat Kohli',90000,'2013-09-05')

--b. Update the second row sal with 15% increment  
update Employee set sal=sal+(sal*15/100) where empno=2

--  c. Delete first row.	
Delete from Employee where empno=1

--After completing above all actions, recall the deleted row without losing increment of second row.
Rollback transaction

select * from Employee
drop table Employee


--5.      Create a user defined function calculate Bonus for all employees of a  given dept using 	following conditions
	--a.     For Deptno 10 employees 15% of sal as bonus.
	--b.     For Deptno 20 employees  20% of sal as bonus
	--c      For Others employees 5%of sal as bonus

	select * from dept
	select * from emp

	create or alter function CalculateBonus(@deptno int,@sal int)
	Returns int
	as
	begin
	declare @bonus int
	if @deptno=10
	 Set @bonus=@sal*15/100
	else if @deptno=20
	 set @bonus=@sal*20/100
	else
	 set @bonus=@sal*5/100

	 Return @bonus
	 End

	 select empno,ename,sal,dbo.CalculateBonus(deptno,sal)as bonus from emp


--6. Create a procedure to update the salary of employee by 500 whose dept name is Sales and current salary is below 1500 (use emp table)

create or alter procedure salaryUpdate
as
begin
update e 
set e.sal=e.sal+500
from emp e join dept d on e.deptno=d.deptno
where d.dname='SALES' And e.sal<1500
end

exec salaryUpdate
