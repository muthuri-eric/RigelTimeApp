CREATE PROCEDURE [dbo].[spOrganizationChartHeader_Insert]
	@organizationchartheaderId int,
	@code nvarchar(15),
	@description nvarchar(50)
AS
begin
	insert into dbo.OrganizationChartHeader(OrganizationChartHeaderId, Code, Description)
	values(@organizationchartheaderId, @code, @description)
end
