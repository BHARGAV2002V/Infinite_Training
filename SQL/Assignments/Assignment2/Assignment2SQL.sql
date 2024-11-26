create database Assignment2
use Assignment2

--EMP(empno, ename, job, mgr-id, hiredate, sal, comm., deptno) 

create table EMP (
empno int primary key,
ename varchar(20) not null,
job varchar(20),
mgr_id int,
hiredate date,
sal int,
comm int,
deptno int references DEPT(deptno)
)

--DEPT(deptno, dname, loc) 

create table DEPT(
deptno int primary key,
dname  varchar(20),
loc varchar(20)
)

insert into EMP values(7369,'SMITH','CLERK',7902,'17-DEC-80',800,null,20),
(7499,'ALLEN','SALESMAN',7698,'20-FEB-81',1600,300,30),
(7521,'WARD','SALESMAN',7698,'22-FEB-81',1250,500,30),
(7566,'JONES','MANAGER',7839,'02-APR-81',2975,null,20),
(7654,'MARTIN','SALESMAN',7698,'28-SEP-81',1250,1400,30),
(7698,'BLAKE','MANAGER',7839,'01-MAY-81',2850,null,30),
(7782,'CLARK','MANAGER',7839,'09-JUN-81',2450,null,10),
(7788,'SCOTT','ANALYST',7566,'19-APR-87',3000,null,20),
(7839,'KING','PRESIDENT',null,'17-NOV-81',5000,null,10),
(7844,'TURNER','SALESMAN',7698,'08-SEP-81',1500,0,30),
(7876,'ADAMS','CLERK',7788,'23-MAY-87',1100,null,20),
(7900,'JAMES','CLERK',7698,'03-DEC-81',950,null,30),
(7902,'FORD','ANALYST',7566,'03-DEC-81',3000,null,20),
(7934,'MILLER','CLERK',7782,'23-JAN-82',1300,null,10)


insert into DEPT values(10,'ACCOUNTING','NEW YORK'),
(20,'RESEARCH','DALLAS'),
(30,'SALES','CHICAGO'),
(40,'OPERATIONS','BOSTON')


--1. List all employees whose name begins with 'A'. 

select * from EMP where ename LIKE 'A%'


--2. Select all those employees who don't have a manager. 

select * from EMP where mgr_id is null

select * from EMP e where not exists (select 'x' from EMP where mgr_id=e.mgr_id)

--3. List employee name, number and salary for those employees who earn in the range 1200 to 1400. 

select empno,ename,sal from EMP where sal between 1200 and 1400

--4. Give all the employees in the RESEARCH department a 10% pay rise. Verify that this has been done by listing all their details before and after the rise. 

select e.ename,e.sal as [current salary] ,e.sal+(e.sal*10)/100 as [Revised salary] from EMP e
join DEPT d on e.deptno=d.deptno where e.deptno=20

--5. Find the number of CLERKS employed. Give it a descriptive heading. 

select count(*) [No of Clearks] from EMP where job = 'CLERK'

--6. Find the average salary for each job type and the number of people employed in each job. 

select job,avg(sal) as [Average Salary],count(*) as [Count] from EMP 
group by job 

--7. List the employees with the lowest and highest salary. 

select ename,sal from EMP where sal=(select MIN(sal) from EMP) 
union
select ename,sal from EMP where sal=(select MAX(sal) from EMP) 


select MAX(sal),MIN(sal) from EMP

--8. List full details of departments that don't have any employees. 

select * from DEPT d
where not exists(select 'a' from EMP where deptno=d.deptno)

--9. Get the names and salaries of all the analysts earning more than 1200 who are based in department 20. Sort the answer by ascending order of name. 

select ename,sal from EMP where job= 'ANALYST' and sal>1200 and deptno=20 order by ename


--10. For each department, list its name and number together with the total salary paid to employees in that department. 

select d.dname,d.deptno,sum(e.sal) as [sum] 
from DEPT d Inner join EMP e 
On d.deptno=e.deptno group by d.deptno,d.dname

--11. Find out salary of both MILLER and SMITH.

select ename,sal from EMP where (ename = 'MILLER' or ename = 'SMITH')

--12. Find out the names of the employees whose name begin with ‘A’ or ‘M’. 

select ename from EMP where ename LIKE '[AM]%'

--13. Compute yearly salary of SMITH.

select (sal*12) as 'Yearly salary of smith' from EMP where ename = 'SMITH'

--14. List the name and salary for all employees whose salary is not in the range of 1500 and 2850. 

select ename,sal from EMP where sal not between 1500 and 2850

--15. Find all managers who have more than 2 employees reporting to them

select mgr_id, count(empno) as ECOUNT from EMP group by mgr_id having(count(empno)>2)  