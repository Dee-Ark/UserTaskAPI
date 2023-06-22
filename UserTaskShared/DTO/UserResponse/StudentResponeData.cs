using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserTaskShared.DTO.UserResponse
{
    internal class StudentResponeData
    {

        [JsonProperty("status")]
        public string Status { get; set; } = string.Empty;

        [JsonProperty("message")]
        public string Message { get; set; } = string.Empty;

        [JsonProperty("data")]
        public InitializeStudentResponseData Data { get; set; }
    }

    public class InitializeStudentResponseData
    {
        public int NationalID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string DateofBirth { get; set; }
        public string StudentNumber { get; set; }
    }
}
