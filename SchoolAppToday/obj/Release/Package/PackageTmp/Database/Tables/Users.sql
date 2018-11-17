CREATE TABLE [SchoolAppToday].[dbo].[Users]
    (
      Id int NOT NULL
             IDENTITY(1, 1) primary key,
      Login varchar(50) NOT NULL,
	  Password varchar(200) NOT NULL
    )
ON  [PRIMARY]
go