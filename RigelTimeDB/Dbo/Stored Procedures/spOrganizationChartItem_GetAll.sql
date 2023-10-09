CREATE PROCEDURE [dbo].[spOrganizationChartItem_GetAll]
AS
begin
	SELECT OrganizationChartItemId, OrganizationChartHeaderId, Code, Description from dbo.OrganizationChartItem
end
