use Assignment2
go
create procedure sp_managersalary2 @empno int
as
begin
declare @manager varchar(20)
select @manager=ename
from emp
where empno=(select mgr_id from emp where empno=@empno)

select @manager,sal from emp where empno=@empno
end


exec sp_managersalary2 7654

select * from dept
select * from emp


create proc sp_empsal @deptno int
as
begin
select avg(sal) as [average salary] from emp where deptno=@deptno
return (select count(*) from emp where deptno=@deptno)

end

declare @totemp int
exec @totemp = sp_empsal 20
print @totemp

----------------------------------
use Practice

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




begin tran
 -- insert into dept values(15,'Testing','Pune')  
 -- save tran t1
    select * from DEPT
   select * from EMP
  delete from emp where empno=7788
  select * from emp
  save tran t2
  update DEPT set dname='QualityA' where deptno=15
  rollback tran t2
  rollback tran t1
  rollback
  select * from dept
  select * from emp


  set implicit_transactions off

  update DEPT set dname='Testing' where deptno=15

  alter table emp 
  drop column comm

  commit

  begin tran
  update dept set dname='developer' where deptno=15
  save tran t1

  rollback tran t1

  create or alter function area_rect(@l int, @b int)
  returns int
  as
  begin 
  return (@l * @b)
  end

  select dbo.area_rect(2,4) as area
