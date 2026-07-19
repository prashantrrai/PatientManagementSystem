USE PatientManagementDB;
GO

INSERT INTO dbo.Patients
(
    FirstName,
    LastName,
    Gender,
    DateOfBirth,
    MobileNumber,
    Email,
    Address,
    BloodGroup
)
VALUES
('John','Doe',1,'1995-05-10','9876543210','john.doe@email.com','Ahmedabad, Gujarat','A+'),
('Jane','Smith',2,'1992-03-21','9876543211','jane.smith@email.com','Surat, Gujarat','O+'),
('Rahul','Sharma',1,'1990-09-15','9876543212','rahul.sharma@email.com','Rajkot, Gujarat','B+'),
('Priya','Patel',2,'1998-11-08','9876543213','priya.patel@email.com','Vadodara, Gujarat','AB+'),
('Amit','Verma',1,'1988-01-27','9876543214','amit.verma@email.com','Mumbai, Maharashtra','O-');
GO