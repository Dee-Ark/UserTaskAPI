using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserTaskShared.DTO;
using UserTaskShared.DTO.UserRequest;
using UserTaskShared.Service.IService;

namespace UserTaskAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeachersManagerService _teacherService;
        public TeacherController(ITeachersManagerService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
        public async Task<IActionResult> SubmitTeachersDetails([FromBody] TeacherRequest request)
        {
            return Ok(await _teacherService.SubmitTeacherDetails(request));
        }
    }
}
