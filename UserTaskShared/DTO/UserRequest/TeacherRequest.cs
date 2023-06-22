using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserTaskShared.DTO.UserRequest
{
    public class TeacherRequest
    {
        public int NationalID { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string DateofBirth { get; set; }
        public string TeacherNumber { get; set; }
        public string Salary { get; set; }
    }
}
