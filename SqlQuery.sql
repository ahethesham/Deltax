create schema clinic;

use schema clinic;

create table department(Name varchar(20),id int primary key);
 create table doctor(Id int primary key auto_increment,Name varchar(20),Joiningdate DATE,patientstreated int,gender varchar(20),deptId int,foreign key(deptId) references department(Id));
 create table slots(Id int primary key,slotdate DATE,starttime time,endtime time);
 create table patient(Id int primary key,Name varchar(20),gender varchar(20),age int);
 create table workingslots(doctorid int,slotid int,status int,foreign key(doctorid) references doctor(id),foreign key(slotid) references slots(id));
create table appointments(id int primary key auto_increment,doctorid int,patientid int,slotid int,foreign key(doctorid) references doctor(id),foreign key(patientid) references patient(id),foreign key(slotid) references slots(id)); 

/*to get doctor with more than 10 years of experience working in a dept and available on a date*/
SELECT d.Id, d.Name, d.Joiningdate, d.patientstreated, d.DeptId FROM 
(doctor d JOIN Workingslots ws ON d.id = ws.Doctorid) JOIN 
Slots s2 ON ws.slotid = s2.id WHERE YEAR(@date) - YEAR(d.Joiningdate) >= 10  
 AND d.DeptId = @DeptId  AND s2.slotdate = @date;


 /*to get doctor who has treated more than 20 patients in a dept available on a particular date*/
SELECT d.Id, d.Name, d.Joiningdate, d.patientstreated, d.DeptId  FROM 
doctor d  JOIN Workingslots s ON d.id = s.Doctorid 
JOIN Slots s2 ON s.slotid = s2.id 
WHERE d.patientstreated >= 20    AND d.DeptId = @DeptId    AND s2.slotdate = @date;



/*to get nearest doctor who has more than 10 years of experience*/
SELECT d.Id, d.Name, d.Joiningdate, d.patientstreated, d.DeptId
 FROM doctor d JOIN Workingslots s ON d.id = s.Doctorid JOIN Slots s2 ON s.slotid = s2.id
  WHERE YEAR(s2.slotdate)-YEAR(d.Joiningdate) >=10  AND d.DeptId = @DeptId ORDER BY s2.slotdate DESC;

/*to get nearest available doctor who has treated more than 20 patients*/
SELECT d.Id, d.Name, d.Joiningdate, d.patientstreated, d.DeptId
 FROM doctor d JOIN Workingslots s ON d.id = s.Doctorid JOIN Slots s2 ON s.slotid = s2.id
  WHERE d.patientstreated >= 20  AND d.DeptId = @DeptId ORDER BY s2.slotdate DESC;





 