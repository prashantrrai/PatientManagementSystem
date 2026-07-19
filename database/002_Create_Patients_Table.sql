USE PatientManagementDB;
GO

SET ANSI_NULLS ON;
GO

SET QUOTED_IDENTIFIER ON;
GO

IF OBJECT_ID(N'dbo.Patients', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Patients
    (
        PatientId      INT IDENTITY(1,1) NOT NULL,
        FirstName      NVARCHAR(100) NOT NULL,
        LastName       NVARCHAR(100) NOT NULL,
        Gender         TINYINT NOT NULL,
        DateOfBirth    DATE NOT NULL,
        MobileNumber   VARCHAR(15) NOT NULL,
        Email          NVARCHAR(255) NOT NULL,
        Address        NVARCHAR(500) NOT NULL,
        BloodGroup     VARCHAR(5) NOT NULL,
        CreatedDate    DATETIME2 NOT NULL
            CONSTRAINT DF_Patients_CreatedDate
            DEFAULT SYSUTCDATETIME(),
        ModifiedDate   DATETIME2 NULL,
        IsActive       BIT NOT NULL
            CONSTRAINT DF_Patients_IsActive
            DEFAULT(1),

        CONSTRAINT CK_Patients_Gender
            CHECK (Gender IN (1,2,3)),

        CONSTRAINT PK_Patients
            PRIMARY KEY CLUSTERED (PatientId),

        CONSTRAINT UQ_Patients_MobileNumber
            UNIQUE (MobileNumber),

        CONSTRAINT UQ_Patients_Email
            UNIQUE (Email)
    );
END
GO

CREATE NONCLUSTERED INDEX IX_Patients_FirstName_LastName
ON dbo.Patients
(
    FirstName,
    LastName
);
GO