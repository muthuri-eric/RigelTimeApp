CREATE TABLE [dbo].[Employee] (
    [Id]   INT         IDENTITY(1,1)  NOT NULL,
    [EmployeeCode] NVARCHAR (50) NULL,
    [EmployeeId] INT NOT NULL,
    [EmployeeName]         NVARCHAR (50) NULL,
    [IsDeviceSynced] BIT NULL DEFAULT 0, 
    [Templates] INT NULL, 
    [LastChanged] DATETIME2 NULL, 
    CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED ([Id] ASC)
);

