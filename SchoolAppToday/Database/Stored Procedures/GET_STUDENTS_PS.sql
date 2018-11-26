
SET ANSI_NULLS ON
use SchoolApp
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Ou-mechtak
-- Create date: 22/11/2018
-- Description:	GET ALL STUDENTS
-- =============================================
CREATE PROCEDURE GET_STUDENTS_PS
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SELECT s.Id,s.FullName,u.FirstName,u.LastName,u.UserName,u.Email,c.Code,c.Label from [UserDB].[dbo].[User] as u 
	join SchoolApp.dbo.Students as s  on u.Id = s.User_Id
	join SchoolApp.dbo.Classes as c on c.Code = s.Classe_Code
END
GO


