using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserTaskShared.DTO.UserRequest
{
    public class StudentRequest
    {
        public int NationalID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string DateofBirth { get; set; }
        public string StudentNumber { get; set; }
    }
}
