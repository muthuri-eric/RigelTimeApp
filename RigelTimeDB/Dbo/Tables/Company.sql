CREATE TABLE [dbo].[Company]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [AccountId] INT NULL, 
    [Code] NVARCHAR(15) NULL, 
    [Description] NVARCHAR(50) NULL, 
    [Industry] NVARCHAR(50) NULL, 
    [CycleId] INT NULL, 
    [Created] DATETIME2 NULL, 
    [Modified] DATETIME2 NULL
)
