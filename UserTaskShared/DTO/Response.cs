using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserTaskShared.DTO
{
    public class Response
    {
        public string ResponseCode { get; set; } = string.Empty;
        public string ResponseMessage { get; set; } = string.Empty;
        public bool HasError { get; set; }
        public dynamic Data { get; set; }

        public Response(string responseCode = "00", string responseMessage = "Successful", bool hasError = false)
        {
            ResponseCode = hasError ? responseCode : "00";
            ResponseMessage = responseMessage;
            HasError = hasError;
        }


        public bool IsSuccessful()
        {
            return ResponseCode == "00";
        }
    }
}
