create schema clinic;

use schema clinic;

create table department(Name varchar(20),id int primary key);
 create table doctor(Id int primary key,Name varchar(20),Joiningdate DATE,patientstreated int,gender varchar(20),deptId int,foreign key(deptId) references department(Id));
 create table token(id int primary key,doctorid int ,alloteddate date,start time,end time,foreign key(doctorid) references doctor(id));
 create table timetable(doctorid int,day DATE,start time,end time,status int,tokenid int,foreign key(doctorid) references doctor(id));
 create table appointements(patientid int,tokenid int);

 