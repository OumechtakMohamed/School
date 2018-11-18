CREATE TABLE [SchoolAppToday].[dbo].[Teachers]
    (
      Id int NOT NULL
             IDENTITY(1, 1) primary key,
	  User_Id nvarchar(128) NOT NULL,
	  FullName nvarchar(max),
	  Subject_Code varchar(20) NOT NULL,
	  constraint fk_Teacher_Subject foreign key (Subject_Code) 
               references Subjects(Code)
               on update no action
               on delete no action,
    )
ON  [PRIMARY]
go
