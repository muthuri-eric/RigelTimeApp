CREATE TABLE [dbo].[Attendance] (
    [AttendanceId]  INT           IDENTITY (1, 1) NOT NULL,
    [EmployeeId]    INT           NOT NULL,
    [ClockDateTime] DATETIME2 (7) NULL,
    [Status]     INT           NULL,
    [Verify]      INT           NULL,
    [WorkCode] INT NULL, 
    [Reserved1] INT NULL, 
    [Reversed2] INT NULL, 
    [DeviceID] INT NULL, 
    PRIMARY KEY CLUSTERED ([AttendanceId] ASC)
);

