CREATE PROCEDURE [dbo].[spOrganizationChartItem_GetById]
@Id int
AS
begin
	SELECT OrganizationChartItemId, OrganizationChartHeaderId, Code, Description from OrganizationChartItem
	where OrganizationChartItemId = @Id
end
