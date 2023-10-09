CREATE TABLE [dbo].[OrganizationChartItem]
(
	[OrganizationChartItemId] INT NOT NULL PRIMARY KEY, 
    [OrganizationChartHeaderId] INT NOT NULL,
    [Code] NVARCHAR(15) NULL, 
    [Description] NVARCHAR(50) NULL
)
