CREATE TABLE [dbo].[DeviceAttlogStamp]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [SerialNumber] NVARCHAR(50) NULL, 
    [Stamp] NVARCHAR(50) NULL, 
    [NumberOfLines] INT NULL
)
