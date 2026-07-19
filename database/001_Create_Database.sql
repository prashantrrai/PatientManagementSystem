USE master;
GO

IF NOT EXISTS
(
    SELECT 1
    FROM sys.databases
    WHERE name = N'PatientManagementDB'
)
BEGIN
    CREATE DATABASE PatientManagementDB;
END
GO