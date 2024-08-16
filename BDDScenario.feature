Scenario:Find Doctor for a specific specialization
Given i am a client
when i make GET request to '/doctors/department/1'
then response must look like this
[
    {"DeptId":1,"name":"abhi","Id":2,"Gender":"male","Joiningdate":"09-09-2000","Patientstreated":20},
    {"DeptId":1,"name":"shreya","Id":3,"Gender":"female","Joiningdate":"09-09-2000","Patientstreated":20},
    {"DeptId":1,"name":"avi","Id":5,"Gender":"male","Joiningdate":"09-09-2000","Patientstreated":20},
]



Scenario:Get all Schedules of a doctor
Given i am a client
when i make a GET request to '/doctors/schedules/1'
then response must look like this
[
    {"DoctorId":1,"name":"abhi","PatientID":2,"date":"09-09-2000","from":"10:30","to":"11:00"},
    {"DoctorId":1,"name":"abhi","PatientID":4,"date":"09-09-2000","from":"11:30","to":"12:00"},
    {"DoctorId":1,"name":"abhi","PatientID":7,"date":"09-09-2000","from":"1:30","to":"2:00"},
]

Scenario:Create a new patient
Given i am a client
when i make a POST request to '/patients' with the following data <Patient>
then response status code should be 200

Examples:
|             Patient                       |
|{"name":"lopa","gender":"female","age":30} |
|{"name":"priya","gender":"female","age":40}|
|{"name":"abhi","gender":"male","age":25}   |


Scenario:Create a new appointment for the patient
Given i am a client
when i make a POST request to '/patients/appointments/1' with the following data <appointment>
Then response status code should be 200

Examples:
|                     appointment                                          |
|{"doctorId":1,"date":"09-09-2000","startFrom":"10:30:00","end":"11:00:00"}|
|{"doctorId":2,"date":"09-09-2000","startFrom":"11:30:00","end":"12:00:00"}|
|{"doctorId":3,"date":"09-09-2000","startFrom":"12:30:00","end":"13:00:00"}|


Scenario:Update the appointment time
Given i am a client
when i make a PUT request to '/patients/appointments/1/2' with following data <data>
Then response status code should be 200

Examples:
|        data                             |
|{"startfrom":"10:30:00","end":"11:00:00"}|
|{"startfrom":"11:00:00","end":"12:30:00"}|

Scenario:Fetch all appointments of a Patient
Given i am a client
when i make a GET request to '/patients/appointments/1'
Then response should look like this 
[
    {"Id":1,"TokenId":2,"DoctorId":2,"date":"09-09-2000","start":"10:00:00","end":"10:30:00"},
    {"Id":1,"TokenId":3,"DoctorId":1,"date":"09-09-2000","start":"11:00:00","end":"11:30:00"},
]









         