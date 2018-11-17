CREATE TABLE [SchoolApp].[dbo].[Ass_Classe_Subject]
    (
      Id int NOT NULL
             IDENTITY(1, 1) primary key,
	  ClasseCode varchar(20) NOT NULL,
      SubjectCode varchar(20) NOT NULL,
	   constraint fk_Ass_Classe foreign key (ClasseCode) 
               references Classes(Code)
               on update no action
               on delete no action,
      constraint fk_Ass_Subject foreign key (SubjectCode) 
               references Subjects(Code)
               on update no action
               on delete no action,
    )
ON  [PRIMARY]
go
