
SET ANSI_NULLS ON
use SchoolApp
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Ou-mechtak
-- Create date: 27/11/2018
-- Description:	GET StudentS fOR tEACHER
-- =============================================
create PROCEDURE GET_Students_FOR_TEACHER_By_Id_PS
@teacher_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	select u.Id as User_Id,u.FirstName + ' ' + u.LastName as FullName, c.Code as Classe_Code,c.Label as Classe_Label,u.Email from dbo.Students as st 
	join dbo.Classes as c on  c.Code = st.Classe_Code 
	join dbo.Ass_Prof_Classe as ass on c.Code = ass.ClasseCode 
	join [UserDB].[dbo].[User] as u on u.Id = st.User_Id
	where ass.Prof_Id = @teacher_id
END
GO


