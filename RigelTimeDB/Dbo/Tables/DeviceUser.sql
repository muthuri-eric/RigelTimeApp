CREATE TABLE [dbo].[DeviceUser] (
    [EmployeeId] INT           NOT NULL,
    [Name]       NVARCHAR (50) NULL,
    [Privilege]  NVARCHAR (50) NULL,
    [Group]      NVARCHAR (50) NULL,
    [Password]   NVARCHAR (50) NULL,
    [TimeZone]   INT NULL,
    PRIMARY KEY CLUSTERED ([EmployeeId] ASC)
);

