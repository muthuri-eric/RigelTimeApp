CREATE PROCEDURE [dbo].[spEmployeeOrgChartDetail_GetAll]
as
begin
	SELECT OrganizationChartItemId, OrganizationChartHeaderId, Code, Description from OrganizationChartItem
end
