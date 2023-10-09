CREATE TABLE [dbo].[Device] (
    [Id]            INT           NOT NULL IDENTITY,
    [SerialNumber] NVARCHAR (50) NOT NULL,
    [Name]          NVARCHAR (50) NULL,
    [TimeZone]      NVARCHAR (50) NULL,
    [AccountID]     INT           NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

