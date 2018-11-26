
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Ou-mechtak
-- Create date: 22/11/2018
-- Description:	Login History
-- =============================================
CREATE PROCEDURE Login_History_PS
	@user_id nvarchar(128)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    INSERT INTO  [UserDB].[dbo].[LoginHistory](USER_ID, Login_Date)
    VALUES (@user_id,Datetime.Now());
END
GO


