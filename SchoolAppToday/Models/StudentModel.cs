using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolAppToday.Models
{
    public class StudentInfosModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email  { get; set; }
        public Classes Classe { get; set; }
        public List<StudentSubjectTeacherModel> SubjectsAndTeachers { get; set; }
    }

    public class StudentSubjectTeacherModel
    {
        public Subjects Subject { get; set; }
        public String TeacherFullName { get; set; }
    }
}