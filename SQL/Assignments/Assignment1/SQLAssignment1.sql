create database Assignment1
use Assignment1
  
create table Clients(
  Client_ID NUMBER(4) primary key,
  Cname VARCHAR2(40) Not Null,
  Address VARCHAR2(30),
  Email VARCHAR2(30) Unique,
  Phone NUMBER(10),
  Business VARCHAR2(20) Not Null
  )

     create table Departments(
  Deptno NUMBER(2) Primary Key,
  Dname VARCHAR2(15) Not Null,
  Loc VARCHAR2(20)
  )

  create table Employees(
  Empno NUMBER(4) Primary Key,
  Ename VARCHAR2(20) Not Null,
  Job VARCHAR2(15),
  Salary NUMBER(7) CHECK(Salary>0),
  Deptno NUMBER(2) references Departments(Deptno)
  )


  create table Projects(
Project_ID NUMBER(3) Primary Key,
Descr VARCHAR2(30) Not Null,
Start_Date DATE,
Planned_End_Date DATE,
Actual_End_date DATE CHECK(Actual_End_date > Planned_End_Date),
Budget NUMBER(10) CHECK(Budget > 0),
Client_ID NUMBER(4) references Clients(Client_ID)
)

create table EmpProjectTasks(
  Project_ID NUMBER(3) references Projects(Project_ID),
  Empno NUMBER(4) references Employees(Empno),
  Start_Date DATE,
  End_Date DATE,
  Task VARCHAR2(25) NOT NULL,
  Status VARCHAR2(15) NOT NULL,
  primary key(Project_ID,Empno)
  )

  insert into Clients VALUES(1001,"ACME Utilities","Noida","contact@acmeutil.com",9567880032,"Manufacturing"),
(1002,"Trackon Consultants","Mumbai","consult@trackon.com",8734210090,"Consultant"),
(1003,"MoneySaver Distributors","Kolkata","save@moneysaver.com",7799886655,"Reseller"),
(1004,"Lawful Corp","Chennai","justice@lawful.com",9210342219,"Professional")
  

  insert into Departments VALUES(10,"Design","Pune"),
(20,"Development","Pune"),
(30,"Testing","Mumbai"),
(40,"Document","Mumbai")
    

insert into Employees VALUES(7001,"Sandeep","Analyst",25000,10),
(7002,"Rajesh","Designer",30000,10),
(7003,"Madhav","Developer",40000,20),
(7004,"Manoj","Developer",40000,20),
(7005,"Abhay","Designer",35000,10),
(7006,"Uma","Tester",30000,30),
(7007,"Gita","Tech. Writer",30000,40),
(7008,"Priya","Tester",35000,30),
(7009,"Nutan","Developer",45000,20),
(7010,"Smita","Analyst",20000,10),
(7011,"Anand","Project Mgr",65000,10)


  
insert into Projects VALUES
(401,"Inventory","01-Apr-11","01-Oct-11","31-Oct-11",150000,1001)

insert into Projects(Project_ID,Descr,Start_Date,Planned_End_Date
,Budget,Client_ID) VALUES
(402,"Accounting","01-Aug-11","01-Jan-12",500000,1002),
(403,"Payroll","01-Oct-11","31-Dec-11",75000,1003),
(404,"Contact Mgmt","01-Nov-11","31-Dec-11",50000,1004)


  
insert into EmpProjectTasks VALUES
(401,7001,"01-Apr-11","20-Apr-11","System Analysis","Completed"),
(401,7002,"21-Apr-11","30-May-11","System Design","Completed"),
(401,7003,"01-Jun-11","15-Jul-11","Coding","Completed"),
(401,7004,"18-Jul-11","01-Sep-11","Coding","Completed"),
(401,7006,"03-Sep-11","15-Sep-11","Testing","Completed"),
(401,7009,"18-Sep-11","05-Oct-11","Code Change","Completed"),
(401,7008,"06-Oct-11","16-Oct-11","Testing","Completed"),
(401,7007,"06-Oct-11","22-Oct-11","Documentation","Completed"),
(401,7011,"22-Oct-11","31-Oct-11","Sign off","Complete"),
(402,7010,"01-Aug-11","20-Aug-11","System Analysis","Completed"),
(402,7002,"22-Aug-11","30-Sep-11","System Design","Completed"),
(402,7004,"01-Oct-11",null,"Coding","In Progress")


  select * from Clients 

  select * from Employees 

  select * from Departments 
    
  select * from Projects 

  select * from EmpProjectTasks 