--1. Write a T-Sql based procedure to generate complete payslip of a given employee with respect to the following condition

--   a) HRA as 10% of Salary
--   b) DA as 20% of Salary
--   c) PF as 8% of Salary
--   d) IT as 5% of Salary
--   e) Deductions as sum of PF and IT
--   f) Gross Salary as sum of Salary, HRA, DA
--   g) Net Salary as Gross Salary - Deductions

--Print the payslip neatly with all details
use Assignment2
select * from emp
create or alter procedure payslip @empno int
as
begin
declare @sal int
declare @HRA int
declare @DA int
declare @PF int
declare @IT int
declare @deduct int
declare @gross int
declare @netsal int

	begin
	select @sal =sal from emp where empno=@empno
	set @HRA=@sal*10/100
	set @DA=@sal*20/100
	set @PF=@sal*8/100
	set @IT=@sal*5/100
	set @deduct=@PF+@IT
	set @gross=@sal+@HRA+@DA
	set @netsal=@gross-@deduct
	 
	select empno,ename,@HRA as HRA,@DA as DA,@PF as PF,@IT as IT,@deduct as DEDUCTION,@gross as [GROSS SALARY],@netsal as [NET SALARY] from emp where empno=@empno
	end

end

exec payslip @empno=7369


----
--2.  Create a trigger to restrict data manipulation on EMP table during General holidays. Display the error message like “Due to Independence day you cannot manipulate data” or "Due To Diwali", you cannot manipulate" etc
--Note: Create holiday table with (holiday_date,Holiday_name). Store at least 4 holiday details. try to match and stop manipulation 

create table holidays (holiday_date date ,holiday_name varchar(50))
insert into holidays values('2024-08-15','Independence day'),('2024-01-26','republic day'),('2024-11-11','Diwali'),('2024-12-05','Independence day')
select * from holidays

create trigger restrictdata
on emp
for insert,update,delete
as
begin
	declare @holiday varchar(50)
	select @holiday=holiday_name from holidays where @holiday_date=GETDATE()
	if @holiday is Not null
	Begin
		raiserror('cannot manipulate on this day,%s',16,1)
		rollback
	end
	end

	update emp set ename='Vasupalli bhargav' where empno=7369
