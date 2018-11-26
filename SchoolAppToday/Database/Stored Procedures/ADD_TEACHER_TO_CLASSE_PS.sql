﻿USE [SchoolApp]
GO
/****** Object:  StoredProcedure [dbo].[ADD_TEACHER_TO_CLASSE_PS]    Script Date: 26/11/2018 20:18:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Ou-mechtak
-- Create date: 26/11/2018
-- Description:	ADD TEACHER TO Classe
-- =============================================
CREATE PROCEDURE [dbo].[ADD_TEACHER_TO_CLASSE_PS]
@teacher_id int,
@code varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	IF (@teacher_id Is Not NULL) AND (@code Is Not NULL)
	BEGIN
     INSERT INTO [dbo].[Ass_Prof_Classe]
           ([Prof_Id]
           ,[ClasseCode])
     VALUES
           (@teacher_id
           ,@code)
    END
END
