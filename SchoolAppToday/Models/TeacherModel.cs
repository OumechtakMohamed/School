using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolAppToday.Models
{
    public class TeacherInfosModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Code { get; set; }
        public Subjects Subject { get; set; }
        public List<StudentClasseModel> ClassesAndStudents { get; set; }
    }

    public class StudentClasseModel
    {
        public String StudentFullName { get; set; }
        public Classes Classe { get; set; }
    }
}