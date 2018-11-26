USE [SchoolApp]
GO
/****** Object:  StoredProcedure [dbo].[DELETE_TEACHER_FROM_CLASSE_PS]    Script Date: 23/11/2018 20:18:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Ou-mechtak
-- Create date: 26/11/2018
-- Description:	Delete TEACHER From Classe
-- =============================================
CREATE PROCEDURE [dbo].[DELETE_TEACHER_FROM_CLASSE_PS]
@teacher_id int,
@code varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	IF (@teacher_id Is Not NULL) AND (@code Is Not NULL)
	BEGIN
     DELETE from SchoolApp.dbo.Ass_Prof_Classe where Prof_Id = @teacher_id and ClasseCode = @code;
    END
	ELSE IF (@code Is NULL)
	BEGIN
     DELETE from SchoolApp.dbo.Ass_Prof_Classe where Prof_Id = @teacher_id ;
    END

END
