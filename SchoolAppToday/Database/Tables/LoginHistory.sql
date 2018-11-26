  CREATE TABLE [UserDB].[dbo].[LoginHistory]
    (
      Id int NOT NULL
             IDENTITY(1, 1) primary key,
      USER_ID nvarchar(128) Not Null,
	  Login_Date DateTime
    )
ON  [PRIMARY]
go