CREATE TABLE [SchoolAppToday].[dbo].[Students]
    (
      Id int NOT NULL
             IDENTITY(1, 1) primary key,
	  User_Id nvarchar(128) NOT NULL,
	  FullName nvarchar(max),
	  Classe_Code varchar(20) NOT NULL,
	  constraint fk_Student_Classe foreign key (Classe_Code) 
               references Classes(Code)
               on update CASCADE
               on delete CASCADE,

    )
ON  [PRIMARY]
go
