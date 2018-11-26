USE [SchoolApp]
GO
/****** Object:  StoredProcedure [dbo].[DELETE_TEACHER_PS]    Script Date: 23/11/2018 20:18:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Ou-mechtak
-- Create date: 22/11/2018
-- Description:	Delete TEACHER
-- =============================================
CREATE PROCEDURE [dbo].[DELETE_TEACHER_PS]
@teacher_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	DECLARE @UserId nvarchar(128);
	SET NOCOUNT ON;

	IF @teacher_id Is Not NULL
	SET @UserId = (select User_Id from SchoolApp.dbo.Teachers where id = @teacher_id);
	BEGIN
     DELETE from SchoolApp.dbo.Teachers where id = @teacher_id;
	 DELETE from [UserDB].[dbo].[User] where Id = @UserId
    END

END
