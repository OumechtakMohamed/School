
SET ANSI_NULLS ON
use SchoolApp
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Ou-mechtak
-- Create date: 22/11/2018
-- Description:	GET ALL Teachers
-- =============================================
CREATE PROCEDURE GET_TEACHERS_PS
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SELECT t.Id,t.FullName,u.FirstName,u.LastName,u.UserName,u.Email,s.Code,s.Label from [UserDB].[dbo].[User] as u 
	join SchoolApp.dbo.Teachers as t  on u.Id = t.User_Id
	join SchoolApp.dbo.Subjects as s on s.Code = t.Subject_Code
END
GO


