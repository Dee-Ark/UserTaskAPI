using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserTaskShared.DTO.UserResponse
{
    internal class TeacherResponseData
    {

        [JsonProperty("status")]
        public string Status { get; set; } = string.Empty;

        [JsonProperty("message")]
        public string Message { get; set; } = string.Empty;

        [JsonProperty("data")]
        public InitializeTeachersResponseData Data { get; set; }
    }

    public class InitializeTeachersResponseData
    {
        public int NationalID { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string DateofBirth { get; set; }
        public string TeacherNumber { get; set; }
        public string? Salary { get; set; }
    }
}
