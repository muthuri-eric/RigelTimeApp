CREATE PROCEDURE [dbo].[spOrganizationChartHeader_GetById]
	@id int
AS
begin
	SELECT OrganizationChartHeaderId, Code, Description from dbo.OrganizationChartHeader
	where OrganizationChartHeaderId = @Id
end
