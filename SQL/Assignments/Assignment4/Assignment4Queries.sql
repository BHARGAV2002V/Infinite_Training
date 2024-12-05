--1.Write a T-SQL Program to find the factorial of a given number.

create or alter procedure factorial @num int
AS 
Begin
	declare @c int =1;
	declare @fact int =1;
	
		if @num<0
			begin
			print 'Factoial cant be calculated for -ve num'
			end
		else if @num=0
			begin
			print 'factorial of 0 is 1'
			end
		else
			begin
			while @c<=@num
				begin
				set @fact=@fact * @c
				set @c=@c+1
				end
				print 'factorial of ' + cast(@num as varchar) + ' is ' + cast(@fact as varchar)
			end
end

exec factorial @num=5

--2.Create a stored procedure to generate multiplication table that accepts a number and generates up to a given number. 

create or alter procedure multiplication @num int ,@upto int
As
begin
	declare @l int =1
	declare @res int
	begin 
		while @l<=@upto
		begin
			set @res=@num*@l
			
			print cast(@num as varchar) +' X '+ cast(@l as varchar)+ ' = ' +cast(@res as varchar)
			set @l=@l+1
			end
	end
end

exec multiplication @num=5,@upto=10
			

--3. Create a function to calculate the status of the student. If student score >=50 then pass, else fail. Display the data neatly

--student table

--Sid       Sname       
--1         Jack
--2         Rithvik
--3         Jaspreeth
--4         Praveen
--5         Bisa
--6         Suraj

--Marks table

--Mid      Sid     Score
--1        1        23
--2        6        95
--3        4        98
--4        2        17
--5        3        53
--6        5        13

create table student(sid int primary key,sname varchar(20))
insert into student values(1,'jack'),(2,'rithvik'),(3,'jaspreeth'),(4,'praveen'),(5,'bisa'),(6,'suraj')
create table marks(mid int primary key,sid int references student(sid),score int)
insert into marks values(1,1,23),(2,6,95),(3,4,98),(4,2,17),(5,3,53),(6,5,13)


create function statusofstudent(@marks int)
returns varchar(10)
as
begin
	declare @status varchar(10)
	if @marks>=50
		set @status='pass'
	else
		set @status='fail'
	return @status
end

select s.sid,s.sname,m.score,dbo.statusofstudent(score) as status from student s join marks m on s.sid=m.sid


--  using table valued

create function studentmarks()
returns table
as
return(
select s.sid,s.sname,m.score,
case 
when m.score>=50 then 'pass'
else 'fail'
end as status 
from student s join marks m on s.sid=m.sid 
)
select * from dbo.studentmarks()








