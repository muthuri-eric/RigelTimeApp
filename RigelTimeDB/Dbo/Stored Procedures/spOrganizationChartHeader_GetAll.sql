CREATE PROCEDURE [dbo].[spOrganizationChartHeader_GetAll]
AS
begin
	SELECT OrganizationChartHeaderId, Code, Description from dbo.OrganizationChartHeader
end
