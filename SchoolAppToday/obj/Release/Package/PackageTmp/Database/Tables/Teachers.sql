CREATE TABLE [SchoolAppToday].[dbo].[Teachers]
    (
      Id int NOT NULL
             IDENTITY(1, 1) primary key,
      FirstName varchar(50),
	  LastName varchar(50),
	  Age int,
	  User_Id int NOT NULL,
	  Subject_Code varchar(20) NOT NULL,
	  constraint fk_Teacher_Users foreign key (User_Id) 
               references Users(Id)
               on update no action
               on delete no action,
	  constraint fk_Teacher_Subject foreign key (Subject_Code) 
               references Subjects(Code)
               on update no action
               on delete no action,
    )
ON  [PRIMARY]
go
