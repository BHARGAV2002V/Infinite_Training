create database RailwayReservationSystem
use RailwayReservationSystem

create table users(
userid int identity primary key,
username varchar(30) not null,
email varchar(50) unique not null,
password varchar(30) not null,
phone varchar(15),
role varchar(20) default 'user'
)
create table trains(
trainid int primary key,
trainname varchar(50) not null,
source varchar(50) not null,
destination varchar(50) not null,
traveltime varchar(50) not null,
status varchar(10) default 'active'
)
select * from bookings
drop table trainclasses

create table trainclasses(
classid int identity primary key,
trainid int not null foreign key references trains(trainid),
classname varchar(40) not null,
price decimal not null,
totalberths int not null,
availableberths int not null,
waitlistlimit int not null
)

create table trainschedules(
scheduleid int identity primary key,
trainid int not null foreign key references trains(trainid),
stationname varchar(50) not null,
arrivaltime time not null,
departuretime time not null,
distancefromsource decimal not null
)
drop table bookings
drop table trainclasses
drop table trains
drop table trainschedules
drop table waitlist
drop table refunds

create table bookings(
bookingid int identity(3141,1) primary key,
userid int not null foreign key references users(userid),
trainid int not null foreign key references trains(trainid),
classid int not null foreign key references trainclasses(classid),
passengername varchar(50) not null,
passengerage int not null,
passengergender varchar(10) not null,
seatsbooked int not null,
traveldate date not null,
bookingstatus varchar(20) default 'Booked',
discountapplied decimal null,
totalfare decimal not null
)

create table waitlist(
waitlistid int identity primary key,
bookingid int not null foreign key references bookings(bookingid),
trainid int not null foreign key references trains(trainid),
classid int not null foreign key references trainclasses(classid),
passengername varchar(50) not null,
passengerage int not null,
passengergender varchar(10) not null,
traveldate date not null,
waitlistposition int not null
)

create table refunds(
refundid int identity primary key,
bookingid int not null foreign key references bookings(bookingid),
refundamount decimal not null,
refunddate datetime not null,
refundstatus varchar(20) default 'pending',
)

create table discounts(
discountid int identity primary key,
discounttype varchar(50) not null,
discountpercentage decimal not null,
eligibilitycriteria varchar(150) null
)

create procedure adduser
@username varchar(50),
@email varchar(50),
@password varchar(30),
@phone varchar(15),
@role varchar(20) = 'user'
as 
begin
insert into users(username,email,password,phone,role)
values(@username,@email,@password,@phone,@role)
end

create or alter procedure authenticateuser
@email varchar(50),
@password varchar(50)
as
begin
select userid,username,role from users where email=@email and password=@password
end

select * from trains

create or alter procedure addtrain
@trainid int,
@trainname varchar(50),
@source varchar(50),
@destination varchar(50),
@traveltime varchar(50)
as
begin
insert into trains(trainid, trainname,source,destination,traveltime,status)
values(@trainid, @trainname,@source,@destination,@traveltime,'Active')
end


create or alter procedure modifytrain
@trainid int,
@trainname varchar(50),
@source varchar(50),
@destination varchar(50),
@traveltime varchar(50),
@status varchar(20)
as
begin
update trains set trainname=@trainname,source=@source,destination=@destination,traveltime=@traveltime,status=@status
where trainid=@trainid
end


create or alter procedure deletetrain
@trainid int
as
begin
update trains set status='Inactive' where trainid=@trainid
end


create or alter procedure getalltrains
as
begin
select * from trains where status='Active'
end


create or alter procedure addtrainclass
@trainid int,
@classname varchar(50),
@price decimal,
@totalberths int,
@availableberths int,
@waitlistlimit int
as
begin
insert into trainclasses(trainid,classname,price,totalberths,availableberths,waitlistlimit)
values(@trainid,@classname,@price,@totalberths,@availableberths,@waitlistlimit)
end

exec addtrainclass 12345,1,"sleeper",5000,20,5

create or alter procedure updatetrainclass
@classid int,
@price decimal,
@totalberths int,
@waitlistlimit int
as
begin
update trainclasses set price=@price,totalberths=@totalberths,availableberths=@totalberths,waitlistlimit=@waitlistlimit 
where classid=@classid
end

create or alter procedure getavailableseats
@trainid int,
@classid int
as
begin
select availableberths from trainclasses where trainid=@trainid and classid=@classid
end


create or alter procedure bookticket
@userid int,
@trainid int,
@classid int,
@passengername varchar(50),
@passengerage int,
@passengergender varchar(10),
@seatsbooked int,
@traveldate date,
@discountapplied decimal=0

as
begin
declare @availableseats int
declare @totalfare decimal
declare @bookingid int;
declare @waitlistlimit int
declare @currentwaitlistcount int


select @availableseats=availableberths,@waitlistlimit=waitlistlimit from trainclasses where trainid=@trainid and classid=@classid
if(@availableseats>=@seatsbooked)
begin
	update trainclasses set availableberths=availableberths-@seatsbooked where trainid=@trainid and classid=@classid
	set @totalfare=@seatsbooked*(select price from trainclasses where trainid=@trainid and classid=@classid)
if(@passengerage>60)
begin
	set @discountapplied=50
end
	set @totalfare=@totalfare-(@totalfare*@discountapplied/100)

insert into bookings(userid,trainid,classid,passengername,passengerage,passengergender,seatsbooked,traveldate,totalfare,discountapplied,bookingstatus)
values(@userid,@trainid,@classid,@passengername,@passengerage,@passengergender,@seatsbooked,@traveldate,@totalfare,@discountapplied,'Booked')
end

else
begin
select @currentwaitlistcount=COUNT(*) from waitlist where trainid=@trainid and classid=@classid
if(@currentwaitlistcount + @seatsbooked<=@waitlistlimit)
begin
set @totalfare=@seatsbooked*(select price from trainclasses where trainid=@trainid and classid=@classid)

if(@passengerage>60)
begin
set @discountapplied=50
end
set @totalfare=@totalfare-(@totalfare*@discountapplied/100)
insert into bookings(userid,trainid,classid,passengername,passengerage,passengergender,seatsbooked,traveldate,totalfare,discountapplied,bookingstatus)
values(@userid,@trainid,@classid,@passengername,@passengerage,@passengergender,@seatsbooked,@traveldate,@totalfare,@discountapplied,'Waitlisted')
set @bookingid=SCOPE_IDENTITY();
insert into waitlist(trainid,bookingid,classid,passengername,passengerage,passengergender,traveldate,waitlistposition)
values(@trainid,@bookingid,@classid,@passengername,@passengerage,@passengergender,@traveldate,@currentwaitlistcount+1)
end
else
begin
	THROW 50001,'Waitlist Limit Exceeded',1;
end
end
end




create or alter procedure bookinghistory
@userid int
as
begin
select b.bookingid,b.trainid,b.classid,c.classname,b.passengername,b.passengerage,b.passengergender,b.seatsbooked,t.source,t.destination,b.traveldate,b.bookingstatus,b.discountapplied,b.totalfare from bookings b inner join trainclasses c
on b.classid=c.classid
inner join trains t on b.trainid=t.trainid
where b.userid=@userid
end

exec bookinghistory 1

create or alter procedure cancelbooking
@bookingid int
as
begin
update bookings set bookingstatus='cancelled' where bookingid=@bookingid

declare @seatsbooked int
declare @trainid int
declare @classid int
select @seatsbooked=seatsbooked,@trainid=trainid,@classid=classid from bookings where bookingid=@bookingid
update trainclasses set availableberths=availableberths+@seatsbooked where trainid=@trainid and classid=@classid
declare @waitlistid int
select top 1 @waitlistid=waitlistid from waitlist where trainid=@trainid and classid=@classid order by waitlistposition

if(@waitlistid is not null)
begin
insert into bookings(userid,trainid,classid,passengername,passengerage,passengergender,seatsbooked,traveldate,totalfare,bookingstatus)
select null,trainid,classid,passengername,passengerage,passengergender,1,traveldate,(select price from trainclasses where trainid=@trainid and classid=@classid),'Booked'
from waitlist
where waitlistid=@waitlistid

delete from waitlist where waitlistid=@waitlistid
end
end


create OR alter procedure CancelBooking
    @bookingid INT
as
begin
    -- Declare variables
declare @seatsbooked int, @trainid int, @classid int,@totalberths int,@waitlistid INT,@userid INT,@passengername varchar(100),@passengerage INT,@passengergender varchar(10),
            @traveldate DATE,
            @totalfare DECIMAL(10, 2);
 
    -- Check if the booking exists and is not already canceled
 if EXISTS (select 1 from bookings where bookingid = @bookingid AND bookingstatus != 'cancelled')
    begin
        -- Get booking details
        select
            @seatsbooked = seatsbooked,@trainid = trainid,@classid = classid from bookings where bookingid = @bookingid;
 
        -- Get total berths for this train and class
select @totalberths = totalberths from trainclasses where trainid = @trainid AND classid = @classid;
 
        -- Update booking status to 'cancelled'
        update bookings set bookingstatus = 'cancelled' where bookingid = @bookingid;
 
        -- Update available berths, ensuring it does not exceed total berths
        update trainclasses
        set availableberths = case
                                when availableberths + @seatsbooked > @totalberths
                                then @totalberths
                                else availableberths + @seatsbooked
                              end
        where trainid = @trainid AND classid = @classid;
 
        -- Get the top waitlist entry
        select top 1
            @waitlistid = waitlistid,
            @passengername = passengername,
            @passengerage = passengerage,
            @passengergender = passengergender,
            @traveldate = traveldate
        from waitlist
        where trainid = @trainid AND classid = @classid
        order by waitlistposition;
 
        -- If a waitlist entry exists, move it to bookings
        if (@waitlistid IS NOT NULL)
        begin
		select top 1 @userid=b.userid from waitlist w join bookings b on w.bookingid=b.bookingid where w.waitlistid=@waitlistid
            -- Calculate total fare
            SELECT @totalfare = price
            FROM trainclasses
            WHERE trainid = @trainid AND classid = @classid;
 
			update bookings set bookingstatus='Booked' where bookingid=(select top 1 bookingid from waitlist)
            -- Remove the waitlist entry
            delete FROM waitlist
            where waitlistid = @waitlistid;
        end
    end
    else
    begin
        print 'Booking does not exist or is already canceled.';
    end
end;

exec cancelbooking 3149
select * from bookings
select * from waitlist
select * from trainschedules
select * from trainclasses
select * from trains
select * from refunds

create or alter procedure processrefund
@bookingid int,
@refundstatus varchar(20) output,
@refundamount decimal output
as
begin 
declare @totalfare decimal
declare @traveldate date
declare @currentdate date=getdate()
declare @refundpercentage decimal
declare @bookingstatus varchar(20)


select @totalfare=totalfare,@traveldate=traveldate,@bookingstatus=bookingstatus from bookings where bookingid=@bookingid
if(@bookingstatus='Cancelled')
Begin
if(DATEDIFF(DAY,@currentdate,@traveldate)>=7)
set @refundpercentage=100
else if (DATEDIFF(DAY,@currentdate,@traveldate)between 1 and 6)
set @refundpercentage=50
else
set @refundpercentage=0
set @refundamount=@totalfare*(@refundpercentage/100)

insert into refunds(bookingid,refundamount,refunddate) values(@bookingid,@refundamount,@currentdate)
set @refundstatus='Refund Processed'
update refunds set refundstatus=@refundstatus where bookingid=@bookingid
end
else
begin
set @refundstatus='Refund Not eligible'
update refunds set refundstatus=@refundstatus where bookingid=@bookingid

set @refundamount=0
end
end

declare @refundstatus varchar(20)
declare @refundamount decimal
exec processrefund 3154,@refundstatus=@refundstatus output,@refundamount=@refundamount output
select @refundstatus as refundstatus,@refundamount as refundamount

create or alter procedure addtrainschedule
@trainid int,
@stationname varchar(50),
@arrivaltime time,
@departuretime time,
@distancefromsource decimal
as
begin
insert into trainschedules(trainid,stationname,arrivaltime,departuretime,distancefromsource)
values(@trainid,@stationname,@arrivaltime,@departuretime,@distancefromsource)
end
exec addtrainschedule 12345,'sklm','6:30:00','8:50:00',9
select * from trains

create or alter procedure gettrainschedule
@trainid int
as
begin
select ts.trainid,ts.stationname,ts.arrivaltime,ts.departuretime,ts.distancefromsource from trainschedules ts join trains t
on ts.trainid=t.trainid
where ts.trainid=@trainid and t.status='Active'  order by distancefromsource
end

exec gettrainschedule 71592

create or alter procedure searchtrains
@source varchar(50),
@destination varchar(50)
as
begin
select t.trainid,t.trainname,t.source,t.destination,t.traveltime from trains t
where t.source=@source and t.destination=@destination and t.status='Active'
end

exec searchtrains "vizag","hyd"

create or alter procedure getwaitlistedpassengers 
@trainid int,
@classid int
as begin
select waitlistid,passengername,passengerage,passengergender,waitlistposition,traveldate from waitlist where trainid=@trainid and classid=@classid order by waitlistposition
end

create or alter procedure getallrefunds
as
begin
select distinct r.bookingid,r.refundamount,r.refunddate,r.refundstatus,b.passengername,b.traveldate from refunds r inner join bookings b 
on r.bookingid=b.bookingid
end
exec getallrefunds
create or alter procedure gettrainclasses 
@trainid int
as
begin
select tc.classid,tc.classname,tc.price,tc.totalberths,tc.availableberths,tc.waitlistlimit from trainclasses tc join trains t
on tc.trainid=t.trainid where tc.trainid=@trainid and t.status='Active'
end

exec gettrainclasses 71592




create or alter procedure printbookingticket
@bookingid int
as
begin
select b.bookingid,b.trainid,b.classid,c.classname,b.passengername,b.passengerage,b.passengergender,b.seatsbooked,t.source,t.destination,b.traveldate,b.bookingstatus,b.discountapplied,b.totalfare from bookings b inner join trainclasses c
on b.classid=c.classid
inner join trains t on b.trainid=t.trainid 
where b.bookingid=@bookingid
end
exec printbookingticket 3158



