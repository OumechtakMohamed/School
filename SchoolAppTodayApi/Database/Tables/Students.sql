CREATE TABLE [SchoolAppToday].[dbo].[Students]
    (
      Id int NOT NULL
             IDENTITY(1, 1) primary key,
      FirstName varchar(50),
	  LastName varchar(50),
	  Age int,
	  User_Id int NOT NULL,
	  Classe_Code varchar(20) NOT NULL,
	  constraint fk_Student_Users foreign key (User_Id) 
               references Users(Id)
               on update no action
               on delete no action,
	  constraint fk_Student_Classe foreign key (Classe_Code) 
               references Classes(Code)
               on update no action
               on delete no action,

    )
ON  [PRIMARY]
go
