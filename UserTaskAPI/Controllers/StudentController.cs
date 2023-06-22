using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserTaskShared.DTO;
using UserTaskShared.DTO.UserRequest;
using UserTaskShared.Respository.Implementation;
using UserTaskShared.Service;
using UserTaskShared.Service.IService;

namespace UserTaskAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentManagerService _studentService;
        public StudentController(IStudentManagerService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
        public async Task<IActionResult> SubmitStudentDetails([FromBody] StudentRequest request)
        {
            return Ok(await _studentService.SubmitStudentDetails(request));
        }
    }
}
