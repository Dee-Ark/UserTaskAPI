using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserTaskShared.Model
{
    public class Student
    {
        public long Id { get; set; }
        public int NationalID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string DateofBirth { get; set; }
        public string StudentNumber { get; set; }
    }
}
