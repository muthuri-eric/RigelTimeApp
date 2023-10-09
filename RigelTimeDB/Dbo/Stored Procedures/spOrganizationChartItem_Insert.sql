CREATE PROCEDURE [dbo].[spOrganizationChartItem_Insert]
	@organizationChartItemId int,
	@organizationChartHeaderId int,
	@code nvarchar(15),
	@description nvarchar(30)
AS
begin
	insert into dbo.OrganizationChartItem (OrganizationChartItemId, OrganizationChartHeaderId, Code, Description)
	values (@organizationChartItemId, @organizationChartHeaderId, @code, @description)
end
