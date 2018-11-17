CREATE TABLE [SchoolAppToday].[dbo].[Ass_Prof_Classe]
    (
      Id int NOT NULL
             IDENTITY(1, 1) primary key,
	  Prof_Id int NOT NULL,
      ClasseCode varchar(20) NOT NULL,
	     constraint fk_Asse_Classe foreign key (ClasseCode) 
               references Classes(Code)
               on update no action
               on delete no action,
      constraint fk_Asse_Prof foreign key (Prof_Id) 
               references Teachers(Id)
               on update no action
               on delete no action,
    )
ON  [PRIMARY]
go
