CREATE PROCEDURE [dbo].[spEmployeeOrgChartDetail_Insert]
@Id int, 
@EmployeeId int, 
@OrganizationChartItemId int
as
begin
	insert into dbo.EmployeeOrgChartDetail (Id, EmployeeId, OrganizationChartItemId)
	values(@id, @EmployeeId, @OrganizationChartItemId)
end
