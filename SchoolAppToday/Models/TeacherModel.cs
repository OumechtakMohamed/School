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
    }
    public class TeacherStudentsInfosModel
    {
        public GET_TEACHER_BY_ID_PS_Result Infos { get; set; }
        public List<GET_Students_FOR_TEACHER_By_Id_PS_Result> ClassesAndStudents { get; set; }
    }
}