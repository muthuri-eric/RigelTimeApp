CREATE PROCEDURE [dbo].[spOrganizationChartItem_GetByHeaderId]
@Id int
AS
begin
	SELECT OrganizationChartItemId, OrganizationChartHeaderId, Code, Description from OrganizationChartItem
	where OrganizationChartHeaderId = @Id
end

