USE [SchoolApp]
GO
/****** Object:  StoredProcedure [dbo].[DELETE_STUDENT_PS]    Script Date: 23/11/2018 20:18:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Ou-mechtak
-- Create date: 22/11/2018
-- Description:	Delete STUDENT
-- =============================================
CREATE PROCEDURE [dbo].[DELETE_STUDENT_PS]
@student_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	DECLARE @UserId nvarchar(128);
	SET NOCOUNT ON;

	IF @student_id Is Not NULL
	SET @UserId = (select User_Id from SchoolApp.dbo.Students where id = @student_id);
	BEGIN
     DELETE from SchoolApp.dbo.Students where id = @student_id;
	 DELETE from [UserDB].[dbo].[User] where Id = @UserId
    END

END
