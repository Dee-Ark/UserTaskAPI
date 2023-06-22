using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserTaskShared.DTO;
using UserTaskShared.DTO.UserRequest;

namespace UserTaskShared.Service.IService
{
    public interface ITeachersManagerService
    {
        Task<Response> SubmitTeacherDetails(TeacherRequest request);
    }
}
