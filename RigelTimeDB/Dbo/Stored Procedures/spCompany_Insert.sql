CREATE PROCEDURE [dbo].[spCompany_Insert]
@AccountId int, 
@Code nvarchar(15), 
@Description nvarchar(50), 
@Industry nvarchar(50), 
@CycleId int, 
@Created datetime2, 
@Modified datetime2
AS
BEGIN
	INSERT INTO dbo.Company (AccountId, Code, Description, Industry, CycleId, Created, Modified)
	VALUES(@AccountId, @Code, @Description, @Industry, @CycleId, @Created, @Modified)
END
