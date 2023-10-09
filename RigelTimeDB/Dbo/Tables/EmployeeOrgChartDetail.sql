CREATE TABLE [dbo].[EmployeeOrgChartDetail]
(
	[Id] INT NOT NULL PRIMARY KEY Identity, 
    [EmployeeId] INT NOT NULL, 
    [OrganizationChartItemId] INT NOT NULL
)
