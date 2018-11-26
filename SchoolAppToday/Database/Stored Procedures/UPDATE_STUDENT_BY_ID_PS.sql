
SET ANSI_NULLS ON
use SchoolApp
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Ou-mechtak
-- Create date: 22/11/2018
-- Description:	uPdate Student By Id
-- =============================================
ALTER PROCEDURE UPDATEE_STUDENT_BY_ID_PS
@student_id int,
@FirstName nvarchar(max),
@LastName nvarchar(max),
@Email nvarchar(256),
@Code varchar(20)
AS
BEGIN
	DECLARE @UserId nvarchar(128);
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	IF @student_id Is Not NULL
	BEGIN
	SET @UserId = (select User_Id from SchoolApp.dbo.Students where id = @student_id);
	update [UserDB].[dbo].[User] set FirstName = @FirstName,Lastname = @Lastname,Email = @Email
	where Id = @UserId
	update SchoolApp.dbo.Students set Classe_Code = @Code where Id = @student_id
	END
END
GO


