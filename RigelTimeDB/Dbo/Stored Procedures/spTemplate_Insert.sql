CREATE PROCEDURE [dbo].[spTemplate_Insert]
	@EmployeeId int,
	@FID int,
	@Size int,
	@Valid int,
	@Template nvarchar(MAX)
AS
begin
	insert into dbo.Template (EmployeeId, FID, Size, Valid, Template)
	values(@EmployeeId,@FID, @Size, @Valid, @Template)
end
